using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TesteCleverti.Extensions;

namespace TesteCleverti.Configuration
{
    public static class TodoConfig
    {
        public static IServiceCollection AddTodoConfiguration(this IServiceCollection services,
            IConfiguration Configuration)
        {
            services.Configure<TodoDatabaseSettings>(
                Configuration.GetSection(nameof(TodoDatabaseSettings)));

            services.AddSingleton<ITodoDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<TodoDatabaseSettings>>().Value);

            return services;
        }

        public static IApplicationBuilder UseIdentityConfiguration(this IApplicationBuilder app)
        {
            return app;
        }

    }
}
