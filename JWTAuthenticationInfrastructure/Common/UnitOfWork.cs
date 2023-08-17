using JWTAuthentication.Application.Common;
using JWTAuthentication.Application.Contract;
using JWTAuthentication.Data.Settings;
using JWTAuthenticationInfrastructure.AccountRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTAuthenticationInfrastructure.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmsContext emsContext;
        private bool _disposed;

        public UnitOfWork(EmsContext emsContext)
        {
            this.emsContext = emsContext;
            User = new AccountsRepository(this.emsContext);
        }

        public async void Commit()
        {
            await this.emsContext.SaveChangesAsync();
        }

        public IAccountsRepository User { get; set; }

        public void Rollback()
        {
            foreach (var entry in this.emsContext.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }

        public IGenericRepositoryBase<T> GenericRepositoryBase<T>() where T : class
        {
            return new GenericRepositoryBase<T>(this.emsContext);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.emsContext.Dispose();

                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

      
    }
}
