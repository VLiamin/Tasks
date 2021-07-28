using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace InternetStore
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();

            var options = optionsBuilder
                .UseSqlServer(@"Server=LAPTOP-QQUBGIB1\\SQLEXPRESS01;Database=Homework4b;Trusted_Connection=True;")
                .Options;
            DbContext dbContext = new MyDbContext(options);
      //      dbContext.Database.EnsureCreated();
            dbContext.Database.Migrate();
        }
    }
}