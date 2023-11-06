﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Core.Interfaces
{
    public interface IBaseEntity
    {

        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }

    }
}
