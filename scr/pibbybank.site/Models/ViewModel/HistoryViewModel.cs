using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace piggybank.site.Models.ViewModel
{
    public class HistoryViewModel
    {
        public IEnumerable<TransactionsOfDay> TransactionsInDay { get; set; }
    }
}
