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
    public void Dispose()
    {
      // Student.DeleteAll();
    }
  }
}
