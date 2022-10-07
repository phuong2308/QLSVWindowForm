using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.SQLConnect;

namespace Test.Component
{
    public class Mark
    {
        public int MarkID { get; set; }
        public string SubjectID { get; set; }
        public string StudentID { get; set; }
        public int Semester { get; set; }
        public string Note { get; set; }
        public float MidtermScore { get; set; }
        public float FinaltermScore { get; set; }
        public float FinalGrade { get; set; }

        KetNoiSql ketNoiSql = new KetNoiSql();

        public int Insert()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("subjectid", SubjectID);
            dic.Add("studentid", StudentID);
            dic.Add("semester", Semester);
            dic.Add("note", Note);
            dic.Add("midtermscore", MidtermScore);
            dic.Add("finaltermscore", FinaltermScore);
            dic.Add("finalgrade", FinalGrade);
            return ketNoiSql.ExecuteNonQueryCommand("INSERT INTO Mark (SubjectID,StudentID,Semester,Note,MidtermScore,FinalScore,FinalGrade) VALUES (@subjectid,@studentid,@semester,@note,@midtermscore,@finaltermscore,@finalgrade)", dic);
        }

        public int Update()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("subjectid", SubjectID);
            dic.Add("studentid", StudentID);
            dic.Add("semester", Semester);
            dic.Add("note", Note);
            dic.Add("midtermscore", MidtermScore);
            dic.Add("finaltermscore", FinaltermScore);
            dic.Add("finalgrade", FinalGrade);
            dic.Add("markid", MarkID);
            return ketNoiSql.ExecuteNonQueryCommand("UPDATE Mark SET SubjectID = @subjectid,StudentID = @studentid,Semester = @semester,Note = @note,MidtermScore = @midtermscore,FinalScore = @finaltermscore,FinalGrade = @finalgrade WHERE MarkID = @markid", dic);
        }

        public int Delete()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("markid", MarkID);
            return ketNoiSql.ExecuteNonQueryCommand("DELETE FROM Mark WHERE MarkID = @markid", dic);
        }

        public DataTable LayDuLieuTable()
        {
            return ketNoiSql.ExecuteDataTableCommand("SELECT Mark.MarkID,Student.StudentID,Student.Student_Name,Department.Department_Name,Class.Class_Name,Subject.Subject_Name,Mark.Semester,Mark.Note,Mark.MidtermScore,Mark.FinalScore,Mark.FinalGrade FROM Mark,Department,Class,Student,Subject WHERE Mark.StudentID = Student.StudentID AND Subject.SubjectID = Mark.SubjectID AND Class.ClassID = Student.ClassID AND Department.DepartmentID = Class.DepartmentID", new Dictionary<string, object>());
        }  
    }
}
