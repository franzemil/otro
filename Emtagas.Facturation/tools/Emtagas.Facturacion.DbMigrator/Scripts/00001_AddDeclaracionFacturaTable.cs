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
                .WithColumn("CUFD").AsString(150)
                .WithColumn("CUF").AsString(150)
                .WithColumn("File").AsBinary()
                .WithColumn("Hash").AsString()
                .WithColumn("Detalle").AsString()
                .WithColumn("Enviada").AsBoolean().WithDefaultValue(false)
                .WithColumn("FechaDeclaracion").AsInt32();
        }

        public override void Down()
        {
            Delete.Table("FaDeclaracionFactura");
        }
    }
}