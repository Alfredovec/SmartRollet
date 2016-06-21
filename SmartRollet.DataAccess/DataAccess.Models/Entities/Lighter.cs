using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DataAccess.Models.Entities
{
    [DataContract]
    public class Lighter
    {
        [Key, DataMember]
        public int Id { get; set; }


        [NotMapped, DataMember]
        public int State { get; set; }
    }
}
