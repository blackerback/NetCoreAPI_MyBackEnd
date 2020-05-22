using MyBackEnd.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBackEnd.Core.Entities.Concrete
{
    public class OperationClaims:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
