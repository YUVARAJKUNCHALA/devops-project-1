using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevopsProject_1.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string  Language { get; set; }
        public double? rating { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        public string Imageurl { get; set; }
    }
}
