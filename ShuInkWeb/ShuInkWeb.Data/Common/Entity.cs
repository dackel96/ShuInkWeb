using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuInkWeb.Data.Common
{
    public class Entity : IEntity
    {
        [Key]
        public Guid Id { get; init; }
        public DateTime CreatedOn
            => DateTime.UtcNow;
    }
}
