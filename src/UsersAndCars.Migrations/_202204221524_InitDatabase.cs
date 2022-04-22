using FluentMigrator;

namespace UsersAndCars.Migrations
{
    [Migration(202204221524)]
    public class _202204221524_InitDatabase : Migration
    {
        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("Id").AsInt32().PrimaryKey().NotNullable().Identity()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("Family").AsString(50).NotNullable()
                .WithColumn("NationalCode").AsString(10).NotNullable()
                .WithColumn("PlaqueId").AsInt32().Nullable();


            Create.Table("Cars")
                .WithColumn("Id").AsInt32().PrimaryKey().NotNullable().Identity()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("Model").AsString(50).NotNullable()
                .WithColumn("Color").AsString(50).NotNullable()
                .WithColumn("EngNumber").AsString(50).NotNullable()
                .WithColumn("ChassisNumber").AsString(50).NotNullable();



            Create.Table("Plaques")
                .WithColumn("Id").AsInt32().PrimaryKey().NotNullable().Identity()
                .WithColumn("LeftNum").AsInt32().NotNullable()
                .WithColumn("Letter").AsString(1).NotNullable()
                .WithColumn("RightNum").AsInt32().NotNullable()
                .WithColumn("CityNum").AsInt32().NotNullable()
                .WithColumn("UserId").AsInt32().Nullable()
                .WithColumn("CarId").AsInt32().Nullable();


            Create.ForeignKey("FK_Plaques_Users")
                .FromTable("Plaques").ForeignColumn("UserId")
                .ToTable("Users").PrimaryColumn("Id");

            Create.ForeignKey("FK_Plaques_Cars")
                .FromTable("Plaques").ForeignColumn("CarId")
                .ToTable("Cars").PrimaryColumn("Id");
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_Plaques_Users").OnTable("Plaques");
            Delete.ForeignKey("FK_Plaques_Cars").OnTable("Plaques");

            Delete.Table("Plaques");
            Delete.Table("Cars");
            Delete.Table("Users");

        }
    }
}
