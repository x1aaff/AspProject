namespace AspProject
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(
                r =>
                {
                    r.MapControllerRoute(
                        "default",
                        "{controller=Home}/{action=Index}"
                        );
                });
        }
    }
}
