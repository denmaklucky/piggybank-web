using PiggyBank.Common.Enums;
using PiggyBank.Model.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace PiggyBank.Model.Models
{
    public class Operation : EntityBase, IBaseModel
    {
        [Key]
        public int Id { get; set; }

        public string Comment { get; set; }

        public OperationType Type { get; set; }
    }
}
