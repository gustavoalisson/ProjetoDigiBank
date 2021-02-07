using DigitalBank.Contratos;
using System;


namespace DigitalBank.Classes
{
    public abstract class Conta : Banco, IConta
    {
        public Conta()
        {
            this.NumeroAgencia = "0001";
            Conta.NumeroDaContaEmSequencia++;
        }

        public double Saldo { get; private set; }
        public string NumeroAgencia { get; private set; }
        public string NumeroConta { get; protected set; }
        public static int NumeroDaContaEmSequencia { get; protected set; }

        public double ConsultaSaldo()
        {
            return this.Saldo;
        }

        public void Deposita(double valor)
        {
            this.Saldo += valor;
        }

        public bool Sacar(double valor)
        {
            if (valor > this.ConsultaSaldo())
            {
                Console.WriteLine("Saque indisponível. ");
                return false;
            }
            else
            {
                this.Saldo -= valor;
                return true;
            }

        }

        public string GetCodigoDoBanco()
        {
            return this.CodigoDoBanco;
        }

        public string GetNumeroAgencia()
        {
            return this.NumeroAgencia;
        }

        public string GetNumeroConta()
        {
            return this.NumeroConta;
        }
    }
}
