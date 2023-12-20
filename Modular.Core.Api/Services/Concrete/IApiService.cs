using System.Net.Http.Headers;
using System;
using Microsoft.Extensions.Configuration;

namespace Modular.Core.Api
{

    public interface IApiService
    {

        public Task<string> GetAsync(string url, Guid id);

    }

}
