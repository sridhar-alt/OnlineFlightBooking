namespace OnlineFlightbooking.DiL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.User_Insert",
                p => new
                    {
                        Mobile = p.String(maxLength: 128),
                        Name = p.String(),
                        Dob = p.DateTime(),
                        Mail = p.String(),
                        Sex = p.Int(),
                        UserAddress = p.String(),
                        Password = p.String(),
                        Role = p.String(),
                    },
                body:
                    @"INSERT [dbo].[Users]([Mobile], [Name], [Dob], [Mail], [Sex], [UserAddress], [Password], [Role])
                      VALUES (@Mobile, @Name, @Dob, @Mail, @Sex, @UserAddress, @Password, @Role)"
            );
            
            CreateStoredProcedure(
                "dbo.User_Update",
                p => new
                    {
                        Mobile = p.String(maxLength: 128),
                        Name = p.String(),
                        Dob = p.DateTime(),
                        Mail = p.String(),
                        Sex = p.Int(),
                        UserAddress = p.String(),
                        Password = p.String(),
                        Role = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[Users]
                      SET [Name] = @Name, [Dob] = @Dob, [Mail] = @Mail, [Sex] = @Sex, [UserAddress] = @UserAddress, [Password] = @Password, [Role] = @Role
                      WHERE ([Mobile] = @Mobile)"
            );
            
            CreateStoredProcedure(
                "dbo.User_Delete",
                p => new
                    {
                        Mobile = p.String(maxLength: 128),
                    },
                body:
                    @"DELETE [dbo].[Users]
                      WHERE ([Mobile] = @Mobile)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.User_Delete");
            DropStoredProcedure("dbo.User_Update");
            DropStoredProcedure("dbo.User_Insert");
        }
    }
}
