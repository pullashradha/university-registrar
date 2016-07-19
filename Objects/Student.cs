using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace UniversityRegistrar
{
  public class Student
  {
    private int _id;
    private string _name;
    private int _number;
    private DateTime? _enrollmentDate;
    public Student(string name, int number, DateTime? enrollmentDate, int id = 0)
    {
      _id = id;
      _name = name;
      _number = number;
      _enrollmentDate = enrollmentDate;
    }
    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public int GetNumber()
    {
      return _number;
    }
    public DateTime? GetEnrollmentDate()
    {
      return _enrollmentDate;
    }
    public void SetName(string name)
    {
      _name = name;
    }
    public void SetNumber(int number)
    {
      _number = number;
    }
    public void SetEnrollmentDate(DateTime? enrollmentDate)
    {
      _enrollmentDate = enrollmentDate;
    }
    public override bool Equals (System.Object otherStudent)
    {
      if (otherStudent is Student)
      {
        Student newStudent = (Student) otherStudent;
        bool idEquality = (this.GetId() == newStudent.GetId());
        bool nameEquality = (this.GetName() == newStudent.GetName());
        bool numberEquality = (this.GetNumber() == newStudent.GetNumber());
        bool enrollmentDateEquality = (this.GetEnrollmentDate() == newStudent.GetEnrollmentDate());
        return (idEquality && nameEquality && numberEquality && enrollmentDateEquality);
      }
      else
      {
        return false;
      }
    }
    public static List<Student> GetAll()
    {
      List<Student> allStudents = new List<Student>{};
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM students ORDER by name ASC;", conn);
      rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        int studentId = rdr.GetInt32(0);
        string studentName = rdr.GetString(1);
        int studentNumber = rdr.GetInt32(2);
        DateTime? studentEnrollmentDate = rdr.GetDateTime(3);
        Student newStudent = new Student(studentName, studentNumber, studentEnrollmentDate, studentId);
        allStudents.Add(newStudent);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allStudents;
    }
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr = null;
      SqlCommand cmd = new SqlCommand ("INSERT INTO students (name, student_number, enrollment_date) OUTPUT INSERTED.id VALUES (@StudentName, @StudentNumber, @StudentEnrollmentDate);", conn);
      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@StudentName";
      nameParameter.Value = this.GetName();
      SqlParameter numberParameter = new SqlParameter();
      numberParameter.ParameterName = "@StudentNumber";
      numberParameter.Value = this.GetNumber();
      SqlParameter enrollmentDateParameter = new SqlParameter();
      enrollmentDateParameter.Value = this.GetEnrollmentDate();
      enrollmentDateParameter.ParameterName = "@StudentEnrollmentDate";
      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(numberParameter);
      cmd.Parameters.Add(enrollmentDateParameter);
      rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }
    public static Student Find (int queryStudentNumber)
    {
      List<Student> allStudents = new List<Student> {};
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr = null;
      SqlCommand cmd = new SqlCommand ("SELECT * FROM students WHERE student_number = @StudentNumber;", conn);
      SqlParameter studentNumberParameter = new SqlParameter ();
      studentNumberParameter.ParameterName = "@StudentNumber";
      studentNumberParameter.Value = queryStudentNumber;
      cmd.Parameters.Add(studentNumberParameter);
      rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        int studentId = rdr.GetInt32(0);
        string studentName = rdr.GetString(1);
        int studentNumber = rdr.GetInt32(2);
        DateTime? studentEnrollmentDate = rdr.GetDateTime(3);
        Student newStudent = new Student (studentName, studentNumber, studentEnrollmentDate, studentId);
        allStudents.Add(newStudent);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allStudents[0];
    }
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand ("DELETE FROM students;", conn);
      cmd.ExecuteNonQuery();
    }
  }
}
