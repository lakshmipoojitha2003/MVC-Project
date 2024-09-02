using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Data
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public int Count { get; set; }
    }
}
