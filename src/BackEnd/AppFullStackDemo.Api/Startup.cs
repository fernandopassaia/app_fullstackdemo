using System;
using System.Text;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Localization;
using AppFullStackDemo.Infra.Context;
using AppFullStackDemo.Infra.Transactions;
using AppFullStackDemo.Api.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using AppFullStackDemo.Infra.Data;
using AppFullStackDemo.Domain.Repositories;
using AppFullStackDemo.Infra.Repositories;
using AppFullStackDemo.Domain.Handlers;
using AppFullStackDemo.Infra.Repositories.Security;
using AppFullStackDemo.Domain.Repositories.Security;
using Newtonsoft.Json;

namespace AppFullStackDemo.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Config of Context, Cors and DependencyInjection
            //inject on this class the configuration coming from my .json
            //services.AddSingleton<IWebHostEnvironment>(Environment);
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.TokenSecret); //I will get a Key of my TokenSecret            

            services.AddScoped<AppFullStackDemoContext>();
            services.AddDbContext<AppFullStackDemoContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ServerLocalConnection")));

            services.AddTransient<IUow, Uow>();
            services.AddTransient<IDeviceModelRepository, DeviceModelRepository>();
            services.AddTransient<IEquipmentRepository, EquipmentRepository>();
            services.AddTransient<IManufacturerRepository, ManufacturerRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserClaimRepository, UserClaimRepository>();
            services.AddTransient<IClaimRepository, ClaimRepository>();

            services.AddTransient<DeviceModelHandler, DeviceModelHandler>();
            services.AddTransient<EquipmentHandler, EquipmentHandler>();
            services.AddTransient<ManufacturerHandler, ManufacturerHandler>();
            services.AddTransient<UserHandler, UserHandler>();

            #endregion Config of Cors DependencyInjection

            #region Config of EF Context / ConnectionString and Json Options
            services.AddCors(options =>
                options.AddPolicy("AppFullStackDemoCors",
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    }
                )
            );

            // services.AddMvc();
            // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            // services.AddMvc().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            // services.AddMvc()
            //     .AddNewtonsoftJson(options =>
            //     options.SerializerSettings.ContractResolver =
            //     new CamelCasePropertyNamesContractResolver());

            services
                .AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });


            #endregion Config of EF Context / ConnectionString / Postgres and Json Options 

            #region Config of JWT
            //Jwt Authentication
            //first of all i get the config in .Json and Cast to my Class AppSettings
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false; //if i set it to true, it will allow only https (secure)
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true, //will validate my "Emiter" (needs to be the name of my system)
                    IssuerSigningKey = new SymmetricSecurityKey(key), //my key (needs to keep it very very safe)
                    ValidateIssuer = true, //will validate the name of my system backend (check in Settings.Emiter)
                    ValidateAudience = true, //will check my URL (that's specific in Settings.ValidIn - default there is http://localhost)
                    ValidIssuer = appSettings.Emiter,
                    ValidAudience = appSettings.ValidIn, //Note: I can use ValidIssuers and ValidAudiences (with S) and pass a IEnumerable, setting various systems, like AngularApp, MobileApp... just configure and use
                    ClockSkew = TimeSpan.Zero,
                    ValidateLifetime = true //With this Two flags I ensure that Token will only be valid for 5 minutes (or whats configured on the JWT generation)
                    //NOTE: More information about these Fields you can see on Class AppSettings.cs in Details
                };
            });
            #endregion Config of JWT

            #region MockDataCreator
            var dbContext = services.BuildServiceProvider().GetService<AppFullStackDemoContext>();
            SeedMockDataCreator.CreateMockData(dbContext);
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //here is the culture of your app language, please change it to modify Dates and other settings
            var supportedCultures = new[] { new CultureInfo("pt-BR") };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseCors("AppFullStackDemoCors");
            app.UseAuthentication();
            app.UseAuthorization();

            //Here I'll call the Helper that generate mockdata test for the API


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
