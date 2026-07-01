using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace CraftIQ.Domain.Entites
{
    public class Category:BaseEntity
    {
        public Guid CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public List<Product>? Products { get; set; } = new();
        //for ef core
        public Category() { }
        
        public Category(string Name,string Description)
        {
            CategoryId = Guid.NewGuid();
            this.Name = Name;
            this.Description = Description;
            CreatedOn = DateTimeOffset.Now;
            ModifiedOn = DateTimeOffset.Now;
            CreatedBy = Guid.Empty;
            ModifiedBy = Guid.Empty;
        }

        /// Method used for coping in update
        public void UpdateCategory(string Name, string Description,Guid modifiedBy)
        {
            this.Name = Name;
            this.Description = Description;
            ModifiedOn = DateTimeOffset.Now;
            ModifiedBy = modifiedBy;
        }

    }
}
