﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Utility;

namespace Restaurant.Pages.CategoryTypes
{
    [Authorize(Policy = SD.AdminEndUser)]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public CategoryType CategoryType { get; set; }


        public async Task<IActionResult> OnGet(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            CategoryType = await _db.CategoryType.SingleOrDefaultAsync(c => c.Id == id);

            if (CategoryType == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CategoryType = await _db.CategoryType.FindAsync(id);

            if (CategoryType != null)
            {
                _db.CategoryType.Remove(CategoryType);
                await _db.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }


    }
}