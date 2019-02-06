using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookList_Razor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookList_Razor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        [TempData]
        public string Message { get; set; }

        public void OnGet(int id)
        {
            Book = _db.Books.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var bookInDb = _db.Books.Find(Book.Id);
                bookInDb.ISBN = Book.ISBN;
                bookInDb.Title = Book.Title;
                bookInDb.Author = Book.Author;
                bookInDb.Price = Book.Price;
                bookInDb.Avaibility = Book.Avaibility;

                await _db.SaveChangesAsync();
                Message = "Book updated Successfully";

                return RedirectToPage("Index");
            }

            return RedirectToPage();
        }
    }
}