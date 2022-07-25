using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using searchRazor.Data;
using searchRazor.Models;

namespace searchRazor.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly searchRazor.Data.searchRazorContext _context;

        public IndexModel(searchRazor.Data.searchRazorContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; }

        public async Task OnGetAsync()
        {
            
            var cars = from m in _context.Cars
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                bool validationPrice = false;
                cars = cars.Where(s => s.Make.Contains(SearchString));
                Car = await cars.ToListAsync();

                foreach (var item in cars)
                {
                    if (item.Price > 5000)
                    {
                        validationPrice = true;
                    }
                }
                if (validationPrice)
                {
                    ViewData["Message"] = string.Format("We found cars older than 5000.00$", null, DateTime.Now.ToString());

                }

            }
            else
            {
                Car = await _context.Cars.ToListAsync();
            }
        }

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
    }
}
