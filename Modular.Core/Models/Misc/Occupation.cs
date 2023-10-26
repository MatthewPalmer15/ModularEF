﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Core.Models.Misc
{
    public class Occupation : BaseEntity
    {

        #region "  Properties  "

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        #endregion

    }
}