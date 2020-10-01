using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;

namespace BethanysPieShop.Models
{
    public class PiesListViewModel
    {
        public IEnumerable<Models.Pie> Pies { get; set; }
        public string CurrentCategory { get; set; }
    }
}
