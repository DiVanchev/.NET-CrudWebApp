using System.ComponentModel.DataAnnotations;

namespace Crud_Web_App.Models
{
    public class Items
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Името е задължително.")]
        [StringLength(100, ErrorMessage = "Името трябва да е между 3 и 100 символа.", MinimumLength = 3)]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Описанието е задължително.")]
        [StringLength(1000, ErrorMessage = "Описанието трябва да е между 10 и 1000 символа.", MinimumLength = 10)]
        public required string Description { get; set; }

        [Required(ErrorMessage = "Цената е задължителна.")]
        [Range(0.01, 10000, ErrorMessage = "Цената трябва да е между 0.01 и 10000.")]
        public required decimal Price { get; set; }

        [Required(ErrorMessage = "Пътят към изображението е задължителен.")]
        [Url(ErrorMessage = "Пътят към изображението трябва да бъде валиден URL.")]
        public required string ImagePath { get; set; }
    }
}
