using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Component;

namespace Test.Repository
{
    public class TeacherRepository
    {
        public int InsertDuLieu(Teacher teacher)
        {
            return teacher.Insert();
        }

        public int InsertDuLieu(string _teacherid, string _teachername, int _sexid, string _departmentid, string _email, string _phone, string _hometown, string _address, string _image, string _note)
        {
            return InsertDuLieu(new Teacher() { TeacherID = _teacherid, TeacherName = _teachername, SexID = _sexid, DepartmentID = _departmentid, Email = _email, Phone = _phone, HomeTown = _hometown, Address = _address, Image = _image, Note = _note });
        }

        public int UpdateDuLieu(Teacher teacher)
        {
            return teacher.Update();
        }

        public int UpdateDuLieu(string _teacherid, string _teachername, int _sexid, string _departmentid, string _email, string _phone, string _hometown, string _address, string _image, string _note)
        {
            return UpdateDuLieu(new Teacher() { TeacherID = _teacherid, TeacherName = _teachername, SexID = _sexid, DepartmentID = _departmentid, Email = _email, Phone = _phone, HomeTown = _hometown, Address = _address, Image = _image, Note = _note });
        }

        public int DeleteDuLieu(Teacher teacher)
        {
            return teacher.Delete();
        }

        public int DeleteDuLieu(string _teacherid)
        {
            return DeleteDuLieu(new Teacher() { TeacherID = _teacherid});
        }

        public DataTable GetAllTeacher()
        {
            Teacher teacher = new Teacher();
            return teacher.LayDuLieuTable();
        }

        public DataTable GetTeacherTheoTeacherName(string _teachername)
        {
            Teacher teacher = new Teacher();
            return teacher.GetTeacherTheoTeacherName(_teachername);
        }
    }
}
