var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Ola Pessoal");

app.MapPost("/Login", (LoginDTO loginDTO) =>
{
    // Implementar a lógica de login aqui
    if (loginDTO.Email == "admin@teste.com" && loginDTO.Senha == "senha")
    {
        return Results.Ok("Login bem-sucedido");
    } else
    {
        return Results.Unauthorized();
    }
});

app.Run();



