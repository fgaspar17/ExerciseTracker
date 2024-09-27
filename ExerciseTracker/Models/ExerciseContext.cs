using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ExerciseTrackerLibrary;

public class ExerciseContext : DbContext
{
    DbSet<Exercise> Exercise {  get; set; }
    public string DbPath { get; }

    public ExerciseContext(DbContextOptions<ExerciseContext> options) : base(options) { }

    //protected override void OnConfiguring(DbContextOptionsBuilder options)
    //    => options.UseSqlite($"Data Source={DbPath}");
}