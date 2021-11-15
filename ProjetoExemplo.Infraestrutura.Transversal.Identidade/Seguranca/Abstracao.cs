using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjetoExemplo.Infraestrutura.Transversal.Identidade.Seguranca.Dados;
using ProjetoExemplo.Infraestrutura.Transversal.Identidade.Seguranca.Modelo;
using System;

namespace ProjetoExemplo.Infraestrutura.Transversal.Identidade.Seguranca
{
    public static class Abstracao
    {
        public static IdentityBuilder AdicionarConfiguracaoIdentidade(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentException(nameof(services));

            return services.AddDefaultIdentity<UsuarioAplicacao>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ContextoAplicacao>()
                .AddDefaultTokenProviders();
        }

        public static IdentityBuilder AddDefaultIdentity(this IServiceCollection services, Action<IdentityOptions> options = null)
        {
            if (services == null) throw new ArgumentException(nameof(services));

            return services.AddDefaultIdentity<IdentityUser>(options);
        }

        public static IdentityBuilder AddCustomIdentity<TIdentityUser>(this IServiceCollection services, Action<IdentityOptions> options = null)
            where TIdentityUser : IdentityUser
        {
            if (services == null) throw new ArgumentException(nameof(services));

            return services.AddDefaultIdentity<TIdentityUser>(options);
        }

        public static IdentityBuilder AddCustomIdentity<TIdentityUser, TKey>(this IServiceCollection services, Action<IdentityOptions> options = null)
            where TIdentityUser : IdentityUser<TKey>
            where TKey : IEquatable<TKey>
        {
            if (services == null) throw new ArgumentException(nameof(services));

            return services.AddDefaultIdentity<TIdentityUser>(options);
        }

        public static IdentityBuilder AddDefaultRoles(this IdentityBuilder builder)
        {
            return builder.AddRoles<IdentityRole>();
        }

        public static IdentityBuilder AddCustomRoles<TRole>(this IdentityBuilder builder)
            where TRole : IdentityRole
        {
            return builder.AddRoles<TRole>();
        }

        public static IdentityBuilder AddCustomRoles<TRole, TKey>(this IdentityBuilder builder)
            where TRole : IdentityRole<TKey>
            where TKey : IEquatable<TKey>
        {
            return builder.AddRoles<TRole>();
        }

        public static IdentityBuilder AddDefaultEntityFrameworkStores(this IdentityBuilder builder)
        {
            return builder.AddEntityFrameworkStores<ContextoAplicacao>();
        }

        public static IdentityBuilder AddCustomEntityFrameworkStores<TContext>(this IdentityBuilder builder) where TContext : DbContext
        {
            return builder.AddEntityFrameworkStores<TContext>();
        }

        public static IServiceCollection AddIdentityEntityFrameworkContextConfiguration(
            this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            if (services == null) throw new ArgumentException(nameof(services));
            if (options == null) throw new ArgumentException(nameof(options));
            return services.AddDbContext<ContextoAplicacao>(options);
        }

        public static IApplicationBuilder  ConfiguracaoAutenticacaoUsuario(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentException(nameof(app));

            return app.UseAuthentication()
                      .UseAuthorization();
        }
    }
}
