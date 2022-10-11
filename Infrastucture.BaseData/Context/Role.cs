using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastucture.BaseData.Context
{
    public partial class Role
    {
        public int RolId { get; set; }
        public string DescRol { get; set; }
        public bool? Activo { get; set; }
    }
}
