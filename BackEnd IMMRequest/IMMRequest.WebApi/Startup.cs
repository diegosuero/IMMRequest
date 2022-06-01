using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMMRequest.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using IMMRequest.DataAccess;
using IMMRequest.BusinessLogic;
using IMMRequest.BusinessLogic.Interface;
using IMMRequest.DataAccess.Interface;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;





namespace IMMRequest.WebApi
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
            services.AddDbContext<DbContext, IMMRequestContext>(
                o => o.UseSqlServer(Configuration.GetConnectionString("IMMRequestDB"))
            );
            services.AddControllers();
        services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Put title here", Description = "DotNet Core Api 3 - with swagger" }); });
        services.AddScoped<ILogic<Administrador>, AdministradorLogic>();
        services.AddScoped<IRepository<Administrador>, AdministradorRepository>();
        services.AddScoped<ISession<AdminSession>, SesionLogic>();
        services.AddScoped<IRepository<AdminSession>, SessionsRepository>();
        services.AddScoped<ILogic<Solicitud>, SolicitudLogic>();
        services.AddScoped<IRepository<Solicitud>, SolicitudRepository>();
        services.AddScoped<ILogic<Area>, AreaLogic>();
        services.AddScoped<IRepository<Area>, AreaRepository>();
        services.AddScoped<ILogic<Tema>, TemaLogic>();
        services.AddScoped<IRepository<Tema>, TemaRepository>();
        services.AddScoped<ILogic<TipoDeTema>, TipoDeTemaLogic>();
        services.AddScoped<IRepository<TipoDeTema>, TipoRepository>();
        services.AddScoped<ILogic<CampoAicionalTexto>, CampoAdicionalTextoLogic>();
        services.AddScoped<IRepository<CampoAicionalTexto>, CampoAdicionalTextoRepository>();
        services.AddScoped<ILogic<CampoAdicionalFecha>, CampoAdicionalFechaLogic>();
        services.AddScoped<IRepository<CampoAdicionalFecha>, CampoAdicionalFechaRepository>();
        services.AddScoped<ILogic<CampoAdicionalEntero>, CampoAdicionalEnteroLogic>();
        services.AddScoped<IRepository<CampoAdicionalEntero>, CampoAdicionalEnteroRepository>();
        services.AddScoped<ILogic<CampoAdicionalBooleano>, CampoAdicionalBooleanoLogic>();
        services.AddScoped<IRepository<CampoAdicionalBooleano>, CampoAdicionalBooleanoRepository>();
        services.AddScoped<ImportadorLogic, ImportadorLogic>();
        
        services.AddCors(
                options => { options.AddPolicy(
                    "CorsPolicy", 
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                );
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            
            app.UseRouting();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

          app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
          
        }
    }
}
