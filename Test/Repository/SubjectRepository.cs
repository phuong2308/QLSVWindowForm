using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Component;

namespace Test.Repository
{
    public class SubjectRepository
    {
        public int InsertDuLieu(Subject subject)
        {
            return subject.Insert();
        }

        public int InsertDuLieu(string _subjectid, string _subjectname, int _teachingunit, int _credits)
        {
            return InsertDuLieu(new Subject() { SubjectID = _subjectid, SubjectName = _subjectname, TeachingUnit = _teachingunit, Credits = _credits });
        }

        public int UpdateDuLieu(Subject subject)
        {
            return subject.Update();
        }

        public int UpdateDuLieu(string _subjectid, string _subjectname, int _teachingunit, int _credits)
        {
            return UpdateDuLieu(new Subject() { SubjectID = _subjectid,SubjectName = _subjectname,TeachingUnit = _teachingunit,Credits = _credits});
        }

        public int DeleteDuLieu(Subject subject)
        {
            return subject.Delete();
        }

        public int DeleteDuLieu(string _subjectid)
        {
            return DeleteDuLieu(new Subject() { SubjectID = _subjectid});
        }

        public DataTable GetAllSubject()
        {
            Subject subject = new Subject();
            return subject.LayDuLieuTable();
        }
    }
}
