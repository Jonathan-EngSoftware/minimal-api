using Microsoft.EntityFrameworkCore;
using Minimalapi.Dominio.DTOs;
using Minimalapi.DomibniInfraestrutura.Db;


builder.Services.AddDbContext<DbContexto>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 29))));
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



