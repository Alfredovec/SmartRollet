using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RolletApi.Models;

namespace RolletApi.Abstract
{
    [ServiceContract]
    public interface IRolletService
    {
        [OperationContract]
        RolletDto GetRolletDto();
    }
}
