using System.ComponentModel.DataAnnotations;

namespace WebAppAzienda.Models
{
    public class Utente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "È richiesto il nome.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "È richiesto il cognome.")]
        public string Cognome { get; set; }
        [Required(ErrorMessage = "È richiesto il numero telefonico.")]
        [RegularExpression(@"^\+(?:[0-9] ?){6,14}[0-9]$", ErrorMessage = "Sono stati inseriti caratteri non validi")]
        public string NTelefonico { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Sono stati inseriti caratteri non validi")]
        [Required(ErrorMessage = "È richiesto un indirizzo email.")]
        public string Email { get; set; }
    }
}
