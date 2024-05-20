using System.ComponentModel.DataAnnotations;
using Humanizer.Localisation;

namespace WebAppAzienda.Models
{
    public class Ordine
        {
            public int Id { get; set; }

            [DataType(DataType.Date)]
            public DateTime Data { get; set; }
            [Display(Name = "Id dell'utente")]
            public int UtenteId { get; set; }
            [Display(Name = "Descrizione dell'ordine")]
            public string  DescrProdotti { get; set; }
 
    }
}
