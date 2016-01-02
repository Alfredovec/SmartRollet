using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Abstract
{
    [ServiceContract]
    public interface IRolletRepository
    {
        [OperationContract]
        Rollet GetRollet();
    }
}
