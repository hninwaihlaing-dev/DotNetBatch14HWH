using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DotNetBatch14HWH.WebApp1.Data;
using DotNetBatch14HWH.WebApp1.Model;

namespace DotNetBatch14HWH.WebApp1.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly DotNetBatch14HWH.WebApp1.Data.DotNetBatch14HWHWebApp1Context _context;

        public CreateModel(DotNetBatch14HWH.WebApp1.Data.DotNetBatch14HWHWebApp1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.User == null || User == null)
            {
                return Page();
            }

            _context.User.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
