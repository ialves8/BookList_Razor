using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookList_Razor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookList_Razor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _db;

        [TempData]
        public string Message { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Book> Books { get; set; }

        public string SomeData { get; set; }

        public async Task OnGet()
        {
            Books = await _db.Books.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = _db.Books.Find(id);
            _db.Books.Remove(book);
            await _db.SaveChangesAsync();

            Message = "Book Deleted Successfully";

            return RedirectToPage("Index");
        }
    }
}