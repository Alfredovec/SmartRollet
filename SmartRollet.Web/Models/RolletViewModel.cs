using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartRollet.Web.Models
{
    public class RolletViewModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public int RolletState { get; set; }

        public int LighterState { get; set; }

        public int LighterId { get; set; }
    }
}