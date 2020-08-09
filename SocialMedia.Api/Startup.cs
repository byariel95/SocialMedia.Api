

namespace SocialMedia.Api
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Core.Interfaces;
    using Infrastructure.Repositories;
    using Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;
    using AutoMapper;
    using System;
    using SocialMedia.Infrastructure.Filters;

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
            // added automapper and implement all mappings in automapper profile
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // ignore indentity with circle reference in models
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            })
            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true; // disable automatic validation from api controller 
            });
            //conection to database
            services.AddDbContext<SocialMediaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SocialMedia")));

            //add injection of dependency
            services.AddTransient<IPostRepository, PostRepository>();

            //register filter in global mode
            services.AddMvc( options => {

                options.Filters.Add<ValidationFilter>();
            }); 

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
