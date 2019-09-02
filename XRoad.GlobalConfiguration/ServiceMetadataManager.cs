using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using SimpleSOAPClient;
using SimpleSOAPClient.Handlers;
using SimpleSOAPClient.Helpers;
using SimpleSOAPClient.Models;
using XRoad.Domain;
using XRoad.Domain.Header;
using XRoad.GlobalConfiguration.Domain.SOAP;
using XRoad.GlobalConfiguration.Metadata;

namespace XRoad.GlobalConfiguration
{
    public class ServiceMetadataManager : IServiceMetadataManager
    {
        private static readonly UserIdHeader UserIdHeader = new UserIdHeader
            {Value = ".NetCore_ServiceMetadataManager"};

        public async Task<SharedParams> GetSharedParamsAsync(Uri securityServerUri)
        {
            var httpClient = new HttpClient();
            var verificationConfUri = new Uri(securityServerUri, "verificationconf");
            using (var httpStream = await httpClient.GetStreamAsync(verificationConfUri))
            {
                using (var zipArchive = new ZipArchive(httpStream))
                {
                    var instanceIdentifier = await GetInstanceIdentifierAsync(zipArchive);
                    return GetSharedParams(instanceIdentifier, zipArchive);
                }
            }
        }

        public async Task<byte[]> GetWsdlAsync(Uri securityServerUri, SubSystemIdentifier subSystemId,
            ServiceIdentifier targetService)
        {
            byte[] wsdlFileBytes = { };

            var client = SoapClient.Prepare()
                .WithHandler(new DelegatingSoapHandler
                {
                    OnHttpResponseAsyncAction = async (soapClient, httpContext, cancellationToken) =>
                    {
                        if (httpContext.Response.Content.IsMimeMultipartContent())
                        {
                            var streamProvider =
                                await httpContext.Response.Content.ReadAsMultipartAsync(cancellationToken);
                            var contentCursor = streamProvider.Contents.GetEnumerator();

                            contentCursor.MoveNext();
                            var soapResponse = contentCursor.Current;

                            contentCursor.MoveNext();
                            var wsdlFile = contentCursor.Current;

                            contentCursor.Dispose();

                            wsdlFileBytes = await wsdlFile.ReadAsByteArrayAsync();
                            httpContext.Response.Content = soapResponse;
                        }
                    }
                });

            var body = SoapEnvelope.Prepare().Body(new GetWsdlRequest
            {
                ServiceCode = targetService.ServiceCode,
                ServiceVersion = targetService.ServiceVersion
            }).WithHeaders(new List<SoapHeader>
            {
                IdHeader.Random,
                UserIdHeader,
                ProtocolVersionHeader.Version40,
                (XRoadClient) subSystemId,
                new XRoadService
                {
                    Instance = targetService.Instance,
                    MemberClass = targetService.MemberClass,
                    MemberCode = targetService.MemberCode,
                    SubSystemCode = targetService.SubSystemCode,
                    ServiceCode = "getWsdl",
                    ServiceVersion = "v1"
                }
            });

            var result = await client.SendAsync(securityServerUri.ToString(), string.Empty, body);
            client.Dispose();

            result.ThrowIfFaulted();

            return wsdlFileBytes;
        }

        public async Task<List<ServiceIdentifier>> GetServicesAsync(Uri securityServerUri, SubSystemIdentifier client,
            SubSystemIdentifier source)
        {
            var soapEnvelope = SoapEnvelope.Prepare()
                .Body(new ListMethodsRequest())
                .WithHeaders(
                    new List<SoapHeader>
                    {
                        IdHeader.Random,
                        UserIdHeader,
                        ProtocolVersionHeader.Version40,
                        (XRoadClient) client,
                        new XRoadService
                        {
                            Instance = source.Instance,
                            MemberClass = source.MemberClass,
                            MemberCode = source.MemberCode,
                            SubSystemCode = source.SubSystemCode,
                            ServiceCode = "listMethods"
                        }
                    });

            
            var soapClient = SoapClient.Prepare();
            var envelope = await soapClient.SendAsync(securityServerUri.ToString(), string.Empty, soapEnvelope);
            soapClient.Dispose();

            envelope.ThrowIfFaulted();
            return envelope.Body<ListMethodsResponse>().Services.Select(o => (ServiceIdentifier) o).ToList();
        }


        private async Task<string> GetInstanceIdentifierAsync(ZipArchive zipArchive)
        {
            const string zipEntryName = "verificationconf/instance-identifier";
            var zipEntry = zipArchive.GetEntry(zipEntryName);

            using (var instanceIdentifierStream = zipEntry.Open())
            {
                var reader = new StreamReader(instanceIdentifierStream);
                return await reader.ReadToEndAsync();
            }
        }

        private SharedParams GetSharedParams(string instanceIdentifier, ZipArchive zipArchive)
        {
            var zipEntryName = $"verificationconf/{instanceIdentifier}/shared-params.xml";
            var zipEntry = zipArchive.GetEntry(zipEntryName);

            using (var sharedParamsStream = zipEntry.Open())
            {
                var xmlSerializer = new XmlSerializer(typeof(SharedParams));
                return (SharedParams) xmlSerializer.Deserialize(sharedParamsStream);
            }
        }
    }
}