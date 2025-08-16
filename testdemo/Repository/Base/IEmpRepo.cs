using testdemo.Models;

namespace testdemo.Repository.Base
{
    public interface IEmpRepo : IRepository<Employee> 
    { 

        void setPayRoll(Employee employee);

        decimal getSalary(Employee employee); 



    }
}
