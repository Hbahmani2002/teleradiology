using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GT.UI.WebApi.Implementation;
using GT.UI.WebApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace GT.UI.WebApi
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
            services.AddControllers();
            TOkenAuthenticaation(services);
        }

        private void TOkenAuthenticaation(IServiceCollection services)
        {
            services.Configure<AppSettings>(AppSettings.Init(Configuration));
            var key = Encoding.ASCII.GetBytes(AppSettings.JWT.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddAuthorization();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Exception(app);
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseHsts();
            }
            //app.UseHttpsRedirection();

            Cors(app);

            app.UseRouting();

            Token(app);



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

        private void Exception(IApplicationBuilder app)
        {
            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature.Error;

                var result = JsonConvert.SerializeObject(HttpMessageService.Exception(exception));
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(result);
            }));
        }

        private void Token(IApplicationBuilder app)
        {
            //https://stackoverflow.com/questions/56185834/asp-net-core-api-always-returns-401-unauthorized-whenever-i-send-a-request-with
            app.UseAuthentication(); // this one first
            app.UseAuthorization();
        }

        private void Cors(IApplicationBuilder app)
        {
            app.UseCorsMiddleware();

            //https://stackoverflow.com/questions/31942037/how-to-enable-cors-in-asp-net-core
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                 //.AllowCredentials()
                 );

        }
    }
}
