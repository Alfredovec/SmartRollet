using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Models;

namespace BusinessLogic.Abstract
{
    [ServiceContract]
    public interface IUserManager
    {
        [OperationContract]
        UserBlo Get(string email);

        [OperationContract]
        void Post(UserBlo user);
    }
}
