using System;
using System.Threading.Tasks;

namespace Feetur.Shared
{
    public interface IFeatureHub
    {
        Task Reply(Guid user, Guid messageId);
    }
}