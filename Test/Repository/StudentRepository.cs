using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Component;

namespace Test.Repository
{
    public class StudentRepository
    {
        public int InsertDuLieu(Student student)
        {
            return student.Insert();
        }

        public int InsertDuLieu(string _studentid, string _studentname, DateTime _birthday, int _sexid, string _address, string _classid, string _departmentid)
        {
            return InsertDuLieu(new Student() { StudentId = _studentid, StudentName = _studentname, BirthDay = _birthday, SexID = _sexid, Address = _address, ClassID = _classid, DepartmentID = _departmentid });
        }

        public int UpdateDuLieu(Student student)
        {
            return student.Update();
        }

        public int UpdateDuLieu(string _studentid, string _studentname, DateTime _birthday, int _sexid, string _address, string _classid, string _departmentid)
        {
            return UpdateDuLieu(new Student() { StudentId = _studentid, StudentName = _studentname, BirthDay = _birthday, SexID = _sexid, Address = _address, ClassID = _classid, DepartmentID = _departmentid });
        }

        public int DeleteDuLieu(Student student)
        {
            return student.Delete();
        }

        public int DeleteDuLieu(string _studentid)
        {
            return DeleteDuLieu(new Student() { StudentId = _studentid });
        }

        public DataTable GetAllStudent()
        {
            Student student = new Student();
            return student.GetAllStudent();
        }

        public Student GetStudentTheoID(string _studentid)
        {
            Student student = new Student();
            return student.GetAllStudentTheoID(_studentid);
        }

        public Student GetStudentNameTheoNameAndID(string _studentid, string _studentname)
        {
            Student student = new Student();
            return student.GetStudentNameTheoNameAndID(_studentid, _studentname);
        }

        public Student GetStudentTheoClassID(string _classid)
        {
            Student student = new Student();
            return student.GetStudentTheoClassID(_classid);
        }

        public DataTable FindStudentTheoName(string _studentname)
        {
            Student student = new Student();
            return student.FindStudentTheoName(_studentname);
        }
    }
}
