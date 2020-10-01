using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BethanysPieShop.Models
{

    public class PieController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

    }

    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
    }
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies { get; }
        IEnumerable<Pie> PieOfTheWeek { get; }
        Pie GetPieById(int pieId);
    }

    public class Pie
    {
        public int PieId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool IsPieOfTheWeek { get; set; }
        public bool IsInStock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<Pie> Pies { get; set; }
    }
}
