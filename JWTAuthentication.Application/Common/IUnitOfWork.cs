using JWTAuthentication.Application.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTAuthentication.Application.Common
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
        IGenericRepositoryBase<T> GenericRepositoryBase<T>() where T : class;
        IAccountsRepository User { get; set; }

    }
}
