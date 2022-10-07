using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.SQLConnect;

namespace Test.Component
{
    public class Role
    {
        public string RoleID { get; set; }
        public string RoleName { get; set; }

        KetNoiSql ketNoiSql = new KetNoiSql();

        public int Insert()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("roleid", RoleID);
            dic.Add("rolename", RoleName);
            return ketNoiSql.ExecuteNonQueryCommand("INSERT INTO Role (RoleID,RoleName) VALUES (@roleid,@rolename)", dic);
        }

        public int Update()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("roleid", RoleID);
            dic.Add("rolename", RoleName);
            return ketNoiSql.ExecuteNonQueryCommand("UPDATE Role SET RoleName = @rolename WHERE RoleID = @roleid", dic);
        }

        public int Delete()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("roleid", RoleID);
            return ketNoiSql.ExecuteNonQueryCommand("DELETE FROM Role WHERE RoleID = @roleid", dic);
        }

        public DataTable LayDuLieuTable()
        {
            return ketNoiSql.ExecuteDataTableCommand("SELECT * FROM Role", new Dictionary<string, object>());
        }        
    }
}
