using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.SQLConnect
{
    public class KetNoiSql
    {
        public string ConnectionString { get; set; }
        public SqlConnection SqlConnection { get; set; }

        public KetNoiSql()
        {
            ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Test\Test\KetNoiDB.mdf;Integrated Security=True";
            SqlConnection = new SqlConnection(ConnectionString);
        }

        public KetNoiSql(string _connectionString)
        {
            ConnectionString = _connectionString;
            SqlConnection = new SqlConnection(ConnectionString);
        }

        //Mở kết nối
        public void OpenConnection()
        {
            if (SqlConnection.State != System.Data.ConnectionState.Open)
            {
                SqlConnection.Open();
            }
        }

        //Đóng kết nối
        public void CloseConnection()
        {
            SqlConnection.Close();
        }

        //Xử lý các tập lệnh không có kiểu trả về : INSERT, UPDATE, DELETE
        public int ExecuteNonQueryCommand(string SqlText, Dictionary<string, object> SqlParams)
        {
            SqlCommand sqlCommand = SqlConnection.CreateCommand();
            sqlCommand.CommandText = SqlText;
            if (SqlParams.Count > 0)
            {
                foreach (string key in SqlParams.Keys)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(key, SqlParams[key]));
                }
            }
            try
            {
                OpenConnection();
                int sobanghi = sqlCommand.ExecuteNonQuery();
                if (sobanghi <= 0)
                {
                    throw new Exception("Không có dữ liệu nào được xử lý!");
                }
                return sobanghi;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }

        //Xử lý tập lệnh có kiểu trả về (Trả về danh sách các đối tượng): SELECT
        public List<object[]> ExecuteDataReaderCommand(string SqlText, Dictionary<string, object> SqlParams)
        {
            SqlCommand sqlCommand = SqlConnection.CreateCommand();
            sqlCommand.CommandText = SqlText;
            if (SqlParams.Count > 0)
            {
                foreach (string key in SqlParams.Keys)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(key, SqlParams[key]));
                }
            }
            List<object[]> list = new List<object[]>();
            try
            {
                OpenConnection();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    object[] arr = new object[sqlDataReader.FieldCount];
                    for (int i = 0; i < sqlDataReader.FieldCount; i++)
                    {
                        arr[i] = sqlDataReader[i];
                        list.Add(arr);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            return list;
        }

        //Xử lý tập lệnh có kiểu trả về (Trả về bảng dữ liệu): SELECT
        public DataTable ExecuteDataTableCommand(string SqlText, Dictionary<string, object> SqlParams)
        {
            SqlCommand sqlCommand = SqlConnection.CreateCommand();
            sqlCommand.CommandText = SqlText;
            if (SqlParams.Count > 0)
            {
                foreach (string key in SqlParams.Keys)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(key, SqlParams[key]));
                }
            }
            DataTable dataTable = new DataTable();
            try
            {
                OpenConnection();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            return dataTable;
        }
    }
}
