using System.Collections.Generic;

namespace Application.Dto
{
    public class MenuDTO
    {
        //public MenuPadre MenuPadre;
        public List<MenuPadre> MenusPadre;
    }

    public class MenuPadre
    {
        public int IdPadre { get; set; }
        public string DescMenu { get; set; }
        public string UrlImagen { get; set; }

        public List<MenuHijo> MenusHijos { get; set; }

    }

    public class MenuHijo
    {
        public int IdPadre { get; set; }
        public int IdHijo { get; set; }
        public int IdOpcion { get; set; }
        public string DescMenu { get; set; }
        public string Url { get; set; }
        public int? Orden { get; set; }
        public bool ActivoHijo { get; set; }
        public string UrlImagen { get; set; } 
    } 
}