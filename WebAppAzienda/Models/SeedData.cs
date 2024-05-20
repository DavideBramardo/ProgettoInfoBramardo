using Microsoft.EntityFrameworkCore;
using WebAppAzienda.Data;

namespace WebAppAzienda.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Prodotto.Any())
                {
                    return;  
                }
                context.Prodotto.AddRange(
                    new Prodotto
                    {
                        Id="1",
                        Nome = "Cappone di Morozzo",
                        Ingredienti = "Cappone di Morozzo",
                        Peso = 1.8,
                        Prezzo = 22
                    },
                    new Prodotto
                    {
                        Id = "2",
                        Nome = "Galletto",
                        Ingredienti = "Galletto",
                        Peso = 2.2,
                        Prezzo = 15
                    },
                    new Prodotto
                    {
                        Id = "3",
                        Nome = "Faraona",
                        Ingredienti = "Faraona",
                        Peso = 2,
                        Prezzo = 15
                    },
                    new Prodotto
                    {
                        Id = "4",
                        Nome = "Pollastra",
                        Ingredienti = "Pollastra",
                        Peso = 1.6,
                        Prezzo = 14
                    },
                    new Prodotto
                    {
                        Id = "5",
                        Nome = "Anatra",
                        Ingredienti = "Anatra",
                        Peso = 2.5,
                        Prezzo = 18
                    },
                    new Prodotto
                    {
                        Id = "6",
                        Nome = "Oca",
                        Ingredienti = "Oca",
                        Peso = 4,
                        Prezzo = 15
                    },
                    new Prodotto
                    {
                        Id = "7",
                        Nome = "Filetto",
                        Ingredienti = "Filetto di scottona piemontese",
                        Peso = 0.3,
                        Prezzo = 35
                    },
                    new Prodotto
                    {
                        Id = "8",
                        Nome = "Sottofiletto",
                        Ingredienti = "Sottofiletto di scottona piemontese",
                        Peso = 0.4,
                        Prezzo = 25
                    },
                    new Prodotto
                    {
                        Id = "9",
                        Nome = "Trita scelta",
                        Ingredienti = "Carne tritata scelta di scottona piemontese",
                        Peso = 0.3,
                        Prezzo = 18
                    },
                    new Prodotto
                    {
                        Id = "10",
                        Nome = "Trita",
                        Ingredienti = "Carne tritata per ragù di scottona piemontese",
                        Peso = 0.5,
                        Prezzo = 15
                    },
                    new Prodotto
                    {
                        Id = "11",
                        Nome = "Trippa",
                        Ingredienti = "Trippa di scottona piemontese",
                        Peso = 1.2,
                        Prezzo = 14
                    },
                    new Prodotto
                    {
                        Id = "12",
                        Nome = "Spezzatino",
                        Ingredienti = "Spezzatino di scottona piemontese",
                        Peso = 0.5,
                        Prezzo = 13
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
