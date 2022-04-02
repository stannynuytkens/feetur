using System.Threading.Tasks;
using Feetur.Shared.Models;

namespace Feetur.Shared
{
    public interface IFeatureClient
    {
        Task Notify(Feature feature);
    }
}