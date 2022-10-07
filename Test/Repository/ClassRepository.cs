using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Component;

namespace Test.Repository
{
    public class ClassRepository
    {
        public int InsertDuLieu(Class clas)
        {
            return clas.Insert();
        }

        public int InsertDuLieu(string _classid, string _classname, string _departmentid)
        {
            return InsertDuLieu(new Class() { ClassID = _classid, ClassName = _classname, DepartmentID = _departmentid });
        }

        public int UpdateDuLieu(Class clas)
        {
            return clas.Update();
        }

        public int UpdateDuLieu(string _classid, string _classname, string _departmentid)
        {
            return UpdateDuLieu(new Class() { ClassID = _classid, ClassName = _classname, DepartmentID = _departmentid });
        }

        public int DeleteDuLieu(Class clas)
        {
            return clas.Delete();
        }

        public int DeleteDuLieu(string _classid)
        {
            return DeleteDuLieu(new Class() { ClassID = _classid });
        }

        public DataTable GetAllClass()
        {
            Class clas = new Class();
            return clas.LayDuLieuTable();
        }

        public Class KiemTraClassForDelete(string _departmentid)
        {
            Class clas = new Class();
            return clas.KiemTraClassForDelete(_departmentid);
        }

        public DataTable GetClassTheoDepartmentID(string departmentid)
        {
            Class clas = new Class();
            return clas.LayClassTheoDepartmentID(departmentid);
        }
    }
}
