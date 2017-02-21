namespace AulaMVC.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AulaMVC.Models.Contexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AulaMVC.Models.Contexto context)
        {
            context.Tipos.AddOrUpdate(
              p => p.Nome,
              new TipoModel { Nome = "Refrigerante" },
              new TipoModel { Nome = "Cerveja" },
              new TipoModel { Nome = "Caf�" },
              new TipoModel { Nome = "Suco" },
              new TipoModel { Nome = "Por��o" }
            );

        }
    }
}
