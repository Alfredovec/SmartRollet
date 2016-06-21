using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DataAccess.Models.Entities
{
    [DataContract]
    public class Rollet
    {
        [Key, DataMember]
        public int Id { get; set; }

        [DataMember]
        public int Height { get; set; }

        [DataMember]
        public int Width { get; set; }

        [NotMapped, DataMember]
        public int RolletState { get; set; }

        [NotMapped, DataMember]
        public int LighterState { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public int LighterId { get; set; }

        public virtual User User { get; set; }

        public virtual Lighter Lighter { get; set; }
    }
}
