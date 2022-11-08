using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuInkWeb.Data.Common
{
    public abstract class BaseEntity : IBaseEntity
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public DateTime CreatedOn
            => DateTime.UtcNow;
    }
}
