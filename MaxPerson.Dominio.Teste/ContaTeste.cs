using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaxPerson.Dominio.Teste
{
    [TestClass]
    public class ContaTeste
    {
        [TestMethod]
        public void Adicionar_Credito_Em_Conta()
        {
            // Arrange
            Conta conta = new Conta();

            // Act
            conta.Credito.Acrescentar(10);

            // Assert
            Assert.AreEqual(conta.Credito.CreditoDisponivel, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Adicionar_Credito_Negativo_Em_Conta()
        {
            // Arrange
            Conta conta = new Conta();

            // Act
            conta.Credito.Acrescentar(-10);
        }

        [TestMethod]
        public void Remover_Credito_Em_Conta()
        {
            // Arrange
            Conta conta = new Conta();
            conta.Credito.Acrescentar(10);

            // Act
            conta.Credito.Remover(5);

            // Assert
            Assert.AreEqual(conta.Credito.CreditoDisponivel, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Remover_Credito_Negativo_Em_Conta()
        {
            // Arrange
            Conta conta = new Conta();

            // Act
            conta.Credito.Remover(-10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Remover_Credito_A_Mais_Em_Conta()
        {
            // Arrange
            Conta conta = new Conta();
            conta.Credito.Acrescentar(10);

            // Act
            conta.Credito.Remover(20);
        }

        [TestMethod]
        public void Reservar_Credito_Em_Conta()
        {
            // Arrange
            Conta conta = new Conta();
            conta.Credito.Acrescentar(10);

            // Act
            conta.Credito.Reservar(3);

            // Assert
            Assert.AreEqual(conta.Credito.CreditoDisponivel, 7);
            Assert.AreEqual(conta.Credito.CreditoReservado, 3);
            Assert.AreEqual(conta.Credito.Saldo, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Reservar_Credito_Negativo_Em_Conta()
        {
            // Arrange
            Conta conta = new Conta();
            conta.Credito.Acrescentar(10);

            // Act
            conta.Credito.Reservar(-3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Reservar_Credito_A_Mais_Em_Conta()
        {
            // Arrange
            Conta conta = new Conta();
            conta.Credito.Acrescentar(10);

            // Act
            conta.Credito.Reservar(20);
        }

        [TestMethod]
        public void Cancelar_Reserva_Em_Conta()
        {
            // Arrange
            Conta conta = new Conta();
            conta.Credito.Acrescentar(10);
            conta.Credito.Reservar(3);

            // Act
            conta.Credito.CancelarReserva(3);

            // Assert
            Assert.AreEqual(conta.Credito.CreditoDisponivel, 10);
            Assert.AreEqual(conta.Credito.CreditoReservado, 0);
            Assert.AreEqual(conta.Credito.Saldo, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Cancelar_Reserva_Negativo_Em_Conta()
        {
            // Arrange
            Conta conta = new Conta();
            conta.Credito.Acrescentar(10);
            conta.Credito.Reservar(3);

            // Act
            conta.Credito.CancelarReserva(-3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Cancelar_Reserva_A_Mais_Em_Conta()
        {
            // Arrange
            Conta conta = new Conta();
            conta.Credito.Acrescentar(10);
            conta.Credito.Reservar(5);

            // Act
            conta.Credito.CancelarReserva(6);
        }

    }
}
