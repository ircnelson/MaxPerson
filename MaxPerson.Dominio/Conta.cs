using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxPerson.Dominio
{
    public class Conta
    {
        public int ID { get; set; }

        public Credito Credito { get; set; }

        public Conta()
        {
            this.Credito = new Credito();
        }
    }

    public class Credito
    {
        public long CreditoDisponivel { get; set; }
        public long CreditoReservado { get; set; }

        public long Saldo
        {
            get
            {
                return CreditoDisponivel + CreditoReservado;
            }
        }

        public void Reservar(long valor)
        {
            if (valor < 0)
                throw new ArgumentOutOfRangeException("valor", "O valor deve ser maior que zero.");

            if (valor > CreditoDisponivel)
                throw new ArgumentOutOfRangeException("valor", "O valor deve ser menor que o saldo atual.");

            this.CreditoReservado += valor;
            this.CreditoDisponivel -= valor;
        }

        public void CancelarReserva(long valor)
        {
            if (valor < 0)
                throw new ArgumentOutOfRangeException("valor", "O valor deve ser maior que zero.");

            if (valor > CreditoReservado)
                throw new ArgumentOutOfRangeException("valor", "O valor deve ser menor que o saldo reservado atual.");

            this.CreditoReservado -= valor;
            this.CreditoDisponivel += valor;
        }

        public void Acrescentar(long valor)
        {
            if (valor < 0)
                throw new ArgumentOutOfRangeException("valor", "O valor deve ser maior que zero.");

            this.CreditoDisponivel += valor;
        }

        public void Remover(long valor)
        {
            if (valor < 0)
                throw new ArgumentOutOfRangeException("valor", "O valor deve ser maior que zero.");

            if (valor > CreditoDisponivel)
                throw new ArgumentOutOfRangeException("valor", "O valor deve ser menor que o saldo atual.");

            this.CreditoDisponivel -= valor;
        }
    }
}
