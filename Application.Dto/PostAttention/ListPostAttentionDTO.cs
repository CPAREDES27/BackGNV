using System.ComponentModel.DataAnnotations;

namespace Application.Dto.PostAttention
{
    public class ListPostAttentionDTO
    {
        public int NumeroPagina { get; set; }
        public int NumeroRegistros { get; set; }
        public string NumeroExpediente { get; set; }

        [Required(ErrorMessage = "IdProveedor es requerido.")]
        public int ?IdProveedor { get; set; }
    }
}
