using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Crud_Web_App.Models;
using System.Security.Cryptography.X509Certificates;

namespace Crud_Web_App.Data
{
    // ������ ApplicationDbContext ��������� IdentityDbContext, �� �� ���������� ��������������� �� ���������� �� ������������� (�����������, ���� � �.�.) � ������ �� ������ �����.
    public class ApplicationDbContext : IdentityDbContext
    {
        // ������������� ������ ����� (options) �� ������������ �� ��������� �� ������ ����� � �� ������� �� ������� ����.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet ������������ �������� �� ������, ����� �� ����� ��������� � ������ ����� � �������� ���� �������. ��� �� ��������� ����� ������� ������:

        // ���� ������� �� ��������� ����� �� Listings (������� �� �����).
        public DbSet<Listings> Listings { get; set; }

        // ���� ������� �� ��������� ����� �� Items (��������, ����� �� �������� ��� �������).
        public DbSet<Items> Items { get; set; }

        // ���� ������� �� ��������� �������� ��������� (SystemSettings) �� ������������.
        public DbSet<SystemSettings> SystemSettings { get; set; }
    }
}
