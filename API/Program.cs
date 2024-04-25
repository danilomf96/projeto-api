using System.ComponentModel.DataAnnotations;
using API.Models;
using Microsoft.AspNetCore.Mvc;

Console.Clear();

var builder = WebApplication.CreateBuilder(args);

//Registrar o serviço de banco de dados
builder.Services.AddDbContext<AppDataContext>();

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

/*GET: http://localhost:5088/produto/listar
atualização para Banco de dados!*/
app.MapGet("/produto/listar", ([FromServices] AppDataContext context) =>
{
    if (context.Produtos.Any())
    {
        return Results.Ok(context.Produtos.ToList());
    }
    return Results.NotFound("Nao existem produtos na tabela");
});

//GET: http://localhost:5088/produto/buscar/iddoproduto
app.MapGet("/produto/buscar/{id}", ([FromRoute] string id, [FromServices] AppDataContext context) =>
    {
        Produto? produto = context.Produtos.Find(id);
        if (produto is null)
        {
            return Results.NotFound("Produto não encontrado");
        }
        return Results.Ok(produto);
    }
    //Ternario
    //return produto is null ? Results.NotFound("Produto não encontrado") : Results.Ok(produto);

);

// 1)CADASTRAR UM PRODUTO
// Endpoint para cadastrar um novo produto
//--PELO CORPO --//
//----POST
app.MapPost("/produto/cadastrar/", ([FromBody] Produto novoProduto, [FromServices] AppDataContext context) =>
{
    //pesquisar melhor -- fazer import do ValidationResult
    List<ValidationResult> erros = new List<ValidationResult>();
    if (!Validator.TryValidateObject(novoProduto, new ValidationContext(novoProduto), erros, true))
    {
        return Results.BadRequest(erros);
    }
    
    //IMPLEMENTANDO REGRAS DE NEGOCIO --> NAO DEIXA ADICIONAR ITENS COM O MESMO NOME.
    Produto? produtosEncontrados = context.Produtos.FirstOrDefault(x => x.Nome == novoProduto.Nome);
    if (produtosEncontrados is null)
    {
        //Adicionar o objeto dentro da tabela do banco de dados
        context.Produtos.Add(novoProduto);
        context.SaveChanges();
        return Results.Created($"/produto/buscar/{novoProduto.Nome}", novoProduto);
    }
    return Results.BadRequest("Já existe um produto com o mesmo nome.");


});
/*--REMOÇAO DO PRODUTO--*/

app.MapDelete("/produto/deletar/{id}", ([FromRoute] string id, [FromServices] AppDataContext context) =>
{

    Produto? produto = context.Produtos.FirstOrDefault(x => x.Id == id);
    if (produto is null)
    {
        return Results.NotFound("Produto não encontrado");
    }
    context.Produtos.Remove(produto);
    context.SaveChanges();
    return Results.Ok("Produto deletado");
}
);

/*--ALTERAÇAO DO PRODUTO--*/

app.MapPut("/produto/alterar/{id}", ([FromBody] Produto produtoAlterado,
 [FromRoute] string id, [FromServices] AppDataContext context) =>
{

    Produto? produto = context.Produtos.Find(id);
    if (produto is null)
    {
        return Results.NotFound("Produto não encontrado");
    }
    produto.Nome = produtoAlterado.Nome;
    produto.Descricao = produtoAlterado.Descricao;
    produto.Valor = produtoAlterado.Valor;
    context.Produtos.Update(produto);
    context.SaveChanges();

    return Results.Ok("Produto alterado!");
});

app.Run();
