using System.Collections.Generic;
using Giprojivmash.DAL.Entities;

namespace Giprojivmash.BLL.Interfaces
{
    public interface IServiceThirdLayerService : IBaseService<ServiceThirdLayerEntity>
    {
        public IEnumerable<ServiceThirdLayerEntity> GetAllServiceThirdLayerByServiceFirstId(int serviceFirstLayerId);
    }
}
