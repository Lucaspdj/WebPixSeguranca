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
            optionsBuilder.UseSqlServer(@"Data Source=35.198.27.36;Initial Catalog=WpSeguranca;Persist Security Info=True;User ID=Dev;Password=WebPix@123;");
        }
    }
}
