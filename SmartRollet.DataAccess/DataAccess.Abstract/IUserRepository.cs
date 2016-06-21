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
    public interface IUserRepository
    {
        [OperationContract]
        User Get(string email);

        [OperationContract]
        void Post(User user);
    }
}
