using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebCau3.Entities;

namespace WebCau3.Lib
{
    public class DatabaseService
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog=Cau3ASPNET;Integrated Security=True";
        private SqlConnection sqlConnection = new SqlConnection();
        private SqlCommand sqlCommand = new SqlCommand();
        private SqlDataReader sqlDataReader;
        List<TiemVacXin> tiemVacXins = new List<TiemVacXin>();
        List<XiNghiep> xiNghieps = new List<XiNghiep>();
        public DatabaseService()
        {

        }
        // connect to database
        private void Connect()
        {
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.ConnectionString = _connectionString;
                sqlConnection.Open();
                sqlCommand.Connection = sqlConnection;

            }
        }
        // disconnect to database
        private void Disconnect()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        // get all  XiNghiep
        public DataTable GetAllXiNghiep()
        {
            Connect();
            sqlCommand.CommandText = "SELECT * FROM XiNghiep";
            sqlDataReader = sqlCommand.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(sqlDataReader);
            Disconnect();
            return dataTable;
        }

        // get all TiemVacXin
        public DataTable GetAllTiemVacXin()
        {
            Connect();
            sqlCommand.CommandText = "SELECT * FROM TiemVacXin";
            sqlDataReader = sqlCommand.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(sqlDataReader);
            Disconnect();
            return dataTable;
        }
        // add new TiemVacXin
        public void AddNewTiemVacXin(TiemVacXin tiemVacXin)
        {
            Connect();
            sqlCommand.CommandText = "INSERT INTO TiemVacXin VALUES(@HoTen, @XiNghiepId, @GioiTinh, @Status)";
            sqlCommand.Parameters.AddWithValue("@HoTen", tiemVacXin.HoTen);
            sqlCommand.Parameters.AddWithValue("@XiNghiepId", tiemVacXin.XiNghiepId);
            sqlCommand.Parameters.AddWithValue("@GioiTinh", tiemVacXin.GioiTinh);
            sqlCommand.Parameters.AddWithValue("@Status", tiemVacXin.Status);
            sqlCommand.ExecuteNonQuery();
            Disconnect();
        }
        // update TiemVacXin
        public void UpdateTiemVacXin(TiemVacXin tiemVacXin)
        {
            Connect();
            sqlCommand.CommandText = "UPDATE TiemVacXin SET HoTen = @HoTen, XiNghiepId = @XiNghiepId, GioiTinh = @GioiTinh, Status = @Status WHERE Id = @Id";
            sqlCommand.Parameters.AddWithValue("@Id", tiemVacXin.Id);
            sqlCommand.Parameters.AddWithValue("@HoTen", tiemVacXin.HoTen);
            sqlCommand.Parameters.AddWithValue("@XiNghiepId", tiemVacXin.XiNghiepId);
            sqlCommand.Parameters.AddWithValue("@GioiTinh", tiemVacXin.GioiTinh);
            sqlCommand.Parameters.AddWithValue("@Status", tiemVacXin.Status);
            sqlCommand.ExecuteNonQuery();
            Disconnect();
        }
        // remove TiemVacXin
        public void RemoveTiemVacXin(int id)
        {
            Connect();
            sqlCommand.CommandText = "DELETE FROM TiemVacXin WHERE Id = @Id";
            sqlCommand.Parameters.AddWithValue("@Id", id);
            sqlCommand.ExecuteNonQuery();
            Disconnect();
        }

        // get by  GioiTinh And Status
        public DataTable GetByGioiTinhAndXiNghiep(string gioiTinh, string status)
        {
            // get id xi nghiep by name
            Connect();
            sqlCommand.CommandText = "SELECT * FROM XiNghiep WHERE TenXiNghiep = @Name";
            sqlCommand.Parameters.AddWithValue("@Name", status);
            sqlDataReader = sqlCommand.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(sqlDataReader);
            if (dataTable.Rows.Count > 0)
            {
                status = dataTable.Rows[0]["Id"].ToString();
            }
            if (dataTable.Rows.Count >= 0)
            {
                return null;
            }


            sqlCommand.CommandText = "SELECT * FROM TiemVacXin WHERE GioiTinh = @GioiTinh AND XiNghiepId = @xiNghiepId";
            sqlCommand.Parameters.AddWithValue("@GioiTinh", gioiTinh);
            sqlCommand.Parameters.AddWithValue("@xiNghiepId", id);
            sqlDataReader = sqlCommand.ExecuteReader();
            DataTable dataTable1 = new DataTable();
            dataTable1.Load(sqlDataReader);
            Disconnect();
            return dataTable;
        }

        // get Count by Status
        public int GetCountByStatus(string status)
        {
            Connect();
            sqlCommand.CommandText = "SELECT COUNT(*) FROM TiemVacXin WHERE Status = @Status";
            sqlCommand.Parameters.AddWithValue("@Status", status);
            int count = (int)sqlCommand.ExecuteScalar();
            Disconnect();
            return count;
        }
    }
}