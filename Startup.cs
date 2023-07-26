using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.Swagger;

namespace BidOneWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen();           
            services.AddHttpClient();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {                         
            app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
            app.UseHsts();            

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            app.UseSwagger();
            app.UseSwaggerUI();           

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }
    }
}
