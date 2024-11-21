using System.Collections.Generic;
using System.Threading.Tasks;
using СurrencyApp.Model;

namespace СurrencyApp.Interfaces
{
    public interface IFileService
    {
        Task<bool> SaveJsonFile(string savePath, string json);
        Task<IEnumerable<SaveRate>> OpenJsonFile(string filePath);
    }
}
