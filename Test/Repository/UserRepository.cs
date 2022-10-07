using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Component;

namespace Test.Repository
{
    public class UserRepository
    {
        public int InsertDuLieu(User user)
        {
            return user.Insert();
        }

        public int InsertDuLieu(string _userid, string _username, string _password, string _fullname, string _address, string _phone, string _roleid)
        {
            return InsertDuLieu(new User() { UserID = _userid, UserName = _username, Password = _password, FullName = _fullname, Address = _address, Phone = _phone, RoleID = _roleid });
        }

        public int UpdateDuLieu(User user)
        {
            return user.Update();
        }

        public int UpdateDuLieu(string _userid, string _username, string _password, string _fullname, string _address, string _phone, string _roleid)
        {
            return UpdateDuLieu(new User() { UserID = _userid, UserName = _username, Password = _password, FullName = _fullname, Address = _address, Phone = _phone, RoleID = _roleid });
        }

        public int DeleteDuLieu(User user)
        {
            return user.Delete();
        }

        public int DeleteDuLieu(string _userid)
        {
            return DeleteDuLieu(new User() { UserID = _userid });
        }

        public DataTable GetAllUser()
        {
            User user = new User();
            return user.LayDuLieuTable();
        }

        public User GetUserForLogin(string username,string password)
        {
            User user = new User();
            return user.LayDuLieuUserForLogin(username, password);
        }

        public User KiemTraUserForDelete(string _roleid)
        {
            User role = new User();
            return role.KiemTraUserForDelete(_roleid);
        }
    }
}
