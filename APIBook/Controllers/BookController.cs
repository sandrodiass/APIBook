using APIBook.Model;
using APIBook.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController: ControllerBase
    {
        readonly IbookRepository _bookRepository;
        public BookController(IbookRepository bookRepository)
        {
            _bookRepository = bookRepository;

        }
        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepository.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBooks(int id)
        {
            return await _bookRepository.Get(id);
        }
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook([FromBody] Book book ) 
        {
            var newbook = await _bookRepository.Create(book);
            return CreatedAtAction(nameof(GetBooks), new { id = newbook.Id }, newbook);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) 
        {
            var bookdelete = await _bookRepository.Get(id);

            if (bookdelete != null)
                
            await _bookRepository.Delet(bookdelete.Id );

            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult> Put(int id,[FromBody]Book book) 
        {
            if (id == book.Id)
                return BadRequest();
                await _bookRepository.Updat(book);
            return NoContent() ;
        }
    }
}
