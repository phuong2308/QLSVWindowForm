using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.SQLConnect;

namespace Test.Component
{
    public class Student
    {
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime BirthDay { get; set; }
        public int SexID { get; set; }
        public string Address { get; set; }
        public string DepartmentID { get; set; }
        public string ClassID { get; set; }

        KetNoiSql ketNoiSql = new KetNoiSql();

        public int Insert()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("studentid", StudentId);
            dic.Add("studentname", StudentName);
            dic.Add("birthday", BirthDay);
            dic.Add("sexid", SexID);
            dic.Add("address", Address);
            dic.Add("classid", ClassID);
            dic.Add("departmentid", DepartmentID);
            return ketNoiSql.ExecuteNonQueryCommand("INSERT INTO Student (StudentID,Student_Name,BirthDay,SexID,Address,ClassID,DepartmentID) VALUES (@studentid,@studentname,@birthday,@sexid,@address,@classid,@departmentid)", dic);
        }

        public int Update()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("studentid", StudentId);
            dic.Add("studentname", StudentName);
            dic.Add("birthday", BirthDay);
            dic.Add("sexid", SexID);
            dic.Add("address", Address);
            dic.Add("classid", ClassID);
            dic.Add("departmentid", DepartmentID);
            return ketNoiSql.ExecuteNonQueryCommand("UPDATE Student SET Student_Name = @studentname,BirthDay = @birthday,SexID = @sexid,Address = @address,ClassID = @classid,DepartmentID = @departmentid WHERE StudentID = @studentid", dic);
        }

        public int Delete()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("studentid", StudentId);
            return ketNoiSql.ExecuteNonQueryCommand("DELETE FROM Student WHERE StudentID = @studentid", dic);
        }
        
        public DataTable GetAllStudent()
        {
            return ketNoiSql.ExecuteDataTableCommand("SELECT Student.StudentID,Student.Student_Name,Student.BirthDay,Sex.Sex_Name,Student.Address,Class.Class_Name,Department.Department_Name FROM Student,Sex,Class,Department WHERE Sex.SexID = Student.SexID AND Student.ClassID = Class.ClassID AND Class.DepartmentID = Student.DepartmentID AND Department.DepartmentID = Class.DepartmentID", new Dictionary<string, object>());
        }

        public Student GetAllStudentTheoID(string _studentid)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("studentid", _studentid);
            List<object[]> list = ketNoiSql.ExecuteDataReaderCommand("SELECT StudentID FROM Student WHERE StudentID = @studentid", dic);
            if (list == null || list.Count <= 0)
            {
                return null;
            }
            object[] arr = list[0];
            return new Student() { StudentId = (string)arr[0] };
        }

        public Student GetStudentNameTheoNameAndID(string _studentid, string _studentname)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("studentid", _studentid);
            dic.Add("studentname", _studentname);    
            List<object[]> list = ketNoiSql.ExecuteDataReaderCommand("SELECT Student_Name FROM Student WHERE Student_Name = @studentname AND StudentID = @studentid", dic);
            if (list == null || list.Count <= 0)
            {
                return null;
            }
            object[] arr = list[0];
            return new Student() { StudentName = (string)arr[0] };
        }
     
        public Student GetStudentTheoClassID(string _classid)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("classid", _classid);
            List<object[]> list = ketNoiSql.ExecuteDataReaderCommand("SELECT Student.StudentID FROM Student,Class WHERE Class.ClassID = Student.ClassID AND Class.ClassID = @classid;", dic);
            if (list == null || list.Count <= 0)
            {
                return null;
            }
            object[] arr = list[0];
            return new Student() { StudentId = (string)arr[0] };
        }

        public DataTable FindStudentTheoName(string _studentname)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("studentname", _studentname);
            return ketNoiSql.ExecuteDataTableCommand("SELECT Mark.MarkID,Student.StudentID,Student.Student_Name,Department.Department_Name,Class.Class_Name,Subject.Subject_Name,Mark.Semester,Mark.Note,Mark.MidtermScore,Mark.FinalScore,Mark.FinalGrade FROM Mark,Department,Class,Student,Subject WHERE Mark.StudentID = Student.StudentID AND Subject.SubjectID = Mark.SubjectID AND Class.ClassID = Student.ClassID AND Department.DepartmentID = Class.DepartmentID AND Student_Name = @studentname", dic);
        }
    }
}
