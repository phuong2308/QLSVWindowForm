using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.SQLConnect;

namespace Test.Component
{
    public class Class
    {
        public string ClassID { get; set; }
        public string ClassName { get; set; }
        public string DepartmentID { get; set; }

        KetNoiSql ketNoiSql = new KetNoiSql();

        public int Insert()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("classid", ClassID);
            dic.Add("classname", ClassName);
            dic.Add("departmentid", DepartmentID);
            return ketNoiSql.ExecuteNonQueryCommand("INSERT INTO Class (ClassID,Class_Name,DepartmentID) VALUES (@classid,@classname,@departmentid)", dic);
        }

        public int Update()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("classid", ClassID);
            dic.Add("classname", ClassName);
            dic.Add("departmentid", DepartmentID);
            return ketNoiSql.ExecuteNonQueryCommand("UPDATE Class SET Class_Name = @classname,DepartmentID = @departmentid WHERE ClassID = @classid", dic);
        }

        public int Delete()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("classid", ClassID);
            return ketNoiSql.ExecuteNonQueryCommand("DELETE FROM Class WHERE ClassID = @classid", dic);
        }

        public DataTable LayDuLieuTable()
        {
            return ketNoiSql.ExecuteDataTableCommand("SELECT Class.ClassID,Class.Class_Name,Department.Department_Name FROM Class,Department WHERE Class.DepartmentID = Department.DepartmentID", new Dictionary<string, object>());
        }

        public Class KiemTraClassForDelete(string _departmentid)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("departmentid", _departmentid);
            List<object[]> list = ketNoiSql.ExecuteDataReaderCommand("SELECT ClassID FROM Class WHERE DepartmentID = @departmentid", dic);
            if (list == null || list.Count <= 0)
            {
                return null;
            }
            object[] arr = list[0];
            return new Class() { ClassID = (string)arr[0] };
        }

        public DataTable LayClassTheoDepartmentID(string departmentid)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("departmentid", departmentid);
            return ketNoiSql.ExecuteDataTableCommand("SELECT * FROM Class WHERE DepartmentID = @departmentid", dic);
        }
    }
}
