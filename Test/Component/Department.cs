using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.SQLConnect;

namespace Test.Component
{
    public class Department
    {
        public string DepartmentID { get; set; }
        public string DepartmentName { get; set; }

        KetNoiSql ketNoiSql = new KetNoiSql();

        public int Insert()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("departmentid", DepartmentID);
            dic.Add("departmentname", DepartmentName);
            return ketNoiSql.ExecuteNonQueryCommand("INSERT INTO Department (DepartmentID,Department_Name) VALUES (@departmentid,@departmentname)", dic);
        }

        public int Update()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("departmentid", DepartmentID);
            dic.Add("departmentname", DepartmentName);
            return ketNoiSql.ExecuteNonQueryCommand("UPDATE Department SET Department_Name = @departmentname WHERE DepartmentID = @departmentid", dic);
        }

        public int Delete()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("departmentid", DepartmentID);
            return ketNoiSql.ExecuteNonQueryCommand("DELETE FROM Department WHERE DepartmentID = @departmentid", dic);
        }

        public DataTable LayDuLieuTable()
        {
            return ketNoiSql.ExecuteDataTableCommand("SELECT * FROM Department", new Dictionary<string, object>());
        }
    }
}
