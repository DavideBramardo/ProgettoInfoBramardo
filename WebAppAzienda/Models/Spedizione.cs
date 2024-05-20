using System.ComponentModel.DataAnnotations;

namespace WebAppAzienda.Models
{
    public class Spedizione
    {
        [Key]
        public int? IdSpedizione { get; set; }
        public int IdOrdine { get; set; }
        public DateTime? DataSpedizione { get; set; }
        public string? IndirizzoSpedizione { get; set; }
    }
}
