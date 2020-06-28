using Microsoft.EntityFrameworkCore;
using MvcCore.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcCore.Data.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options){}

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                    .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                     property.Relational().ColumnType = "varchar(100)";

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDbContext).Assembly);

            //Impede que um item ao ser deletado, os outros objetos relacionados a ele, sejam deletados em cascata
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                //DeleteBehavior => Comportamento após a exclusão
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
