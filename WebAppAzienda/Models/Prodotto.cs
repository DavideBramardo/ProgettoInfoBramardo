using System.ComponentModel.DataAnnotations;

namespace WebAppAzienda.Models
{
    public class Prodotto
    {
        [Key]
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Ingredienti { get; set; }
        public double Peso { get; set; }
        public decimal Prezzo { get; set; }
    }
}
