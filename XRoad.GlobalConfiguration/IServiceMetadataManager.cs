using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XRoad.Domain;
using XRoad.GlobalConfiguration.Metadata;

namespace XRoad.GlobalConfiguration
{
    public interface IServiceMetadataManager
    {
        Task<SharedParams> GetSharedParamsAsync(Uri securityServerUri);

        Task<byte[]> GetWsdlAsync(Uri securityServerUri, SubSystemIdentifier client, ServiceIdentifier targetService);

        Task<List<ServiceIdentifier>> GetServicesAsync(Uri securityServerUri, SubSystemIdentifier client,
            SubSystemIdentifier source);
    }
}