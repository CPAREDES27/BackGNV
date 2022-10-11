﻿using System.ComponentModel.DataAnnotations;

namespace Domain.MainModule.Entities
{
    public class MenuPadreEntity
    {
        [Key]
        public int IdMenuPadre { get; set; }
        public int IdOpcion { get; set; }
        public string DescMenu { get; set; }
        public string Url { get; set; }
        public int? Orden { get; set; }
        public bool Activo { get; set; }
        public string UrlImagen { get; set; }
    }
}