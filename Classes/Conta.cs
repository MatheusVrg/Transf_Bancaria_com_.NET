using System;

namespace Bank.DIO
{
    public class Conta
    {
        private string Nome { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private TipoConta TipoConta { get; set; }   

        public Conta (TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        } 
        public bool Saque(double vSaque)
        {
            //Validação do saldo suficiente
            if(this.Saldo - vSaque < (this.Credito *-1))
            {
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }
            this.Saldo -= vSaque;
            Console.WriteLine($"O saldo atual da conta de {this.Nome} é R${this.Saldo}");
            return true;
        }
        public void Deposito (double vDeposito)
        {
            this.Saldo += vDeposito;
            Console.WriteLine($"O saldo atual da conta de {this.Nome} é R${this.Saldo}");
        }
        public void Transferencia(double vTransferencia, Conta cDestino)
        {
            if(this.Saque(vTransferencia))
            {
                cDestino.Deposito(vTransferencia);
            }
        }
        public override string ToString()
        {
            string retorno = "";
            retorno += $"Tipo da Conta: {this.TipoConta} | ";
            retorno += $"Nome: {this.Nome} | ";
            retorno += $"Saldo: {this.Saldo} | ";
            retorno += $"Crédito: {this.Credito} | ";
            return retorno;
        }
    }
}