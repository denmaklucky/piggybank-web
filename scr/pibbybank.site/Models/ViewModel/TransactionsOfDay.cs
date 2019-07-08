using piggybank.dal.DTO;
using System;
using System.Collections.Generic;

namespace piggybank.site.Models.ViewModel
{
    public class TransactionsOfDay
    {
        public DateTime Date { get; set; }

        public IEnumerable<TransactionDto> Transactions { get; set; }
    }
}
