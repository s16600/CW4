using CW3.Controllers;
using CW3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using CW3.DAL;
using System.Data.SqlClient;
//using Microsoft.Data.SqlClient;


namespace CW3.DAL
{
    public class MockDbService : IDbService
    {
        /*
        private static IEnumerable<Student> _students;

        static MockDbService()
        {
            _students = new List<Student>
            {
                new Student{IdStudent=1, FirstName="Jan", LastName="Kowalski"},
                new Student{IdStudent=2, FirstName="Anna", LastName="Malewski"},
                new Student{IdStudent=3, FirstName="Andrzej", LastName="Andrzejewicz"}
            };
        }


        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }
        */

        
        public IEnumerable<Student> GetStudents()
        {
            var list = new List<Student>();

            using (SqlConnection conection = new SqlConnection("Data Source=db-mssql;Initial Catalog=s16600;Integrated Security=True"))
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conection;
                command.CommandText = "select * from Student";

                conection.Open();
                SqlDataReader sqlReader = command.ExecuteReader();
                while (sqlReader.Read())
                {
                    var student = new Student();
                    student.FirstName = sqlReader["FirstName"].ToString();
                    student.LastName = sqlReader["LastName"].ToString();
                    student.IndexNumber = sqlReader["IndexNumber"].ToString();
                    list.Add(student);
                }

            }
            return list;
        }




        public IEnumerable<Enrollment> GetStudentsEnrollment(string id)
        {

            var list = new List<Enrollment>();

            using (SqlConnection conection = new SqlConnection("Data Source=db-mssql;Initial Catalog=s16600;Integrated Security=True"))
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conection;
                command.CommandText = "SELECT e.IdEnrollment,e.Semester,e.IdStudy,e.StartDate FROM Student AS s INNER JOIN Enrollment as e ON s.IdEnrollment = e.IdEnrollment WHERE s.IndexNumber = @id";
                command.Parameters.AddWithValue("id", id);

                conection.Open();
                SqlDataReader sqlReader = command.ExecuteReader();

                while (sqlReader.Read())
                {
                    var enrol = new Enrollment();
                    enrol.IdEnrollment = Int32.Parse(sqlReader["IdEnrollment"].ToString());
                    enrol.Semester = Int32.Parse(sqlReader["Semester"].ToString());
                    enrol.IdStudy = Int32.Parse(sqlReader["IdStudy"].ToString());
                    enrol.StartDate = sqlReader["StartDate"].ToString();
                    list.Add(enrol);
                }

            }

            return list;
        }
    }
}
