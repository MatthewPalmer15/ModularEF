using Microsoft.Extensions.Configuration;
using Modular.Core.Entity;
using Modular.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Modular.Core.Config
{
    public interface IConfigurationRepository
    {
        string GetValue(string key);

    }
}
