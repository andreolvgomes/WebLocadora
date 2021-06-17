using Locabora.Application.Commands;
using Locabora.Application.Commands.Handlers;
using Locabora.Application.Queries;
using Locabora.Application.Queries.Handlers;
using Locadora.Data.Context;
using Locadora.Data.Repositories;
using Locadora.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Locadora.Api
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
            services.AddDbContext<LocadoraDbContext>(op => op.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Locadora.Api", Version = "v1" });
            });

            services.AddMediatR(typeof(Startup));
            services.AddAutoMapper(typeof(Startup));

            // inject dependency
            services.AddScoped<LocadoraDbContext>();
            services.AddScoped<IFilmeRepository, FilmeRepository>();
            // commands
            services.AddScoped<IRequestHandler<RemoverFilmeCommand, bool>, RemoverFilmeCommandHandler>();
            services.AddScoped<IRequestHandler<CriarFilmeCommand, bool>, CriarFilmeCommandHandler>();
            services.AddScoped<IRequestHandler<EditarFilmeCommand, bool>, EditarFilmeCommandHandler>();
            services.AddScoped<IRequestHandler<GetFilmeByIdQuery, Filme>, GetFilmeByIdQueryHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Locadora.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
