﻿using Modular.Core.Entities;
using Modular.Core.Interfaces;

namespace Modular.Core.Services.Repositories.Abstract
{
    public interface IContactRepository : IRepository<Contact>, IDisposable
    {
        public Contact New(string forename, string surname, string email);

        public Contact New(Func<Contact, bool> predicate);

    }
}
