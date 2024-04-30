using LAB_APP.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LAB_APP.API.Services
{
    public static class DataBaseManagmentService
    {
        public static void MigrationInitialisation(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var servicedB = serviceScope.ServiceProvider.GetService<AppDbContext>();
                servicedB?.Database.Migrate();
            }
        }
    }
}
