using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Produto
{

    //CONSTRUTOR
    public Produto()
    {
        Id = Guid.NewGuid().ToString();
        CriadoEm = DateTime.Now;
    }
    //Parametrizado ---> nao precisa de this.
    public Produto(string nome, string descricao, double valor)
    {
        Id = Guid.NewGuid().ToString();
        Nome = nome;
        Descricao = descricao;
        Valor = valor;
        CriadoEm = DateTime.Now;
    }


    //Atributos(java) ou propriedades(c#) = Caracteristicas de um Objeto


    //getter e setter em C#

    //ANOTAÇÃO - DATA ANOTATIONS -- IMPORTANTE
    [Required(ErrorMessage = "Este campo é obrigatorio!")]
    public string? Nome { get; set; }

    //escrever prop para gerar o modelo dos getters e setters e autocompletar no tab

    [MinLength(3, ErrorMessage = "Este campo tem o tamanho minimo de 3 caracteres.")]
    [MaxLength(10, ErrorMessage = "Este campo tem o tamanho maximo 10 caracteres.")]
    public string? Descricao { get; set; }

    [Range(1, 10000, ErrorMessage = "Valor minimo de 1 e Valor maximo 10000")]
    public double Valor { get; set; }

    public string? Id { get; set; }

    public DateTime CriadoEm { get; set; }

    public int Quantidade { get; set; }

}