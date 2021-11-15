using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CatalyaCMS.Domain.DomainModels;
using CatalyaCMS.Infrastructure.Abstractions;
using CatalyaCMS.Infrastructure.Context;
using CatalyaCMS.Infrastructure.Queries.Articles;
using CatalyaCMS.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Hosting;

namespace CatalyaCMS.Api
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
      services.AddDbContext<SiteDbContext>(options =>
      {
        options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
      });

      services.AddDefaultIdentityUI<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
          .AddEntityFrameworkStores<SiteDbContext>();

      services.AddIdentityServer()
          .AddApiAuthorization<ApplicationUser, SiteDbContext>();

      services.AddAuthentication()
          .AddIdentityServerJwt();

      services.AddScoped<BaseQuerySpecification<Article>, ArticleListQuerySpecification>();
      services.AddScoped<BaseQuerySpecification<Article>, ArticleDetailQuerySpecification>();
      services.AddScoped<IRepository<Article>, ArticleRepository>();

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
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseRouting();
      app.UseAuthentication();
      app.UseIdentityServer();
      app.UseAuthorization();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller}/{action=Index}/{id?}");
        endpoints.MapRazorPages();
      });
    }
  }
}
