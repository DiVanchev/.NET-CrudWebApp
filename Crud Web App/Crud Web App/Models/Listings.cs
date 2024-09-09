using System.ComponentModel.DataAnnotations;

namespace Crud_Web_App.Models
{
    public class Listings
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Полето за име е задължително.")]
        [StringLength(100, ErrorMessage = "Името трябва да бъде между 2 и 100 символа.", MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Полето за описание е задължително.")]
        [StringLength(500, ErrorMessage = "Описанието трябва да бъде между 10 и 500 символа.", MinimumLength = 10)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Полето за цена е задължително.")]
        [Range(0.01, 10000.00, ErrorMessage = "Цената трябва да бъде между 0.01 и 10,000.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Полето за път към изображението е задължително.")]
        [StringLength(255, ErrorMessage = "Пътят към изображението не трябва да надвишава 255 символа.")]
        public string ImagePath { get; set; } = string.Empty;
    }
}
