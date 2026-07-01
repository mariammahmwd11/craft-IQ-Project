using Domain.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CraftIQ.Domain.Entites
{
    public class Transaction:BaseEntity
    {
        public Guid TransactionId { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
        public int Quantity { get; set; }
        public int TransactionType { get; set; }
        public string Notes { get; set; }
        
        public List<Product> products { get; set; } = new();
        public Transaction(){ }

        public Transaction(Guid employeeId,
                           DateTimeOffset transactionDate,
                           int quantity,
                           int transactionType,
                           string notes)
        {
            TransactionId = Guid.NewGuid();
            EmployeeId = employeeId;
            TransactionDate = transactionDate;
            Quantity = quantity;
            Notes = notes;
            TransactionType = transactionType;
            CreatedBy=employeeId;
            ModifiedBy = Guid.Empty;
            CreatedOn = DateTimeOffset.Now;
            ModifiedOn = DateTimeOffset.Now;


        }

        public void UpdateTransaction(Guid employeeId,
                                      DateTimeOffset transactionDate,
                                      int quantity,
                                      int transactionType,
                                      string notes)
        {
            EmployeeId = employeeId;
            TransactionDate = transactionDate;
            Quantity = quantity;
            Notes = notes;
            TransactionType = transactionType;
            ModifiedBy = employeeId;
            ModifiedOn = DateTimeOffset.Now;
        }





    }
}
