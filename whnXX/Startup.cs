using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using whnXX.Services;
using Microsoft.EntityFrameworkCore;
using whnXX.Database;
using Microsoft.Extensions.Configuration;


namespace whnXX
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration) 
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // 每次创建请求发起新的，请求结束注销
            services.AddTransient<ITouristRouteRepository, TouristRouteRepository>();
            services.AddDbContext<AppDbContext>(option => {
                //option.UseSqlServer("server=localhost; Database=; User Id=sa; Password=");
                 option.UseSqlServer("Data Source=(localdb)\\ProjectsV13;Initial Catalog=mxdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                //option.UseSqlServer(Configuration["DbContext: ConnectionString"]);
            });

            //services.AddSingleton 有且仅创建一个
            //services.AddScoped 事物 有且仅创建一个
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
                //endpoints.MapGet("/test", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
                endpoints.MapControllers();
            });
        }
    }
}
