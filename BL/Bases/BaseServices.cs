using AutoMapper;
using BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Bases
{
    public class BaseServices : IDisposable
    {

        protected IUnitOfWork TheUnitOfWork { get; set; }

        protected readonly IMapper mapper = Configration.ConfigureMapper.mapper;
        

        public BaseServices()
        {
            TheUnitOfWork = new UnitOfWork();
        }

        public void Dispose()
        {
            TheUnitOfWork.Dispose();
        }

    }
}
