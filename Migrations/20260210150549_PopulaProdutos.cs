using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Produtos(Nome,Preco,ImagemUrl,Descricao,Estoque,DataCadastro,CategoriaId) " +
                                "Values('Coca Cola',10.50,'cocacola.jpg','Coca Cola 2L',500,now(),1)");

            migrationBuilder.Sql("Insert into Produtos(Nome,Preco,ImagemUrl,Descricao,Estoque,DataCadastro,CategoriaId) " +
                                "Values('X Bacon',23.75,'xbacon.jpg','Pão hamburguer presunto e mussarela',10,now(),2)");

            migrationBuilder.Sql("Insert into Produtos(Nome,Preco,ImagemUrl,Descricao,Estoque,DataCadastro,CategoriaId) " +
                                "Values('Pudim',5.50,'pudim.jpg','Pudim de leite com cobertura de amendoin',25,now(),3)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Produtos");
        }
    }
}
