using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BusinessLogic.Models;

namespace BusinessLogic.Abstract
{
    [ServiceContract]
    public interface IRolletManager
    {
        [OperationContract]
        RolletBlo GetRollet(int value);

        [OperationContract]
        void UpdateRollet(RolletBlo rollet);
    }
}
