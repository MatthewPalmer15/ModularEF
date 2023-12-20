

namespace Modular.Core.Api
{

    public interface IApiService
    {

        public Task<string> GetAsync(string url, Guid id);

    }

}
