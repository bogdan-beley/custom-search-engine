using CustomSearchEngine.Configuration;
using CustomSearchEngine.Models;
using CustomSearchEngine.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace CustomSearchEngine
{
    public class Startup
    {
        private string _apiKey = null;
        private string _searchEngineId = null;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<CustomSearchEngineContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CustomSearchEngineDb")));
           
            services.AddHttpClient<IGoogleWebSearchApiClient, GoogleWebSearchApiClient>(client => {
                _apiKey = Configuration["GoogleCustomSearch:ApiKey"];
                _searchEngineId = Configuration["GoogleCustomSearch:SearchEngineId"];
                client.BaseAddress = new Uri("https://www.googleapis.com/customsearch/v1?key=" + _apiKey + "&cx=" + _searchEngineId + "&q=");
            });

            services.AddHttpClient<IBingWebSearchApiClient, BingWebSearchApiClient>();

            services.Configure<ExternalApiClientsConfig>(ExternalApiClientsConfig.BingWebSearchApiClient, Configuration.GetSection("ExternalApiClientsConfig:BingWebSearchApiClient"));

            services.AddScoped<ISearchResultsService, SearchResultsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
