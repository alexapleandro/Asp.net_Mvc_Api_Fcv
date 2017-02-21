namespace AulaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FabricanteModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PessoasMesaModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 30),
                        Calote = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProdutoModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 30),
                        Volume = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TeorAlc = c.Decimal(precision: 18, scale: 2),
                        TipoModelId = c.Int(nullable: false),
                        FabricanteModelId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FabricanteModel", t => t.FabricanteModelId)
                .ForeignKey("dbo.TipoModel", t => t.TipoModelId, cascadeDelete: true)
                .Index(t => t.TipoModelId)
                .Index(t => t.FabricanteModelId);
            
            CreateTable(
                "dbo.TipoModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProdutoRodadaModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PessoasMesaId = c.Int(nullable: false),
                        ProdutoModelId = c.Int(nullable: false),
                        RodadaModelId = c.Int(nullable: false),
                        Pessoas_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PessoasMesaModel", t => t.Pessoas_Id)
                .ForeignKey("dbo.ProdutoModel", t => t.ProdutoModelId, cascadeDelete: true)
                .ForeignKey("dbo.RodadaModel", t => t.RodadaModelId, cascadeDelete: true)
                .Index(t => t.ProdutoModelId)
                .Index(t => t.RodadaModelId)
                .Index(t => t.Pessoas_Id);
            
            CreateTable(
                "dbo.RodadaModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Local = c.String(nullable: false, maxLength: 30),
                        Data = c.DateTime(nullable: false),
                        Observacao = c.String(maxLength: 30),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProdutoRodadaModel", "RodadaModelId", "dbo.RodadaModel");
            DropForeignKey("dbo.ProdutoRodadaModel", "ProdutoModelId", "dbo.ProdutoModel");
            DropForeignKey("dbo.ProdutoRodadaModel", "Pessoas_Id", "dbo.PessoasMesaModel");
            DropForeignKey("dbo.ProdutoModel", "TipoModelId", "dbo.TipoModel");
            DropForeignKey("dbo.ProdutoModel", "FabricanteModelId", "dbo.FabricanteModel");
            DropIndex("dbo.ProdutoRodadaModel", new[] { "Pessoas_Id" });
            DropIndex("dbo.ProdutoRodadaModel", new[] { "RodadaModelId" });
            DropIndex("dbo.ProdutoRodadaModel", new[] { "ProdutoModelId" });
            DropIndex("dbo.ProdutoModel", new[] { "FabricanteModelId" });
            DropIndex("dbo.ProdutoModel", new[] { "TipoModelId" });
            DropTable("dbo.RodadaModel");
            DropTable("dbo.ProdutoRodadaModel");
            DropTable("dbo.TipoModel");
            DropTable("dbo.ProdutoModel");
            DropTable("dbo.PessoasMesaModel");
            DropTable("dbo.FabricanteModel");
        }
    }
}
