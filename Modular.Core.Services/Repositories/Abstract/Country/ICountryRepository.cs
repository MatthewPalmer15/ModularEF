﻿using Modular.Core.Entities.Concrete;
using Modular.Core.Interfaces;

namespace Modular.Core.Services.Repositories.Abstract
{
    public interface ICountryRepository : IRepository<Country>, IDisposable
    {

        public Country New(string name, string? description = null, string? code = null);

    }
}
