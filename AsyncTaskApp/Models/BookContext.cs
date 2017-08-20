using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AsyncTaskApp.Models;
using System.Data.Entity;

namespace AsyncTaskApp.Models
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }

    public class BookDbInitializer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext context)
        {
            context.Books.Add(new Book { Name = "Voyna i mir", Author = "L. Tolstoy", Price = 220 });
            context.Books.Add(new Book { Name = "Otsy i dety", Author = "I. Turgenev", Price = 185 });
            context.Books.Add(new Book { Name = "Chayka", Author = "A. Chehov", Price = 130 });

            base.Seed(context);
        }
    }
}