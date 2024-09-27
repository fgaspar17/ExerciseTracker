using ExerciseTrackerLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker;
using Microsoft.Extensions.Configuration;

public class Startup
{
    public static IHost StartApplication()
    {
        // TODO: CancelString
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        
        IConfiguration config = builder.Build();

        var host = new HostBuilder()
        .ConfigureServices((hostContext, services) =>
        {
            services.AddDbContext<ExerciseContext>(options =>
                options.UseSqlite(config.GetConnectionString("SqliteDB"), b => b.MigrationsAssembly("ExerciseTracker")));
            services.AddTransient(typeof(IRepository<Exercise>), typeof(ExerciseRepository));
        });

        return host.Build();
    }
}
