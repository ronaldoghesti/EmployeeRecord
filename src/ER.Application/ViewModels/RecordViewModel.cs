using ER.Domain.Enumerations;
using System;
using System.ComponentModel.DataAnnotations;

namespace ER.Application.ViewModels
{
    public class RecordViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "O nome do funcionário é obrigatório")]
        public string EmployeeName { get; set; }

        public int TypeId { get; set; }

        public string TypeDescription { get; set; }

        [Required(ErrorMessage = "Data e Hora são obrigatórios")]
        [DataType(DataType.DateTime, ErrorMessage = "Data e hora inválida")]
        public DateTime? CreatedAt { get; set; }
    }
}
