namespace OnlineFlightbooking.DiL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FlightTravelClasses",
                c => new
                    {
                        FlightTravelClass_Id = c.Int(nullable: false, identity: true),
                        Flight_Id = c.Int(nullable: false),
                        Class_Id = c.Int(nullable: false),
                        SeatCount = c.Int(nullable: false),
                        SeatCost = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FlightTravelClass_Id)
                .ForeignKey("dbo.Flights", t => t.Flight_Id, cascadeDelete: true)
                .ForeignKey("dbo.TravelClasses", t => t.Class_Id, cascadeDelete: true)
                .Index(t => t.Flight_Id)
                .Index(t => t.Class_Id);
            
            CreateTable(
                "dbo.TravelClasses",
                c => new
                    {
                        Class_Id = c.Int(nullable: false, identity: true),
                        ClassName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Class_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FlightTravelClasses", "Class_Id", "dbo.TravelClasses");
            DropForeignKey("dbo.FlightTravelClasses", "Flight_Id", "dbo.Flights");
            DropIndex("dbo.FlightTravelClasses", new[] { "Class_Id" });
            DropIndex("dbo.FlightTravelClasses", new[] { "Flight_Id" });
            DropTable("dbo.TravelClasses");
            DropTable("dbo.FlightTravelClasses");
        }
    }
}
