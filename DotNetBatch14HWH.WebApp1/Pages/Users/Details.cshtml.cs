using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DotNetBatch14HWH.WebApp1.Data;
using DotNetBatch14HWH.WebApp1.Model;

namespace DotNetBatch14HWH.WebApp1.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly DotNetBatch14HWH.WebApp1.Data.DotNetBatch14HWHWebApp1Context _context;

        public DetailsModel(DotNetBatch14HWH.WebApp1.Data.DotNetBatch14HWHWebApp1Context context)
        {
            _context = context;
        }

      public User User { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User.FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            else 
            {
                User = user;
            }
            return Page();
        }
    }
}
