using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuInkWeb.Core.Models.HappeningModels
{
    public class HappeningAddModel : HappeningViewModel
    {
        public MemoryStream File { get; set; } = null!;
    }
}
