using Minimalapi.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Minimalapi.Infraestrutura.Db;

    public class DbContexto : DbContext
    {
        private readonly IConfiguration _configurationAppSettings;
        public DbContexto(IConfiguration configuracaoAppSettings)
        {
            _configurationAppSettings = configuracaoAppSettings;
        }

        public DbSet<Administrador> Administradores { get; set; } = default!;

        public DbContexto(IConfiguration configuracaoAppSettings)
        {
            _configurationAppSettings = configuracaoAppSettings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var stringConexao = _configurationAppSettings.GetConnectionString("mysql")?.ToString();
            if (!string.IsNullOrEmpty(stringConexao))
            {
                optionsBuilder.UseMySql(stringConexao,
                ServerVersion.AutoDetect(stringConexao));
            }
        }
    }
