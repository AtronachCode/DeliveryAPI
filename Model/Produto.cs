using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DeliveryAPI.Model;

public class Produto
{
    [Key]
    public int ProdutoId { get; set; }

    [Required]
    [StringLength(80)]
    public string? Nome { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")] //Este atributo significa que o campo preço pode te 10 casas e 2 casas após a virgula
    public decimal Preco { get; set; }

    [Required]
    [StringLength(300)]
    public string? ImagemURL{ get; set; }

    [Required]
    [StringLength(300)]
    public string? Descricao { get; set; }
    public int Estoque { get; set; }
    public DateTime DataCadastro { get; set; }
    public int CategoriaId { get; set; }

    [JsonIgnore]
    public Categoria? Categoria { get; set; }


}
