using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimpleBotCore.Bot;
using SimpleBotCore.Configuration;
using SimpleBotCore.Logic;
using SimpleBotCore.Repositories;
using SimpleBotCore.Repositories.Mongo;
using SimpleBotCore.Repositories.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBotCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services
                .AddOptions<ConnectionStrings>()
                .Configure<IConfiguration>(
                    (settings, configuration) =>
                    {
                        configuration.GetSection(nameof(ConnectionStrings)).Bind(settings);
                    });

            services.AddSingleton<ISqlDbContext, SqlDbContext>();
            services.AddSingleton<IMongoDbContext, MongoDbContext>();
            services.AddSingleton<Func<IEnumerable<IPerguntasRepository>>>(x => () => x.GetService<IEnumerable<IPerguntasRepository>>()!);

            services.AddScoped<IPerguntasRepository, PerguntasSqlRepository>();
            services.AddSingleton<IPerguntasRepository, PerguntasMongoRepository>();

            services.AddSingleton<IUserProfileRepository>(new UserProfileMockRepository());
            services.AddSingleton<IBotDialogHub, BotDialogHub>();
            services.AddSingleton<BotDialog, SimpleBot>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
