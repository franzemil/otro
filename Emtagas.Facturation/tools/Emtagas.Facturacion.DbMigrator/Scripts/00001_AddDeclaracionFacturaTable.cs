using FluentMigrator;

namespace Emtagas.Facturacion.DbMigrator.Scripts
{
    [Migration(00001)]
    public class AddDeclaracionFacturaTable : Migration {
        public override void Up()
        {
            Create.Table("FaDeclaracionFactura")
                .WithColumn("Id").AsGuid().PrimaryKey().WithDefault(SystemMethods.NewGuid)
                .WithColumn("FacturaId").AsInt32()
                .WithColumn("FechaDeclaracion").AsInt32();
        }

        public override void Down()
        {
            Delete.Table("FaDeclaracionFactura");
        }
    }
}