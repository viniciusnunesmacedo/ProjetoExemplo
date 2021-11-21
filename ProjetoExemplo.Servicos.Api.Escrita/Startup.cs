using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetoExemplo.Infraestrutura.Transversal.Identidade;
using ProjetoExemplo.Infraestrutura.Transversal.Identidade.Seguranca;
using ProjetoExemplo.Infraestrutura.Transversal.Identidade.Seguranca.Usuario;
using ProjetoExemplo.Servicos.Api.Escrita.Configuracoes;

namespace ProjetoExemplo.Servicos.Api.Escrita
{
    public class Startup
    {
        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuracoes = builder.Build();
        }

        public IConfiguration Configuracoes { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection servicos)
        {
            // WebAPI Config
            servicos.AddControllers();

            // Setting DBContexts
            servicos.AdicionarConfiguracaoBancoDados(Configuracoes);

            // ASP.NET Identity Settings & JWT
            servicos.AdicionarConfiguracaoIdentidadeApi(Configuracoes);

            // Interactive AspNetUser (logged in)
            // NetDevPack.Identity dependency
            servicos.AdicionarConfiguracaoUsuarioAspNet();

            // AutoMapper Settings
            servicos.AdicionarConfiguracaoAutoMapper();

            // Swagger Config
            servicos.AdicionarConfiguracaoSwagger();

            // Adding MediatR for Domain Events and Notifications
            servicos.AddMediatR(typeof(Startup));

            // .NET Native DI Abstraction
            servicos.AdicionarConfiguracaoInjecaoDependencia();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
           
            app.UseRouting();

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            // NetDevPack.Identity dependency
            app.ConfiguracaoAutenticacaoUsuario();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerSetup();
        }
    }
}
