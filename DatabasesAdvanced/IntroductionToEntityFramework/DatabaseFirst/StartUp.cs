using DatabaseFirst.Data;

namespace DatabaseFirst
{
    public class StartUp
    {
        public static void Main()
        {
            using (var db = new SoftUniContext())
            {
                var manager = new ExerciseManager(db);

                manager.Run();
            }
        }
    }
}
