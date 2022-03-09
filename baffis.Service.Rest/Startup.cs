using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace baffis.Service.Rest
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("*").AllowAnyHeader().WithMethods("GET", "POST", "OPTIONS", "PUT", "DELETE"); ;
                                  });
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "baffis.Service.Rest", Version = "v1" });
            });
            services.AddSingleton<BusinessLogic.Interface.ICurrency, BusinessLogic.Currency>();
            services.AddSingleton<DataAccess.Interface.ICurrency, DataAccess.Currency>();
            services.AddSingleton<BusinessLogic.Interface.ISubscription, BusinessLogic.Subscription>();
            services.AddSingleton<DataAccess.Interface.ISubscription, DataAccess.Subscription>();
            services.AddSingleton<DataAccess.Interface.IConnectionManager, DataAccess.ConnectionManager>();
            services.AddSingleton<BusinessLogic.Interface.IOrder, BusinessLogic.Order>();
            services.AddSingleton<DataAccess.Interface.IOrder, DataAccess.Order>();
            services.AddSingleton<BusinessLogic.Interface.IPayment, BusinessLogic.Payment>();
            services.AddSingleton<DataAccess.Interface.IPayment, DataAccess.Payment>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "baffis.Service.Rest v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
