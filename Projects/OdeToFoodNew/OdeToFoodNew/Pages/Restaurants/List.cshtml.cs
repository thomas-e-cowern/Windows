using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OdeToFoodNew.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        public string Message { get; set; } 
        public void OnGet()
        {
            Message = "Hello World"; 
        }
    }
}
