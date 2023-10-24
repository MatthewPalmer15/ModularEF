﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Core.Models.Config
{
    public class Configuration : ModularBaseEntity
    {

        public string Key { get; set; } = string.Empty;

        public string Value { get; set; } = string.Empty;

    }
}
