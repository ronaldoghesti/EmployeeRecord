using Bogus;
using ER.Domain.Models;
using System;
using System.Linq;
using Xunit;

namespace ER.Tests
{
    public class DescribeEmployee
    {
        [Fact]
        public void Nao_deve_permitir_nome_nulo()
        {
            Assert.Throws<Exception>(() => new Employee(null));
        }

        [Fact]
        public void Nao_deve_permitir_nome_vazio()
        {
            Assert.Throws<Exception>(() => new Employee(string.Empty));
        }

        [Fact]
        public void Nao_deve_permitir_nome_com_apenas_espacos_em_branco()
        {
            Assert.Throws<Exception>(() => new Employee("      "));
        }

        [Fact]
        public void Deve_possuir_um_identificador_unico_para_cada_instancia()
        {
            var employess = new Faker<Employee>("pt_BR")
                .CustomInstantiator(f => new Employee(f.Name.FullName()))
                .Generate(10000);

            var hasDuplicateId = employess.GroupBy(e => e.Id).Any(g => g.Count() > 1);
            Assert.False(hasDuplicateId);
        }
    }
}
