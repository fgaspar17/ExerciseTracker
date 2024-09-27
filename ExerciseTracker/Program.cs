using ExerciseTracker;
using ExerciseTrackerLibrary;
using Microsoft.Extensions.DependencyInjection;
using System;

var host = Startup.StartApplication();


using (var scope = host.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ExerciseContext>();
    var controller = new ExerciseController(context);
    // Add a new exercise

    var exercise1 = new Exercise
    {
        DateStart = DateTime.Now,
        DateEnd = DateTime.Now.AddMinutes(30),
        Duration = TimeSpan.FromMinutes(30),
        Comments = "Morning workout - Push-ups"
    };

    var exercise2 = new Exercise
    {
        DateStart = DateTime.Now,
        DateEnd = DateTime.Now.AddMinutes(45),
        Duration = TimeSpan.FromMinutes(45),
        Comments = "Evening cardio - Running"
    };

    controller.CreateExercise(exercise1);
    controller.CreateExercise(exercise2);

    // Retrieve and display all exercises
    Console.WriteLine("All Exercises:");
    foreach (var exercise in controller.GetExercises())
    {
        Console.WriteLine(exercise);
    }
}