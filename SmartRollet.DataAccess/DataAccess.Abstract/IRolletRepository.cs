using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models.Entities;

namespace DataAccess.Abstract
{
    [ServiceContract]
    public interface IRolletRepository
    {
        [OperationContract]
        IEnumerable<Rollet> GetRollets(string email);

        [OperationContract]
        void UpdateRollet(Rollet rollet);

        [OperationContract]
        void ChangePosition(int id, int change);
    }
}
