using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace DeliveryAPI.Model;

public class Categoria
{
    [Key] // Este atributo significa que CategoriaId será a chave primária no DB
    public int CategoriaId { get; set; }

    [Required] // Este atributo significa que este campo nome não pode ficar vazio
    [StringLength(80)] //Este atributo significa que o campo nome suporta até 80 bytes
    public string? Nome { get; set; }
    
    [Required]
    [StringLength(300)]
    public string? ImagemUrl { get; set; }

    // Aqui estou informando que uma categoria pode ter varios produtos
    public ICollection<Produto>? Produtos { get; set; }

    public Categoria()
    {
        Produtos = new Collection<Produto>();
    }

}
