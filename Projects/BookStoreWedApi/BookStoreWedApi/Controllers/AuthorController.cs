using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreWedApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookStoreWedApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public AuthorController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Author> Get()
        {
            using (var context = new BookStoresDBContext())
            {
                // Get All
                // return context.Author.ToList();

                // Add an author
                /*Author author = new Author();

                author.FirstName = "John";
                author.LastName = "Smith";
                author.Phone = "123-456-7890";
                author.State = "FL";
                author.Zip = "12345";

                context.Author.Add(author);

                context.SaveChanges();*/

                Author author = context.Author.Where(auth => auth.AuthorId == 25).FirstOrDefault();

                /*               author.Phone = "111-111-1111";

                               context.Author.Update(author);

                               context.SaveChanges();*/
                // Get bi Id
                // return context.Author.Where(auth => auth.AuthorId == 4).ToList();

                context.Author.Remove(author);
                context.SaveChanges();

                return context.Author.ToList();
            }
        }
    }
}
