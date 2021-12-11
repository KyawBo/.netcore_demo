using System.Threading.Tasks;

namespace API.Infrastructure
{
    public interface IFileImport
    {
        Task ImportAsync(string file);
    }
}
