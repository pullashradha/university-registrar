using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace UniversityRegistrar
{
  public class StudentTest : IDisposable
  {
    public StudentTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=university_registrar_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      int result = Student.GetAll().Count;

      Assert.Equal(0, result);
    }
    [Fact]
    public void Test_Equals_SameEntriesMatch()
    {
      Student firstStudent = new Student ("Jane Doe", 999999, new DateTime (2016, 07, 19));
      Student secondStudent = new Student ("Jane Doe", 999999, new DateTime (2016, 07, 19));
      Assert.Equal(firstStudent, secondStudent);
    }
    [Fact]
    public void Test_Save_SavesStudentToDatabase()
    {
      Student studentToSave = new Student ("Jane Doe", 999999, new DateTime (2016, 07, 19));
      studentToSave.Save();
      Assert.Equal(studentToSave, Student.GetAll()[0]);
      Assert.Equal(1, Student.GetAll().Count);
    }
    [Fact]
    public void Test_Find_ReturnsStudentByStudentNumber()
    {
      Student firstStudent = new Student ("Kevin Macallister", 123456, new DateTime (1995, 12, 25));
      firstStudent.Save();
      Student secondStudent = new Student ("Bart Simpson", 654321, new DateTime(1989, 7, 4));
      secondStudent.Save();
      Student foundStudent = Student.Find(firstStudent.GetNumber());
      Assert.Equal(firstStudent, foundStudent);
    }
    public void Dispose()
    {
      Student.DeleteAll();
    }
  }
}
