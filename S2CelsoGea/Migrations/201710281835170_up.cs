namespace S2CelsoGea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Amigo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 20),
                        Email = c.String(maxLength: 20),
                        Telefone = c.String(maxLength: 20),
                        Password = c.String(maxLength: 20),
                        ConfirmPassword = c.String(maxLength: 20),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Jogo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        WithUser_Id = c.Int(nullable: false),
                        Amigo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Amigo", t => t.WithUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Amigo", t => t.Amigo_Id)
                .Index(t => t.WithUser_Id)
                .Index(t => t.Amigo_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jogo", "Amigo_Id", "dbo.Amigo");
            DropForeignKey("dbo.Jogo", "WithUser_Id", "dbo.Amigo");
            DropIndex("dbo.Jogo", new[] { "Amigo_Id" });
            DropIndex("dbo.Jogo", new[] { "WithUser_Id" });
            DropTable("dbo.Jogo");
            DropTable("dbo.Amigo");
        }
    }
}
