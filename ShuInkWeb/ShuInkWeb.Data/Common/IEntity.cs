﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuInkWeb.Data.Common
{
    public interface IEntity
    {
        public Guid Id { get; init; }

        public DateTime CreatedOn { get; }
    }
}
