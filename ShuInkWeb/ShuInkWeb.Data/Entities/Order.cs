using Microsoft.EntityFrameworkCore;
using ShuInkWeb.Data.Common;
using ShuInkWeb.Data.Entities.Clients;
using ShuInkWeb.Data.Entities.Merchandises;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShuInkWeb.Data.Constants.MerchandiseConstants;
namespace ShuInkWeb.Data.Entities
{
    public class Order : BaseDeletableModel<Guid>
    {
        [Precision(PrecisionDigits, PrecisionDigitsAfterSign)]
        public decimal TotalPrize { get; set; }

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public string ClientId { get; set; } = null!;

        public Client Client { get; set; } = null!;

        public IEnumerable<Merchandise> Merchandises { get; set; } = new HashSet<Merchandise>();
    }
}
