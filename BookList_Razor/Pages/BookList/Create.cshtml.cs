using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookList_Razor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookList_Razor.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private ApplicationDbContext _db;

        [TempData]
        public string Message { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _db.Books.Add(Book);
            await _db.SaveChangesAsync();
            Message = "New Book Added Successfully!";
            return RedirectToPage("Index");
        }
    }
}