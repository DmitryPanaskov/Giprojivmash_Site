using System.Collections.Generic;
using Giprojivmash.DAL.Entities;

namespace Giprojivmash.BLL.Interfaces
{
    public interface IServiceThirdLayerService : IBaseInterface<ServiceThirdLayerEntity>
    {
        public IEnumerable<ServiceThirdLayerEntity> GetAllServiceThirdLayerByServiceFirstId(int serviceFirstLayerId);
    }
}
