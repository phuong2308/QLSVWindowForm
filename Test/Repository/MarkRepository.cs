using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Component;

namespace Test.Repository
{
    public class MarkRepository
    {
        public int InsertDuLieu(Mark mark)
        {
            return mark.Insert();
        }

        public int InsertDuLieu(string _subjectid, string _studentid, int _semester, string _note, float _midtermscore, float _finaltermscore, float _finalgrade)
        {
            return InsertDuLieu(new Mark() { SubjectID = _subjectid, StudentID = _studentid, Semester = _semester, Note = _note, MidtermScore = _midtermscore, FinaltermScore = _finaltermscore, FinalGrade = _finalgrade });
        }

        public int UpdateDuLieu(Mark mark)
        {
            return mark.Update();
        }

        public int UpdateDuLieu(int _markid, string _subjectid, string _studentid, int _semester, string _note, float _midtermscore, float _finaltermscore, float _finalgrade)
        {
            return UpdateDuLieu(new Mark() { MarkID = _markid, SubjectID = _subjectid, StudentID = _studentid, Semester = _semester, Note = _note, MidtermScore = _midtermscore, FinaltermScore = _finaltermscore, FinalGrade = _finalgrade });
        }

        public int DeleteDuLieu(Mark mark)
        {
            return mark.Delete();
        }

        public int DeleteDuLieu(int _markid)
        {
            return DeleteDuLieu(new Mark() { MarkID = _markid });
        }

        public DataTable GetAllMark()
        {
            Mark mark = new Mark();
            return mark.LayDuLieuTable();
        }
    }
}
