using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Core.Reports.Structures.Quotes
{
    public struct Quote
    {

        public string QuoteNumber { get; set; }

        public DateOnly QuoteDate { get; set; }

        public Guid CompanyId { get; set; }

        public List<QuoteItem> Items { get; set; }

        public bool ExcludesVAT { get; set; }

        public int DayLimit { get; set; } 

    }
}
