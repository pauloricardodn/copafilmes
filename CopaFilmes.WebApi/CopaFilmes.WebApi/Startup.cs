using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmes.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "CorsPolicy";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvc().AddControllersAsServices();

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    builder.WithOrigins("*")
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            // Adicionando servicos do framework
            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    // handle loops correctly
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                    // use standard name conversion of properties
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                    // include $id property in the output
                    //options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
                });

            // Configurando o serviço de documentação do Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Documentação de Apis",
                        Version = "v1.0",
                        Description = "# Introducão\nSeja bem-vindo a documentação da API CopaFilmes!\n"
                                      + "API foi criada utilizando o padrão REST.",
                        Contact = new Contact
                        {
                            Name = "Lambda3"
                        }
                    });
            });

            //services.AddMvc(options => options.EnableEndpointRouting = true).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvcCore(options => options.EnableEndpointRouting = false);

            services.AddApiVersioning(
                options =>
                {
                    // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
                    options.ReportApiVersions = true;

                    options.DefaultApiVersion = new ApiVersion(new DateTime(2019, 2, 20));

                    // automatically applies an api version based on the name of the defining controller's namespace
                    options.Conventions.Add(new VersionByNamespaceConvention());
                });
           // services.AddMvc().AddWebApiConventions();

            services.AddSingleton<IConfiguration>(Configuration);
            InjectionDependency.InjecaoDependenciaRepositorios(ref services);


            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(context =>
                {
                    var userLangs = context.Request.Headers["Accept-Language"].ToString();
                    var firstLang = userLangs.Split(',').FirstOrDefault();
                    var defaultLang = string.IsNullOrEmpty(firstLang) ? "pt-BR" : firstLang;
                    return Task.FromResult(new ProviderCultureResult(defaultLang, defaultLang));
                }));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var supportedCultures = new[] {
                new CultureInfo("pt-BR")
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("pt-BR"),
                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // UI strings that we have localized.
                SupportedUICultures = supportedCultures
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(MyAllowSpecificOrigins);

            // Ativando middlewares para uso do Swagger
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api da Copa do Mundo de Filmes - Versão 1.0");

                c.RoutePrefix = string.Empty;
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "DefaultApi", template: "{controller=Values}/{id?}");
            });

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
