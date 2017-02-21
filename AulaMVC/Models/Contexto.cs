using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AulaMVC.Models
{
    public class Contexto : DbContext
    {
        public Contexto() :base("name=Contexto")
        {

        }

        public DbSet<FabricanteModel> Fabricantes { get; set; }

        public DbSet<PessoasMesaModel> Pessoas { get; set; }

        public DbSet<ProdutoModel> Produtos { get; set; }

        public DbSet<ProdutoRodadaModel> ProdutosRodada { get; set; }

        public DbSet<RodadaModel> Rodadas { get; set; }

        public DbSet<TipoModel> Tipos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

    }
}