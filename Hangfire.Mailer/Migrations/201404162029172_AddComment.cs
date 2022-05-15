namespace Hangfire.Mailer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddComment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Text = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);


            CreateTable(
               "dbo.Patient",
               c => new
               {
                   PatientId = c.Int(nullable: false, identity: true),
                   PFirstName = c.String(nullable: false),
                   PLastName = c.String(nullable: false),
                   PPhone = c.String(nullable: false),
                   AnotherPhone = c.String(nullable: true),
                   Email = c.String(nullable: true),
                   BirthDay = c.DateTime(nullable: true),
                   IDNumber = c.String(nullable: true),
                   FFirstName = c.String(nullable: true),
                   FLastName = c.String(nullable: true),
                   FPhone = c.String(nullable: true),
                   RegistDate = c.DateTime(nullable: false),
                   HMO = c.String(nullable: false),

               })
                .PrimaryKey(t => t.PatientId);

            CreateTable(
               "dbo.Medical",
               c => new
               {
                   MedicalId = c.Int(nullable: false, identity: true),
                   PatientId = c.Int(nullable: false),
                   MedicalName = c.String(nullable: false),
                   CreateDate = c.DateTime(nullable: false),
                   UpdateDate = c.DateTime(nullable: false),
                   Status = c.Boolean(nullable: false),
                   CronExpress = c.String(nullable: false)
               })
               .PrimaryKey(t => t.MedicalId);
             
            

          /*  CreateTable(
               "dbo.Login",
               c => new
               {
                   
                   LoginIdPhone = c.String(nullable: false),
                   Password = c.Int(nullable: false),
                   PFirstName = c.String(nullable: true),
                   PLastName = c.String(nullable: true),
                   Email = c.String(nullable: false),
                   CreateDate = c.DateTime(nullable: false),
                   
                   
               })
               .PrimaryKey(t => t.LoginIdPhone);*/
        }
        
        public override void Down()
        {
            DropTable("dbo.Comments");
            DropTable("dbo.Patient");
            DropTable("dbo.Medical");
        }
    }
}
