using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.SQLConnect;

namespace Test.Component
{
    public class User
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string RoleID { get; set; }

        KetNoiSql ketNoiSql = new KetNoiSql();
        public int Insert()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("userID", UserID);
            dic.Add("username", UserName);
            dic.Add("password", Password);
            dic.Add("fullname", FullName);
            dic.Add("address", Address);
            dic.Add("phone", Phone);
            dic.Add("roleid", RoleID);
            return ketNoiSql.ExecuteNonQueryCommand("INSERT INTO Users (UserID,User_Name,Password,Fullname,Address,Phone,RoleID) VALUES (@userID,@username,@password,@fullname,@address,@phone,@roleid)", dic);
        }

        public int Update()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("userID", UserID);
            dic.Add("username", UserName);
            dic.Add("password", Password);
            dic.Add("fullname", FullName);
            dic.Add("address", Address);
            dic.Add("phone", Phone);
            dic.Add("roleid", RoleID);
            return ketNoiSql.ExecuteNonQueryCommand("UPDATE Users SET User_Name = @username,Password = @password,Fullname = @fullname,Address = @address,Phone = @phone,RoleID = @roleid WHERE UserID = @userID", dic);
        }

        public int Delete()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("userID", UserID);
            return ketNoiSql.ExecuteNonQueryCommand("DELETE FROM Users WHERE UserID = @userID", dic);
        }

        public DataTable LayDuLieuTable()
        {
            return ketNoiSql.ExecuteDataTableCommand("SELECT Users.UserID,Users.User_Name,Users.Password,Users.Fullname,Users.Address,Users.Phone,Role.RoleName FROM Users,Role WHERE Users.RoleID = Role.RoleID", new Dictionary<string, object>());
        }

        public User LayDuLieuUserForLogin(string username, string password)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("username", username);
            dic.Add("password", password);
            List<object[]> list = ketNoiSql.ExecuteDataReaderCommand("SELECT User_Name,Password FROM Users WHERE User_Name = @username AND Password = @password", dic);
            if (list == null || list.Count <= 0)
            {
                return null;
            }
            object[] arr = list[0];
            return new User() { UserName = (string)arr[0], Password = (string)arr[1]};
        }

        public User KiemTraUserForDelete(string _roleid)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("roleid", _roleid);
            List<object[]> list = ketNoiSql.ExecuteDataReaderCommand("SELECT UserID FROM Users WHERE RoleID = @roleid", dic);
            if (list == null || list.Count <= 0)
            {
                return null;
            }
            object[] arr = list[0];
            return new User() { UserID = (string)arr[0] };
        }
    }
}
