using System.Collections.Generic;
using Giprojivmash.DAL.Entities;
using Giprojivmash.DataModels.Enums;

namespace Giprojivmash.BLL.Interfaces
{
    public interface IContactDataService : IBaseService<ContactDataEntity>
    {
        public IEnumerable<ContactDataEntity> GetContactDataListByPositionType(PositionType position);
    }
}
