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
    public void AddCourse (Course newCourse)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand ("INSERT INTO students_courses (student_number, course_number) VALUES (@StudentNumber, @CourseNumber);", conn);
      SqlParameter studentNumberParameter = new SqlParameter();
      studentNumberParameter.ParameterName = "@StudentNumber";
      studentNumberParameter.Value = this.GetNumber();
      SqlParameter courseNumberParameter = new SqlParameter ();
      courseNumberParameter.ParameterName = "@CourseNumber";
      courseNumberParameter.Value = newCourse.GetCourseNumber();
      cmd.Parameters.Add(studentNumberParameter);
      cmd.Parameters.Add(courseNumberParameter);
      cmd.ExecuteNonQuery();
      if (conn != null)
      {
        conn.Close();
      }
    }
    public List<Course> GetCourses()
    {
      List<int> courseNumbers = new List<int> {};
      List<Course> allCourses = new List<Course> {};
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr = null;
      SqlCommand cmd = new SqlCommand ("SELECT course_number FROM students_courses WHERE student_number = @StudentNumber;", conn);
      SqlParameter studentNumberParameter = new SqlParameter();
      studentNumberParameter.ParameterName = "@StudentNumber";
      studentNumberParameter.Value = this.GetNumber();
      cmd.Parameters.Add(studentNumberParameter);
      rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        int courseNumber = rdr.GetInt32(0);
        courseNumbers.Add(courseNumber);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      foreach (int courseNumber in courseNumbers)
      {
        SqlDataReader queryReader = null;
        SqlCommand courseQuery = new SqlCommand ("SELECT * FROM courses WHERE course_number = @CourseNumber;", conn);
        SqlParameter courseNumberParameter = new SqlParameter();
        courseNumberParameter.ParameterName = "@CourseNumber";
        courseNumberParameter.Value = courseNumber;
        courseQuery.Parameters.Add(courseNumberParameter);
        queryReader = courseQuery.ExecuteReader();
        while (queryReader.Read())
        {
          int courseId = queryReader.GetInt32(0);
          string courseName = queryReader.GetString(1);
          string courseCode = queryReader.GetString(2);
          int thisCourseNumber = queryReader.GetInt32(3);
          Course foundCourse = new Course (courseName, courseCode, thisCourseNumber, courseId);
          allCourses.Add(foundCourse);
        }
        if (queryReader != null)
        {
          queryReader.Close();
        }
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allCourses;
    }
    public void DeleteOne()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand ("DELETE FROM students WHERE student_number = @StudentNumber;", conn);
      SqlParameter studentNumberParameter = new SqlParameter ();
      studentNumberParameter.ParameterName = "@StudentNumber";
      studentNumberParameter.Value = this.GetNumber();
      cmd.Parameters.Add(studentNumberParameter);
      cmd.ExecuteNonQuery();
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
