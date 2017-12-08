namespace _603211_PROKHORENKO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Nick : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "NickName", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "NickName");
        }
    }
    //public partial class Nick : DbMigration
    //{
    //    public override void Up()
    //    {
    //        AddColumn("dbo.AspNetUsers", "NickName", c => c.String());
    //        DropTable("dbo.Dishes");
    //    }

    //    public override void Down()
    //    {
    //        CreateTable(
    //            "dbo.Dishes",
    //            c => new
    //                {
    //                    DishId = c.Int(nullable: false, identity: true),
    //                    DishName = c.String(nullable: false),
    //                    Description = c.String(nullable: false),
    //                    Calories = c.Int(nullable: false),
    //                    GroupName = c.String(nullable: false),
    //                    Image = c.Binary(),
    //                    MimeType = c.String(),
    //                })
    //            .PrimaryKey(t => t.DishId);

    //        DropColumn("dbo.AspNetUsers", "NickName");
    //    }
    //}
}
