Console.Clear();

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


// Funcionalidades da aplicaçao --> EndPoints
app.MapGet("/", () => "Localhost");
app.MapGet("/produto", () => "Produtos");
app.MapGet("/produto/listar", () => "Listagem de produtos");
app.MapPost("/produto/cadastrar", () => "Cadastro de produtos");

app.Run();
