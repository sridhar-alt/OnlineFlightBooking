namespace OnlineFlightbooking.DiL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        Flight_Id = c.Int(nullable: false, identity: true),
                        FlightName = c.String(),
                        FromLocation = c.String(),
                        ToLocation = c.String(),
                        ArrivalTime = c.DateTime(nullable: false),
                        Duration = c.DateTime(nullable: false),
                        TotalSeat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Flight_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Mobile = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Dob = c.DateTime(nullable: false),
                        Mail = c.String(),
                        Sex = c.Int(nullable: false),
                        UserAddress = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Mobile);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Flights");
        }
    }
}
