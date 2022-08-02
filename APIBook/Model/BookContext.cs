using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBook.Model
{    
    //conexão com o banco 
    public class BookContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Data Source = BÁRBARAFARIA-PC\SQLSERVER; Database = cursomvc; User ID=sa;Password=1234");
        } 
       public  DbSet<Book> books { get; set; }
    }
}
