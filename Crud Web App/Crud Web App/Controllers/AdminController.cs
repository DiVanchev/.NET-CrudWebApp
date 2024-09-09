using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Crud_Web_App.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Crud_Web_App.Data;

namespace Crud_Web_App.Controllers
{
    [Authorize(Roles = "Admin")] //Този контролер може да бъде достъпен само от потребители, които имат ролята "Admin".
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        // Конструкторът на контролера, който инжектира зависимостите за управление на потребители, роли и контекста на базата данни.
        public AdminController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        // Метод за показване на главната страница на админския панел.
        public IActionResult Index()
        {
            return View();
        }

        // Метод за управление на потребители. Той извлича всички потребители от базата данни и ги подава към изгледа.
        public async Task<IActionResult> ManageUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }

        // Метод за редактиране на потребител. Той извлича потребителя по неговото ID и го подава към изгледа.
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST метод за редактиране на потребител. Актуализира информацията за потребителя в базата данни.
        [HttpPost]
        public async Task<IActionResult> EditUser(IdentityUser user)
        {
            var existingUser = await _userManager.FindByIdAsync(user.Id);
            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.UserName = user.UserName;
            existingUser.Email = user.Email;

            await _userManager.UpdateAsync(existingUser); 
            return RedirectToAction(nameof(ManageUsers));
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userManager.DeleteAsync(user);
            return RedirectToAction(nameof(ManageUsers));
        }

        // Метод за управление на съдържание, в случая списък с обяви (Listings).
        public async Task<IActionResult> ManageListings()
        {
            var listings = await _context.Items.ToListAsync();
            return View(listings);
        }

        // Метод за управление на роли. Извлича всички роли.
        public async Task<IActionResult> ManageRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }

        // POST метод за създаване на нова роля.
        [HttpPost]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (!string.IsNullOrEmpty(roleName))
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName)); 
            }
            return RedirectToAction(nameof(ManageRoles));
        }

        // Метод за изтриване на роля. Извлича роля по нейното ID и я изтрива от базата данни.
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role != null)
            {
                await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction(nameof(ManageRoles));
        }

        // Метод за управление на системни настройки. Извлича текущите настройки и ги подава към изгледа.
        public async Task<IActionResult> SystemSettings()
        {
            var systemSettings = await _context.SystemSettings.FirstOrDefaultAsync();

            if (systemSettings == null)
            {
                systemSettings = new SystemSettings
                {
                    SiteTitle = "Default Title",
                    SiteDescription = "Default Description",
                    ContactEmail = "default@example.com",
                    AllowUserRegistration = true,
                    MaxUploadFileSize = 2048
                };
            }

            return View(systemSettings);
        }

        // POST метод за запазване на системни настройки. Актуализира или добавя нови настройки в базата данни.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SystemSettings(SystemSettings systemSettings)
        {
            if (ModelState.IsValid)
            {
                var existingSettings = await _context.SystemSettings.FirstOrDefaultAsync();

                if (existingSettings != null)
                {
                    existingSettings.SiteTitle = systemSettings.SiteTitle;
                    existingSettings.SiteDescription = systemSettings.SiteDescription;
                    existingSettings.ContactEmail = systemSettings.ContactEmail;
                    existingSettings.AllowUserRegistration = systemSettings.AllowUserRegistration;
                    existingSettings.MaxUploadFileSize = systemSettings.MaxUploadFileSize;

                    _context.Update(existingSettings);
                }
                else
                {
                    _context.Add(systemSettings);
                }

                await _context.SaveChangesAsync();

                ViewBag.Message = "Settings have been saved successfully!";
            }

            return View(systemSettings);
        }
    }
}
