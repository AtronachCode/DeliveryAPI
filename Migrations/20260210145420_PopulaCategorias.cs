using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class PopulaCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //No método Up posso incluir os dados usando instruções SQL eu passo o local onde vou inserir e os valores que serão inseridos
            migrationBuilder.Sql("Insert into Categorias(Nome, ImagemUrl) Values('Bebidas','bebidas.jpg')");
            migrationBuilder.Sql("Insert into Categorias(Nome, ImagemUrl) Values('Lanches','lanches.jpg')");
            migrationBuilder.Sql("Insert into Categorias(Nome, ImagemUrl) Values('Sobremesas','sobremesa.jpg')");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //No método Down estou configurando para remover caso eu precise
            migrationBuilder.Sql("Delete from Categorias");
        }
    }
}
