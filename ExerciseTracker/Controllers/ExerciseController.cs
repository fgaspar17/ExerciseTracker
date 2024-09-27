namespace ExerciseTrackerLibrary;

public class ExerciseController
{
    private IRepository<Exercise> _repository;

    public ExerciseController(ExerciseContext exerciseContext)
    {
        _repository = new ExerciseRepository(exerciseContext);
    }

    public IEnumerable<Exercise> GetExercises() => _repository.GetAll();
    public Exercise? GetExerciseById(int id) => _repository.GetById(id);
    public void CreateExercise(Exercise exercise) => _repository.Add(exercise);
    public void UpdateExercise(Exercise exercise) => _repository.Update(exercise);
    public void DeleteExercise(Exercise exercise) => _repository.Delete(exercise);
}