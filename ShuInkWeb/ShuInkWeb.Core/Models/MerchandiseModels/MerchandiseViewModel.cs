namespace ShuInkWeb.Core.Models.MerchandiseModels
{
    public class MerchandiseViewModel
    {
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string Type { get; set; } = null!;

        public bool InStock { get; set; }
    }
}
