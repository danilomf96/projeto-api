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
List<Produto> produtos =
[
    new Produto("Celular", "IOS", 4000),
    new Produto("Celular", "Android", 2000),
    new Produto("TV", "LG", 2500),
    new Produto("Placa de video", "NVIDIA", 2800),
];


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
//app.MapPost("/produto/cadastrar", () => "Cadastro de produtos");


/*
EXERCICIOS
1)CADASTRAR UM PRODUTO
*/

//--PELA URL

// Endpoint para cadastrar um novo produto
app.MapPost("/produto/cadastrar", ([FromBody] Produto novoProduto) =>
{
    produtos.Add(novoProduto);
    return Results.Created($"/produto/buscar/{novoProduto.Nome}", novoProduto);
});

/*
--PELO CORPO
--REMOÇAO DO PRODUTO
--ALTERAÇAO DO PRODUTO
*/

app.Run();
