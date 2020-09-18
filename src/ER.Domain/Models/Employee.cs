using ER.Domain.Extensions;
using System;
using System.Collections.Generic;

namespace ER.Domain.Models
{
    public class Employee : Entity
    {
        protected Employee() { }

        public Employee(string name)
        {
            if (name.IsEmpty())
            {
                throw new Exception("O nome do empregado é obrigatório");
            }

            Name = name;
        }

        public string Name { get; private set; }

        public IEnumerable<Record> Records{ get; set; }
    }
}
