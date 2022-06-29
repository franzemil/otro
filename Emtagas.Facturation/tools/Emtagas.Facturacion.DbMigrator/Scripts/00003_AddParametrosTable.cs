using FluentMigrator;

namespace Emtagas.Facturacion.DbMigrator.Scripts
{
    [Migration(00003)]
    public class AddParametrosTable : Migration {
        public override void Up()
        {
            Create.Table("FaParametroFacturacion")
                .WithColumn("Id").AsGuid().PrimaryKey().WithDefault(SystemMethods.NewGuid)
                .WithColumn("Codigo").AsInt32()
                .WithColumn("Description").AsInt32()
                .WithColumn("TipoParametro").AsString().Unique();
        }

        public override void Down()
        {
            Delete.Table("FaParametroFacturacion");
        }
    }
}