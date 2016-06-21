using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DataAccess.Models.Entities
{
    [DataContract]
    public class User
    {
        [Key, DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Email { get; set; }
        
        public virtual ICollection<Rollet> Rollets { get; set; } 
    }
}
