using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entites
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }
    }
}
