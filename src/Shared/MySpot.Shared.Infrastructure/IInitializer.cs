using System.Threading.Tasks;

namespace MySpot.Shared.Infrastructure;

public interface IInitializer
{
    Task InitAsync();
}