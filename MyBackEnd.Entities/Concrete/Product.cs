using MyBackEnd.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBackEnd.Entities.Concrete
{
    public class Product:IEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }

        

    }
}
