using Microsoft.AspNetCore.Razor.Language;
using testdemo.Models;

namespace testdemo.Repository.Base
{
    public interface IUintOfWork : IDisposable 
    { 
        IRepository<Category> categoryes { get; }

        IRepository<Item> items { get; }

        IEmpRepo employees { get; }

        int CommitChanges(); 
    } 
}

