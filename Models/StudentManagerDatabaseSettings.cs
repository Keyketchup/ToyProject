namespace StudentManager.Models
{
    public class StudentManagerDatabaseSettings : IStudentManagerDatabaseSettings
    {
        public string StudentCollectionName{ get; set;}
        public string ConnectionString{ get; set;}
        public string DatabaseName{ get; set;}
}

    public interface IStudentManagerDatabaseSettings{
        string StudentCollectionName{ get; set;}
        string ConnectionString{ get; set;}
        string DatabaseName{ get; set;}


    }
}