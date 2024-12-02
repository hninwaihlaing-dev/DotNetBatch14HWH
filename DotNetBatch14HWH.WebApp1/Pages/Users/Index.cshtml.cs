﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly DotNetBatch14HWH.WebApp1.Data.DotNetBatch14HWHWebApp1Context _context;

        public IndexModel(DotNetBatch14HWH.WebApp1.Data.DotNetBatch14HWHWebApp1Context context)
        {
            _context = context;
        }

        public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.User != null)
            {
                User = await _context.User.ToListAsync();
            }
        }
    }
}
