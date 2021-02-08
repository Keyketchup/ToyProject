using StudentManager.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.IO;

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
        public void Create(Students _st) =>
            _students.InsertOne(_st);

        public void Delete(string Id) {
            _students.DeleteOne(Students => Students.Id ==  Id);
        }

        public void Update(string Id, Students _st) {
            Delete(Id);
            Create(_st);
             //_students.ReplaceOne(tmp => tmp.Id ==  Id, _st);
        }
    }
}