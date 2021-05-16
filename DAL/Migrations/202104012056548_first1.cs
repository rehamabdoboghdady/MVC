namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Orders", name: "OrderUser_Id", newName: "userId");
            RenameIndex(table: "dbo.Orders", name: "IX_OrderUser_Id", newName: "IX_userId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Orders", name: "IX_userId", newName: "IX_OrderUser_Id");
            RenameColumn(table: "dbo.Orders", name: "userId", newName: "OrderUser_Id");
        }
    }
}
