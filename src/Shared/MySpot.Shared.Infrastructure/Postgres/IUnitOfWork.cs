using System;
using System.Threading.Tasks;

namespace MySpot.Shared.Infrastructure.Postgres;

public interface IUnitOfWork
{
    Task ExecuteAsync(Func<Task> action);
}