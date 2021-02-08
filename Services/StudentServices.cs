using StudentManager.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace StudentManager.Services
{
    public class StudentServices
    {
        private readonly IMongoCollection<Students> _students;

        public StudentServices(IStudentManagerDatabaseSettings settings) {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _students = database.GetCollection<Students>(settings.StudentCollectionName);
        }

        public List<Students> Get() =>
            _students.Find(Students => true).ToList();

        public Students Get(string Id) =>
            _students.Find(Students => Students.Id ==  Id).FirstOrDefault();
    }
}