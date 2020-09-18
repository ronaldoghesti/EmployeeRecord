using ER.Domain.Enumerations;
using ER.Domain.Models;
using System;
using Xunit;

namespace ER.Tests
{
    public class DescribeRecord
    {
        [Fact]
        public void Nao_deve_permitir_instancia_nula_para_usuario()
        {
            Assert.Throws<Exception>(() => new Domain.Models.Record(null, RecordTypeEnumeration.Input, DateTime.Now));
        }

        [Fact]
        public void Nao_deve_permitir_instancia_nula_para_tipo_de_registro()
        {
            Assert.Throws<Exception>(() => new Domain.Models.Record(new Employee("User"), null, DateTime.Now));
        }

        [Fact]
        public void Nao_deve_permitir_nome_com_apenas_espacos_em_branco()
        {
            Assert.Throws<Exception>(() => new Domain.Models.Record(new Employee("User"), RecordTypeEnumeration.Input, default));
        }
    }
}
