using API.Models;
using Microsoft.AspNetCore.Mvc;

Console.Clear();

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//getter e setter em C#
// Produto produto = new Produto();
// produto.Nome = "Bolacha";
// Console.WriteLine(produto.Nome);



//criando array list e instanciando objeto
List<Produto> produtos = new List<Produto>();


// Funcionalidades da aplicaçao --> EndPoints

//GET: http://localhost:5088
app.MapGet("/", () => "API de produtos");
//GET: http://localhost:5088/produto
app.MapGet("/produto", () => "Produtos");
//GET: http://localhost:5088/produto/listar
app.MapGet("/produto/listar", () => produtos);

//GET: http://localhost:5088/produto/buscar/nomedoproduto
app.MapGet("/produto/buscar/{nome}", (/* Pegar Informaçao da Rota-- URL---> */[FromRoute] string nome) =>
    {
        for (int i = 0; i < produtos.Count; i++)
        {
            if (produtos[i].Nome == nome)
            {
                //retornar o produto encontrado
                return Results.Ok(produtos[i]);
            }
        }
        return Results.NotFound();
    }
);

// !EXERCICIO! <---- CADASTRAR PRODUTOS DENTRO DA LISTA ---> !EXERCICIO!


/*
EXERCICIOS
1)CADASTRAR UM PRODUTO
*/

//--PELA URL
app.MapPost("/produto/cadastrar/{nome}/{descricao}/{valor}",
 ([FromRoute] string nome, [FromRoute] string descricao, [FromRoute] double valor) =>
 {
     //Prencher o objeto pelo construtor
     Produto produto = new Produto(nome, descricao, valor);

     /*Preencher o objeto pelos atributos
      * produto.Nome = nome;
      * produto.Descricao = descricao;
      * produto.Valor = valor;
      */

     //Adicionar o Objeto dentro da lista
     produtos.Add(produto);
     return Results.Created("", produto);
 });

// Endpoint para cadastrar um novo produto

/*--PELO CORPO -- */
app.MapPost("/produto/cadastrar/", ([FromBody] Produto novoProduto) =>
{
    produtos.Add(novoProduto);
    return Results.Created($"/produto/buscar/{novoProduto.Nome}", novoProduto);
});
/*--REMOÇAO DO PRODUTO--*/

app.MapDelete("/produto/deletar/", ([FromRoute] string nome) =>
{
    // Encontrar o índice do produto na lista pelo nome
    int index = produtos.FindIndex(p => p.Nome == nome);

    if (index != -1)
    {
        produtos.RemoveAt(index);
        return Results.Ok();
    }
    else
    {
        return Results.NotFound(); 
    }
}
);

/*--ALTERAÇAO DO PRODUTO--*/

app.MapPut("/produto/alterar/{nome}", ([FromBody] Produto produtoAlterado,
 [FromRoute] string nome) =>
{

    // Procurar o produto pelo nome na lista
    var prodAux = produtos.FirstOrDefault(p => p.Nome == nome);

    if (prodAux != null)
    {
        // Atualizar os atributos do produto existente com os atributos do produto alterado
        prodAux.Nome = produtoAlterado.Nome;
        prodAux.Descricao = produtoAlterado.Descricao;
        prodAux.Valor = produtoAlterado.Valor;

        // Retorna o produto alterado
        return Results.Ok(prodAux);
    }
    else
    {
        return Results.NotFound();
    }
});

app.Run();
