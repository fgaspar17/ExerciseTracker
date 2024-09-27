namespace ExerciseTrackerLibrary;

public class ExerciseRepository(ExerciseContext context) : EntityFrameworkRepository<Exercise>(context)
{
}