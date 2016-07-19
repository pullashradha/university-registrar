using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace UniversityRegistrar
{
  public class Course
  {
    private int _id;
    private string _name;
    private string _courseCode;
    private int _courseNumber;
    public Course (string Name, string CourseCode, int CourseNumber, int Id = 0)
    {
      _id = Id;
      _name = Name;
      _courseCode = CourseCode;
      _courseNumber = CourseNumber;
    }
    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public void SetName (string newName)
    {
      _name = newName;
    }
    public string GetCourseCode()
    {
      return _courseCode;
    }
    public void SetCourseCode (string newCourseCode)
    {
      _courseCode = newCourseCode;
    }
    public int GetCourseNumber()
    {
      return _courseNumber;
    }
    public void SetCourseNumber (int newCourseNumber)
    {
      _courseNumber = newCourseNumber;
    }

    public override bool Equals(System.Object otherCourse)
    {
      if (!(otherCourse is Course))
      {
        return false;
      }
      else
      {
        Course newCourse = (Course) otherCourse;
        bool idEquality = (this.GetId() == newCourse.GetId());
        bool nameEquality = (this.GetName() == newCourse.GetName());
        bool courseCodeEquality = (this.GetCourseCode() == newCourse.GetCourseCode());
        bool courseNumberEquality = (this.GetCourseNumber() == newCourse.GetCourseNumber());
        return (idEquality && nameEquality && courseCodeEquality && courseNumberEquality);
      }
    }
    public static List<Course> GetAll()
    {
      List<Course> allCourses = new List<Course> {};
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr = null;
      SqlCommand cmd = new SqlCommand ("SELECT * FROM courses ORDER BY course_code ASC;", conn);
      rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        int courseId = rdr.GetInt32(0);
        string courseName = rdr.GetString(1);
        string courseCode = rdr.GetString(2);
        int courseNumber = rdr.GetInt32(3);
        Course newCourse = new Course (courseName, courseCode, courseNumber, courseId);
        allCourses.Add(newCourse);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allCourses;
    }
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr = null;
      SqlCommand cmd = new SqlCommand ("INSERT INTO courses (name, course_code, course_number) OUTPUT INSERTED.id VALUES (@CourseName, @CourseCode, @CourseNumber);", conn);
      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@CourseName";
      nameParameter.Value = this.GetName();
      SqlParameter codeParameter = new SqlParameter();
      codeParameter.ParameterName = "@CourseCode";
      codeParameter.Value = this.GetCourseCode();
      SqlParameter numberParameter = new SqlParameter();
      numberParameter.ParameterName = "@CourseNumber";
      numberParameter.Value = this.GetCourseNumber();
      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(codeParameter);
      cmd.Parameters.Add(numberParameter);
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
    public static Course Find (int queryCourseNumber)
    {
      List<Course> allCourses = new List<Course> {};
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr = null;
      SqlCommand cmd = new SqlCommand ("SELECT * FROM courses WHERE course_number = @CourseNumber;", conn);
      SqlParameter courseNumberParameter = new SqlParameter ();
      courseNumberParameter.ParameterName = "@CourseNumber";
      courseNumberParameter.Value = queryCourseNumber;
      cmd.Parameters.Add(courseNumberParameter);
      rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        int courseId = rdr.GetInt32(0);
        string courseName = rdr.GetString(1);
        string courseCode = rdr.GetString(2);
        int courseNumber = rdr.GetInt32(3);
        Course newCourse = new Course (courseName, courseCode, courseNumber, courseId);
        allCourses.Add(newCourse);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allCourses[0];
    }
    public static  void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand ("DELETE FROM courses;", conn);
      cmd.ExecuteNonQuery();
    }
  }
}
