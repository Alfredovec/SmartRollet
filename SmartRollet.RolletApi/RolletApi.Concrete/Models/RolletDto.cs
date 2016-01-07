using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RolletApi.Concrete.Models
{
    public class RolletDto
    {
        public int Id { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int OpenedPart { get; set; }
    }
}