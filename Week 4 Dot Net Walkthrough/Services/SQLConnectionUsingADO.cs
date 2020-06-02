using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace Week_4_Dot_Net_Walkthrough.Services
{
    public class SQLConnectionUsingADO
    {
        static readonly string connectionString = @"Data Source=THEACCELERATOR;Initial Catalog=Week6Database;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand sqlCommand = new SqlCommand();

        public void Init()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            System.Console.WriteLine(connection.ConnectionString);
        }

        public void Create(string name, string email, string gender, string skills, string city)
        {
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
            sqlCommand.CommandText = @"INSERT INTO dbo.Registration
            (
                --CustId - column value is auto - generated
                Name,
                Email,
                Gender,
                Skills,
                City
            )
            VALUES
            (
                --CustId - int
                '" + name + @"', --Name - varchar
                '" + email + @"', --Email - varchar
                '" + gender + @"', --Gender - varchar
                '" + skills + @"', --Skills - varchar
                '" + city + @"'-- City - varchar
            )";
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = connection;
        }

        public ArrayList Get(string email)
        {
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
            sqlCommand.CommandText = @"
                SELECT * FROM dbo.Registration 
                WHERE
                dbo.Registration.Email = '" + email + @"'
            ";
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = connection;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            Debug.WriteLine("Reader: " + reader.FieldCount);
            ArrayList data = new ArrayList();
            if (reader.Read())
            {
                if (reader.FieldCount > 0)
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        data.Add(reader.GetValue(i).ToString());
                    }
                }
            }

            return data;
        }

        public void Update(string name, string email, string gender, string skills, string city)
        {
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
            sqlCommand.CommandText = @"UPDATE dbo.Registration
            SET
                --CustId - column value is auto-generated
                dbo.Registration.Name = '" + name + @"', -- varchar
                dbo.Registration.Email = '" + email + @"', -- varchar
                dbo.Registration.Gender = '" + gender + @"', -- varchar
                dbo.Registration.Skills = '" + skills + @"', -- varchar
                dbo.Registration.City = '" + city + @"' -- varchar
            WHERE
                Email = '" + email + @"'";
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = connection;
        }

        public void Open()
        {
            connection.Open();
        }

        public void ExecuteNonQuery()
        {
            sqlCommand.ExecuteNonQuery();
        }

        public void Close()
        {
            connection.Close();
        }
    }
}