using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Security
{
    public class RolMenuDTO
    {
        public RolMenuDTO()
        {
            menusPadre = new List<MenuPadres>();
        }
        public List<MenuPadres> menusPadre { get; set; }  
    }
    public class MenuGeneral
    {
        public RolMenuDTO menus { get; set; }
    }
    public class MenuPadres
    {
        public int RolId { get; set; }
        public int IdPadre { get; set; }
        public string DescMenu { get; set; }
        public string UrlImagen { get; set; }
        public List<MenuRolHijo> menusHijos { get; set; }
    }
    public class MenuRolHijo
    {
        public int IdPadre { get; set; }
        public int IdMenuHijo { get; set; }
        public int IdOpcion { get; set; }
        public string DescMenu { get; set; }
        public string Url { get; set; }
        public bool Activo { get; set; }
    }
}

