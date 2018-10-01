namespace TeduShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameapplicationclaims : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.IdentityUserClaims", newName: "ApplicationUserClaims");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ApplicationUserClaims", newName: "IdentityUserClaims");
        }
    }
}
