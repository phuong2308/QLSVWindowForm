using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.SQLConnect;

namespace Test.Component
{
    public class Subject
    {
        public string SubjectID { get; set; }
        public string SubjectName { get; set; }
        public int TeachingUnit { get; set; }
        public int Credits { get; set; }

        KetNoiSql ketNoiSql = new KetNoiSql();

        public int Insert()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("subjectid", SubjectID);
            dic.Add("subjectname", SubjectName);
            dic.Add("teachingunit", TeachingUnit);
            dic.Add("credits", Credits);
            return ketNoiSql.ExecuteNonQueryCommand("INSERT INTO Subject (SubjectID,Subject_Name,TeachingUnit,Credits) VALUES (@subjectid,@subjectname,@teachingunit,@credits)", dic);
        }

        public int Update()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("subjectid", SubjectID);
            dic.Add("subjectname", SubjectName);
            dic.Add("teachingunit", TeachingUnit);
            dic.Add("credits", Credits);
            return ketNoiSql.ExecuteNonQueryCommand("UPDATE Subject SET Subject_Name = @subjectname,TeachingUnit = @teachingunit,Credits = @credits WHERE SubjectID = @subjectid", dic);
        }

        public int Delete()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("subjectid", SubjectID);
            return ketNoiSql.ExecuteNonQueryCommand("DELETE FROM Subject WHERE SubjectID = @subjectid", dic);
        }

        public DataTable LayDuLieuTable()
        {
            return ketNoiSql.ExecuteDataTableCommand("SELECT * FROM Subject", new Dictionary<string, object>());
        }
    }
}
