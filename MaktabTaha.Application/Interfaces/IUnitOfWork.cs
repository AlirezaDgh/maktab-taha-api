using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        Task ExecuteInTransactionAsync(Func<CancellationToken, Task> action,
            CancellationToken cancellationToken = default);
    }
}
