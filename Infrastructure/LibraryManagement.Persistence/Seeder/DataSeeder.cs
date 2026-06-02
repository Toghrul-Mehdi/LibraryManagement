using LibraryManagement.Domain.Entities;
using LibraryManagement.Persistence.Context;

namespace LibraryManagement.Persistence.Seeder;

public static class DataSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (context.Books.Any())
            return;

        var books = new List<Book>
        {
            new Book { Title = "Müharibə və Sülh",        Author = "Lev Tolstoy",                Year = 1869, Price = 12.99m, Genre = "Roman"        },
            new Book { Title = "Cinayət və Cəza",          Author = "Fyodor Dostoyevski",          Year = 1866, Price = 10.49m, Genre = "Roman"        },
            new Book { Title = "Dönüşüm",                  Author = "Franz Kafka",                 Year = 1915, Price = 7.99m,  Genre = "Fantastika"   },
            new Book { Title = "Yüz İlin Tənhalığı",       Author = "Gabriel García Márquez",      Year = 1967, Price = 11.50m, Genre = "Sehrli Realizm"},
            new Book { Title = "Ölülər",                   Author = "Cəlil Məmmədquluzadə",        Year = 1909, Price = 6.99m,  Genre = "Dram"         },
            new Book { Title = "Aldanmış Kəvakib",         Author = "Mirzə Fətəli Axundzadə",      Year = 1857, Price = 5.99m,  Genre = "Satira"       },
            new Book { Title = "Dağlar Arxasında Üç Dost", Author = "İlyas Əfəndiyev",             Year = 1963, Price = 8.49m,  Genre = "Roman"        },
            new Book { Title = "Kar",                      Author = "Orhan Pamuk",                 Year = 2002, Price = 13.99m, Genre = "Roman"        },
            new Book { Title = "Köhnə Dəftər",             Author = "Əli Vəliyev",                 Year = 1975, Price = 4.99m,  Genre = "Hekayə"       },
            new Book { Title = "Şamo",                     Author = "Süleyman Rəhimov",             Year = 1956, Price = 9.99m,  Genre = "Roman"        },
        };

        await context.Books.AddRangeAsync(books);
        await context.SaveChangesAsync();
    }
}