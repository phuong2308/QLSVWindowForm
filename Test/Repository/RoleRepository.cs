using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.Component;

namespace Test.Repository
{
    public class RoleRepository
    {
        public int InsertDuLieu(Role role)
        {
            return role.Insert();
        }

        public int InsertDuLieu(string _roleid, string _rolename)
        {
            return InsertDuLieu(new Role() { RoleID = _roleid, RoleName = _rolename });
        }

        public int UpdateDuLieu(Role role)
        {
            return role.Update();
        }

        public int UpdateDuLieu(string _roleid, string _rolename)
        {
            return UpdateDuLieu(new Role() { RoleID = _roleid, RoleName = _rolename });
        }

        public int DeleteDuLieu(Role role)
        {
            return role.Delete();
        }

        public int DeleteDuLieu(string _roleid)
        {
            return DeleteDuLieu(new Role() { RoleID = _roleid });
        }

        public DataTable GetAllRole()
        {
            Role role = new Role();
            return role.LayDuLieuTable();
        }      
    }
}
