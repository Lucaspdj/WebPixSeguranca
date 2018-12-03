using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class WebPixContext : DbContext
    {
        public DbSet<Permissao> Permissao { get; set; }
        public DbSet<Token> Token { get; set; }
        public DbSet<UsuarioPermissao> UsuarioPermissao { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<UsuarioXPerfil> UsuarioXPerfil { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer(@"Server=DESKTOP-9B04LJT\SQLEXPRESS;Database=WebPixPrincipal;Trusted_Connection=True;Integrated Security = True;");
            optionsBuilder.UseSqlServer(@"Data Source=34.226.175.244;Initial Catalog=WebPixSeguranca;Persist Security Info=True;User ID=sa;Password=StaffPro@123;");

        }
    }
}
