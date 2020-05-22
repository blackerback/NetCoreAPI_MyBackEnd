using MyBackEnd.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBackEnd.Core.Entities.Concrete
{
    public class User:IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
        public List<OperationClaims> OperationClaims { get; set; }
    }
}
