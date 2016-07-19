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
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=university_registrar__test;Integrated Security=SSPI;";
    }
    public void Dispose()
    {
      Student.DeleteAll();
    }
  }
}
