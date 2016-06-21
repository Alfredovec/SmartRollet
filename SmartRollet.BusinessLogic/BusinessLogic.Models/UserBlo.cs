using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    [DataContract]
    public class UserBlo
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Email { get; set; }
    }
}
