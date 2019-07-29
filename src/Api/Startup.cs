using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using MediatR;
using Gangueame.Eventstore;
using Marten;

namespace Gangueame.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvcCore()
                .AddJsonFormatters(settings =>
                {
                    settings.ContractResolver = new DefaultContractResolver();
                    settings.Formatting = Formatting.Indented;
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    settings.PreserveReferencesHandling = PreserveReferencesHandling.None;
                    settings.Converters.Add(new StringEnumConverter());
                });

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IEventStore, MartenEventStore>();
            var store = DocumentStore.For(_ =>
            {
                _.Connection("host=localhost;database=gangueame;password=;username=");
                _.Events.AddEventType(typeof(PostCreated));
            });
            services.AddSingleton<IDocumentStore>(store);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        }
    }
}
