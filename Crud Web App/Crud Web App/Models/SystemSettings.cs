using System.ComponentModel.DataAnnotations;

namespace Crud_Web_App.Models
{
    public class SystemSettings
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Заглавието на сайта е задължително.")]
        [StringLength(100, ErrorMessage = "Заглавието на сайта трябва да бъде между 5 и 100 символа.", MinimumLength = 5)]
        public string SiteTitle { get; set; } = string.Empty;

        [Required(ErrorMessage = "Описанието на сайта е задължително.")]
        [StringLength(500, ErrorMessage = "Описанието на сайта трябва да бъде между 10 и 500 символа.", MinimumLength = 10)]
        public string SiteDescription { get; set; } = string.Empty;

        [Required(ErrorMessage = "Имейлът за контакт е задължителен.")]
        [EmailAddress(ErrorMessage = "Невалиден имейл адрес.")]
        public string ContactEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Трябва да се уточни дали е позволена регистрация на потребители.")]
        public bool AllowUserRegistration { get; set; } = true;

        [Range(1, 10000, ErrorMessage = "Максималният размер на качвания файл трябва да бъде между 1 и 10000 KB.")]
        public int MaxUploadFileSize { get; set; } = 2048;
    }
}
