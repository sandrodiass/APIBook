using APIBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBook.Repositories
{
     public interface IbookRepository
    {
        Task<IEnumerable<Book>> Get();

        Task<Book> Get(int id);


        Task<Book> Create(Book book);
        Task Updat(Book book);
        
        Task Delet(int id);
    }
}
