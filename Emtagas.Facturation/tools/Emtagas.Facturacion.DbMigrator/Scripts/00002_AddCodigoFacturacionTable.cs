using FluentMigrator;

namespace Emtagas.Facturacion.DbMigrator.Scripts
{
    [Migration((00002))]
    public class AddCodigoFacturacionTable : Migration
    {
        public override void Up()
        {
            Create.Table("FaCodigoFacturacion")
                .WithColumn("Id").AsGuid().PrimaryKey().WithDefault(SystemMethods.NewGuid)
                .WithColumn("Codigo").AsString(100)
                .WithColumn("TipoCodigo").AsString()
                .WithColumn("Fecha").AsDate();
        }

        public override void Down()
        {
            Delete.Table("FaCodigoFacturacion");
        }
    }
}