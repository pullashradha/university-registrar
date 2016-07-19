using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace UniversityRegistrar
{
  public class Student
  {

    public static List<Student> GetAll()
    {
      List<Student> allStudents = new List<Student>{};

      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM students ORDER by name ASC;", conn);
      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int studentId = rdr.GetInt32(0);
        string studentName = rdr.GetString(1);
        Date? studentEnrollmentDate = rdr.GetDate(2);
        int studentNumber = rdr.GetInt32(3);
        Student newStudent = new Student(studentName, studentNumber, studentEnrollmentDate, studentId);
      }
    }
  }
}
