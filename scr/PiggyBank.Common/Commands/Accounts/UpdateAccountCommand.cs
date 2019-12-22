using PiggyBank.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PiggyBank.Common.Commands.Accounts
{
    public class UpdateAccountCommand
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public AccountType Type { get; set; }

        public string Currency { get; set; }

        public decimal Balance { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsArchived { get; set; }
    }
}
