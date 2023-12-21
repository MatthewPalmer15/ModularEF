using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Core.Reports.Structures.Quotes
{
    public struct QuoteItem
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice
        {
            get
            {
                return UnitPrice * Quantity;
            }
        }

    }
}
