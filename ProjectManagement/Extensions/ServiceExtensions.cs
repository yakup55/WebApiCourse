namespace ProjectManagement.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(x=>x.AddPolicy("CorsPolicy",y=>y.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
        }
    }
}
