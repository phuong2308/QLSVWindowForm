using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.SQLConnect;

namespace Test.Component
{
    public class Teacher
    {
        public string TeacherID { get; set; }
        public string TeacherName { get; set; }
        public int SexID { get; set; }
        public string DepartmentID { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string HomeTown { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public string Note { get; set; }

        KetNoiSql ketNoiSql = new KetNoiSql();
        public int Insert()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("teacherid", TeacherID);
            dic.Add("teachername", TeacherName);
            dic.Add("sexid", SexID);
            dic.Add("departmentid", DepartmentID);
            dic.Add("email", Email);
            dic.Add("phone", Phone);
            dic.Add("hometown", HomeTown);
            dic.Add("address", Address);
            dic.Add("image", Image);
            dic.Add("note", Note);
            return ketNoiSql.ExecuteNonQueryCommand("INSERT INTO Teacher (TeacherID,Teacher_Name,SexID,DepartmentID,Email,Phone,HomeTown,Address,Image,Note) VALUES (@teacherid,@teachername,@sexid,@departmentid,@email,@phone,@hometown,@address,@image,@note)", dic);
        }

        public int Update()
        {
            Dictionary<string,object> dic = new Dictionary<string,object>();
            dic.Add("teacherid",TeacherID);
            dic.Add("teachername",TeacherName);
            dic.Add("sexid",SexID);
            dic.Add("departmentid",DepartmentID);
            dic.Add("email",Email);
            dic.Add("phone",Phone);
            dic.Add("hometown",HomeTown);
            dic.Add("address",Address);
            dic.Add("image", Image);
            dic.Add("note",Note);
            return ketNoiSql.ExecuteNonQueryCommand("UPDATE Teacher SET Teacher_Name = @teachername,SexID = @sexid,DepartmentID = @departmentid,Email = @email,Phone = @phone,HomeTown = @hometown,Address = @address,Image = @image,Note = @note WHERE TeacherID = @teacherid",dic);
        }

        public int Delete()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("teacherid", TeacherID);
            return ketNoiSql.ExecuteNonQueryCommand("DELETE FROM Teacher WHERE TeacherID = @teacherid", dic);
        }

        public DataTable LayDuLieuTable()
        {
            return ketNoiSql.ExecuteDataTableCommand("SELECT TeacherID,Teacher_Name,Sex_Name,Department_Name,Email,Phone,HomeTown,Address,Image,Note FROM Teacher,Department,Sex WHERE Teacher.DepartmentID = Department.DepartmentID AND Sex.SexID = Teacher.SexID", new Dictionary<string, object>());
        }
        
        public DataTable GetTeacherTheoTeacherName(string _teachername)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("teachername",_teachername);
            return ketNoiSql.ExecuteDataTableCommand("SELECT TeacherID,Teacher_Name,Sex_Name,Department_Name,Email,Phone,HomeTown,Address,Image,Note FROM Teacher,Department,Sex WHERE Teacher.DepartmentID = Department.DepartmentID AND Sex.SexID = Teacher.SexID AND Teacher.Teacher_Name = @teachername", dic);
        }
    }
}
