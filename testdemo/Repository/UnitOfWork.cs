using testdemo.Data;
using testdemo.Models;
using testdemo.Repository.Base;

namespace testdemo.Repository
{
    public class UnitOfWork : IUintOfWork
    {  

        public UnitOfWork(AppDbContext context) {  

            _context = context;
            categoryes = new MainRepository<Category>(_context);
            items = new MainRepository<Item>(_context); 

            employees  = new  EmpRepo(_context);

        } 

        private readonly AppDbContext _context;

        public IRepository<Category> categoryes  { get; private set; }

        public IRepository<Item> items { get; private set; }

        public IEmpRepo employees { get; private set; }

        public int CommitChanges()
        {
           return _context.SaveChanges(); 
        }

        public void Dispose()
        {  

            _context.Dispose();
        }
    }
}
