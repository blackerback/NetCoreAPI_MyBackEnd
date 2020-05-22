using MyBackEnd.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBackEnd.Entities.Concrete
{
    public class Log:IEntity
    {
        public int Id { get; set; }
        public string Detail { get; set; }
        public DateTime Date { get; set; }
        public string Audit { get; set; }
    }
}
