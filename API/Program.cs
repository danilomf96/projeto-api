using API.Models;

Console.Clear();

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//getter e setter em C#
// Produto produto = new Produto();
// produto.Nome = "Bolacha";
// Console.WriteLine(produto.Nome);





//criando array list e instanciando objeto
List<Produto> produtos = new List<Produto>();
produtos.Add(new Produto("Celular", "IOS", 4000));
produtos.Add(new Produto("Celular", "Android", 2000));
produtos.Add(new Produto("TV", "LG", 2500));
produtos.Add(new Produto("Placa de video", "NVIDIA", 2800));


// Funcionalidades da aplicaçao --> EndPoints

//GET: http://localhost:5088
app.MapGet("/", () => "API de produtos");
//GET: http://localhost:5088/produto
app.MapGet("/produto", () => "Produtos");
//GET: http://localhost:5088/produto/listar
app.MapGet("/produto/listar", () => produtos);

// !EXERCICIO! <---- CADASTRAR PRODUTOS DENTRO DA LISTA ---> !EXERCICIO!
app.MapPost("/produto/cadastrar", () => "Cadastro de produtos");

app.Run();
