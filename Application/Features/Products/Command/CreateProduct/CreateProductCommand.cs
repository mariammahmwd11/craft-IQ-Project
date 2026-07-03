using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommand :IRequest<Guid>
    {
        // add properties that will send cause in controllwer we send command itself to handler and handler will send it to repository to save in database
        //you can use the DTO but it is not necessary because we can use the command itself as DTO without mapping it to another DTO class
          public int ProductId { get; set; } 
        public string Name { get; set; }
     
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public float Length { get; set; }
        public float Width { get; set; }
        public decimal TaxCost { get; set; }
        public decimal ProfitPerUnit { get; set; }
        public decimal ProductionCost { get; set; }
        public int CategoryId { get; set; }

        public int InventoryId { get; set; }

        public int TransactionId { get; set; }
      
    }
}
