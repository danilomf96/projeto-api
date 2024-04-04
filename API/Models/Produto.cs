namespace API.Models;

public class Produto
{

    //CONSTRUTOR
    public Produto()
    {
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
    public string? Nome { get; set; }

    //escrever prop para gerar o modelo dos getters e setters e autocompletar no tab
    public string? Descricao { get; set; }

    public double Valor { get; set; }

    public string? Id { get; set; }

    public DateTime CriadoEm { get; set; }

}