using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRollet.DomainModel.Entities
{
    public class Rollet
    {
        [Key]
        public int Id { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }
    }
}
