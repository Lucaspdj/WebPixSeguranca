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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer(@"Server=DESKTOP-9B04LJT\SQLEXPRESS;Database=WebPixPrincipal;Trusted_Connection=True;Integrated Security = True;");
            optionsBuilder.UseSqlServer(
                @"Server = 187.84.229.35; Database = WebPixSeguranca; User Id = dev;Password = Lucas-2007");

        }
    }
}
