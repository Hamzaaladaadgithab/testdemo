using Microsoft.IdentityModel.Tokens;
using testdemo.Data;
using testdemo.Models;
using testdemo.Repository.Base;

namespace testdemo.Repository
{
    public class EmpRepo : MainRepository<Employee>, IEmpRepo
    {
        public EmpRepo(AppDbContext context) : base(context)
        {   
             _context = context;

        }   

        private readonly AppDbContext _context;

        public decimal getSalary(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void setPayRoll(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
