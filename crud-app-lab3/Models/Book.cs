using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace crud_app_lab3.Models
{
    public class Book
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage = "Musisz wpisać tytuł")]
        [MinLength(length: 3)]
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Author { get; set; }
        public bool IsAvailable { get; set; }
    }
}
