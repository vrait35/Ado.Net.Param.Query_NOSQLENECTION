using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ConnectLevelPart2
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection  connection=new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString))
            using (var command = new SqlCommand())
          
            {
                connection.Open();
                command.CommandText = "insert into users(id,login,password,updateDateTime)" +
                    "values(@id,@login,@password,@updateDate)";               
                command.Parameters.Add(new SqlParameter {
                    ParameterName = "@id",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = 8,
                IsNullable = false
            });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@login",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = "Vasja",
                    IsNullable = false
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@password",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = "Vasja",
                    IsNullable = false
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@updateDate",
                    SqlDbType = System.Data.SqlDbType.DateTime2,
                  Value=DateTime.Now                   
                });
                command.Connection = connection;
                command.ExecuteNonQuery();
                //using (var transaction = connection.BeginTransaction()) { }
            }            
        }
    }
}
