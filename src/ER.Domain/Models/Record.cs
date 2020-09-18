using ER.Domain.Enumerations;
using System;
using System.ComponentModel;

namespace ER.Domain.Models
{
    public class Record : Entity
    {
        protected Record() { }

        public Record(Employee employee, RecordTypeEnumeration type, DateTime createdAt)
        {
            if(createdAt == default)
            {
                throw new Exception("Deve ser informada uma data e hora válida");
            }

            Employee = employee ?? throw new Exception("Deve ser informado o funcionário");
            Type = type ?? throw new Exception("Deve ser informado o tipo de registro");
            CreatedAt = createdAt;
        }

        public RecordTypeEnumeration Type { get; set; }
        public DateTime CreatedAt { get; private set; }
        public Employee Employee { get; set; }
    }
}
