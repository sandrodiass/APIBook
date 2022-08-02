using APIBook.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBook.Repositories
{
    public class BookRepository : IbookRepository
    {
        public readonly BookContext _contex;
        public BookRepository(BookContext context)
        {
            _contex = context;
        }
        public async Task<Book> Create(Book book)
        {  // chamando a conexão, na entidade books , adicionando nela o parametro passado 
            _contex.books.Add(book);
           await _contex.SaveChangesAsync();
            return book;
        }

        public async Task Delet(int id)
        {    //buscar o id no banco 
            var booktoDelete = await _contex.books.FindAsync(id);
            //deleta o id que encontrar 
           
                _contex.books.Remove(booktoDelete);
                await _contex.SaveChangesAsync();
          
        }
        public async Task<IEnumerable<Book>> Get()
        {
            return await  _contex.books.ToListAsync();
        }

        public async Task<Book> Get(int id)
        {
           return  await _contex.books.FindAsync(id);
        }

        public async Task Updat(Book book)
        {
            _contex.Entry(book).State = EntityState.Modified;
            await _contex.SaveChangesAsync();
        }
    }
}
