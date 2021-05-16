using BL.Reposatories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        int Commit();

        ProductRepository Product { get; }
        CategoryReopsitory Category { get; }
        OrderRepository Order { get; }
        OrderDetailesRepository OrderDetail { get; }
        AccountRepository Account { get; }
        RoleRepository Role { get; }
    }
}
