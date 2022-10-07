using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Component;

namespace Test.Repository
{
    public class DepartmentRepository
    {
        public int InsertDuLieu(Department department)
        {
            return department.Insert();
        }

        public int InsertDuLieu(string _departmentid, string _departmentname)
        {
            return InsertDuLieu(new Department() { DepartmentID = _departmentid, DepartmentName = _departmentname });
        }

        public int UpdateDuLieu(Department department)
        {
            return department.Update();
        }

        public int UpdateDuLieu(string _departmentid, string _departmentname)
        {
            return UpdateDuLieu(new Department() { DepartmentID = _departmentid, DepartmentName = _departmentname });
        }

        public int DeleteDuLieu(Department department)
        {
            return department.Delete();
        }

        public int DeleteDuLieu(string _departmentid)
        {
            return DeleteDuLieu(new Department() { DepartmentID = _departmentid });
        }

        public DataTable GetAllDepartment()
        {
            Department department = new Department();
            return department.LayDuLieuTable();
        }
    }
}
