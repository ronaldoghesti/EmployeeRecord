using ER.Domain.Enumerations;
using ER.Domain.Models;
using System;
using Xunit;

namespace ER.Tests
{
    public class DescribeRecordType
    {
        [Fact]
        public void Deve_possuir_tipo_entrada_para_id_1()
        {
            Assert.Equal(RecordTypeEnumeration.Input, Enumeration.GetById<RecordTypeEnumeration>(1));
        }

        [Fact]
        public void Deve_possuir_a_descricao_do_tipo_Entrada()
        {
            Assert.Equal("Entrada", RecordTypeEnumeration.Input.Name);
        }

        [Fact]
        public void Deve_possuir_a_descricao_do_tipo_Saida()
        {
            Assert.Equal("Saída", RecordTypeEnumeration.Output.Name);
        }

        [Fact]
        public void Deve_possuir_tipo_saida_para_id_2()
        {
            Assert.Equal(RecordTypeEnumeration.Output, Enumeration.GetById<RecordTypeEnumeration>(2));
        }

        [Fact]
        public void Nao_deve_permitir_tipos_diferentes_de_entrada_ou_saida()
        {
            Assert.Throws<InvalidOperationException>(() => Enumeration.GetById<RecordTypeEnumeration>(3));
            Assert.Throws<InvalidOperationException>(() => Enumeration.GetById<RecordTypeEnumeration>(4));
            Assert.Throws<InvalidOperationException>(() => Enumeration.GetById<RecordTypeEnumeration>(5));
            Assert.Throws<InvalidOperationException>(() => Enumeration.GetById<RecordTypeEnumeration>(0));
            Assert.Throws<InvalidOperationException>(() => Enumeration.GetById<RecordTypeEnumeration>(10));
            Assert.Throws<InvalidOperationException>(() => Enumeration.GetById<RecordTypeEnumeration>(8));
            Assert.Throws<InvalidOperationException>(() => Enumeration.GetById<RecordTypeEnumeration>(9));
        }
    }
}
