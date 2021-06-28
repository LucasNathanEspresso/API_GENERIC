using Crm.Comercial.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Crm.Comercial.Repository
{
    public class ApplicationDbContext : DbContext
    {
        //CRIAR TABELA DE USUÁRIO
        public DbSet<Login> Login { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<VinculoMenu> VinculoMenu { get; set; }
        public DbSet<Validacao> Validacao { get; set; }
        public DbSet<Usuario> Usuario { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
            
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = String.Empty;
            IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .AddJsonFile("appsettings.Development.json", optional: true)
           .Build();

            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], b => b.MigrationsAssembly("Crm.Comercial.Api"));
       
        }
    }

}
