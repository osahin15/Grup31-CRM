using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ToptanciCRMApi.Domain;
using AutoMapper;
using Microsoft.OpenApi.Models;
using ToptanciCRMApi.Domain.Repositories;
using ToptanciCRMApi.Domain.Services;
using ToptanciCRMApi.Serivices;
using ToptanciCRMApi.Domain.UnitOfWork;
using ToptanciCRMApi.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ToptanciCRMApi
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

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ITokenHandler, TokenHandler>();

            services.AddScoped<IKategoriRepository, KategoriRepository>();
            services.AddScoped<IKategoriService, KategoriService>();

            services.AddScoped<ISiparisRepository, SiparisRepository>();
            services.AddScoped<ISiparisService, SiparisService>();

            services.AddScoped<IUrunService, UrunService>();
            services.AddScoped<IUrunRepository, UrunRepository>();

            services.AddScoped<ISiparisDetayRepository, SiparisDetayRepository>();
            services.AddScoped<ISiparisDetayService, SiparisDetayService>();

            services.AddScoped<IBayiRepository, BayiRepository>();
            services.AddScoped<IBayiService, BayiService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddCors(options =>
                        {
                            options.AddDefaultPolicy(builder =>
                            {
                                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                            });
                        });


            services.Configure<TokenOptions>(Configuration.GetSection("TokenOptions"));

            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(jwtbeareroptions =>
            {
                jwtbeareroptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    IssuerSigningKey = SignHandler.GetSecurityKey(tokenOptions.SecurityKey),
                    ClockSkew = TimeSpan.Zero
                };
            });


            services.AddDbContext<ToptanciCRMContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnecitonStrings:DefaultConnectionString"]);
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            //services.AddSwaggerGen(options => {
            //    options.SwaggerDoc("ToptanciApi",
            //        new Microsoft.OpenApi.Models.OpenApiInfo()
            //        {
            //            Title = "Toptanci Api",
            //            Version = "1"
            //        });
            /// });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }



            

            //app.UseSwagger();
            //app.UseSwaggerUI(options => {
            //    options.SwaggerEndpoint("/swagger/ToptanciApi/swagger.json", "Toptanci Api");                
            //    options.RoutePrefix = "";
            //});

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();
            app.UseCors();
            app.UseHttpsRedirection();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
