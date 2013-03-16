using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;
using Web.UI.Models;

namespace Web.UI.Infrastructure.Indexes
{
    public class Products_Index : AbstractIndexCreationTask<Product>
    {
        public Products_Index()
        {
            Map = products => from p in products
                              select new
                              {
                                  p.ItemNum,
                                  p.BrandName,
                                  p.ProductName,
                                  p.Catalog,
                                  p.UOM,
                                  p.CasePack,
                                  p.AveWeight,
                                  p.CatalogId,
                                  p.HasPicture,
                                  p.INFO2,
                                  p.IsOfflineSupplierItem,
                                  p.IsRebateItem,
                                  p.IsSpecialOrderItem,
                                  p.IsSpecialPriceItem,
                                  p.Price
                              };

            Sort(x => x.Price, SortOptions.Double);

            Indexes.Add(x => x.INFO2, FieldIndexing.Analyzed);
        }
    }
}