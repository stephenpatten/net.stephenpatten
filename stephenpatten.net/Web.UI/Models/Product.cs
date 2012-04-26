using System;
using System.Text;
using Newtonsoft.Json;

namespace Web.UI.Models
{
    [Serializable]
    public class Product
    {
        private string _productAttributes;

        public string AveWeight { get; set; }

        public string BrandName { get; set; }

        public string CasePack { get; set; }

        public string Catalog { get; set; }

        public decimal CatalogId { get; set; }

        public decimal CategoryId { get; set; }

        public bool HasPicture { get; set; }

        // ReSharper disable InconsistentNaming
        public string INFO2 { get; set; }
        // ReSharper restore InconsistentNaming

        public string Info { get; set; }

        public bool IsOfflineSupplierItem { get; set; }

        public bool IsRebateItem { get; set; }

        public bool IsSpecialOrderItem { get; set; }

        public bool IsSpecialPriceItem { get; set; }

        public bool IsTieredPricingItem { get; set; }

        public string ItemNum { get; set; }

        public string ManufactureName { get; set; }

        public string ManufactureNum { get; set; }

        public decimal OffineSupplierId { get; set; }

        public string PackageRemarks { get; set; }

        public decimal Price { get; set; }

        public decimal PriceGroupId { get; set; }

        [JsonIgnore]
        public string ProductAttributes
        {
            get
            {
                var sb = new StringBuilder();
                if (!string.IsNullOrEmpty(Url))
                {
                    sb.Append("P");
                    sb.Append("~");
                }
                else
                {
                    sb.Append("X");
                    sb.Append("~");
                }

                if (IsSpecialOrderItem)
                {
                    sb.Append("SO");
                    sb.Append("~");
                }
                else
                {
                    sb.Append("X");
                    sb.Append("~");
                }

                if (IsSpecialPriceItem)
                {
                    sb.Append("SP");
                    sb.Append("~");
                }
                else
                {
                    sb.Append("X");
                    sb.Append("~");
                }

                if (IsRebateItem)
                {
                    sb.Append("R");
                    sb.Append("~");
                }
                else
                {
                    sb.Append("X");
                    sb.Append("~");
                }

                if (IsTieredPricingItem)
                {
                    sb.Append("T");
                    sb.Append("~");
                }
                else
                {
                    sb.Append("X");
                    sb.Append("~");
                }

                sb.Append("X");
                sb.Append("~");

                if (IsOfflineSupplierItem)
                {
                    sb.Append("O");
                    sb.Append("~");
                }
                else
                {
                    sb.Append("X");
                    sb.Append("~");
                }

                sb.Append("X");
                sb.Append("~");

                _productAttributes = sb.ToString();
                return _productAttributes.TrimEnd(new[] { '~' });
            }
            set
            {
                _productAttributes = value;
            }
        }

        public decimal ProductId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public string SupplierName { get; set; }

        // ReSharper disable InconsistentNaming
        public string UOM { get; set; }
        // ReSharper restore InconsistentNaming

        public string Upc { get; set; }

        public string Url { get; set; }
    }
}