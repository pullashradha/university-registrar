using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace UniversityRegistrar
{
  public class CourseTest : IDisposable
  {
    public CourseTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=university_registrar_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_Empty_DatabaseIsEmpty()
    {
      int result = Course.GetAll().Count;
      Assert.Equal(0, result);
    }
    [Fact]
    public void Test_Equals_SameValuesMatch()
    {
      Course firstCourse = new Course("Intro to Programming", "CS101", 000000);
      Course secondCourse = new Course("Intro to Programming", "CS101", 000000);
      //New way of testing Equal method
      bool expected = true;
      bool test = firstCourse.Equals(secondCourse);
      Assert.Equal(expected, test);
    }
    public void Dispose()
    {
      // Course.DeleteAll();
    }
  }
}
