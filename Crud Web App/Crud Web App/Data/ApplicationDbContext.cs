using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Crud_Web_App.Models;
using System.Security.Cryptography.X509Certificates;

namespace Crud_Web_App.Data
{
    // Класът ApplicationDbContext наследява IdentityDbContext, за да предостави функционалности за управление на идентичността (потребители, роли и т.н.) и достъп до базата данни.
    public class ApplicationDbContext : IdentityDbContext
    {
        // Конструкторът приема опции (options) за конфигурация на контекста на базата данни и ги предава на базовия клас.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet представлява колекция от обекти, които ще бъдат съхранени в базата данни и достъпни като таблици. Тук се дефинират трите основни модела:

        // Тази таблица ще съхранява данни за Listings (списъци на обяви).
        public DbSet<Listings> Listings { get; set; }

        // Тази таблица ще съхранява данни за Items (елементи, които се продават или обменят).
        public DbSet<Items> Items { get; set; }

        // Тази таблица ще съхранява системни настройки (SystemSettings) на приложението.
        public DbSet<SystemSettings> SystemSettings { get; set; }
    }
}
