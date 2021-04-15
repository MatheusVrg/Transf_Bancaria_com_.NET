using System;
using System.Collections.Generic;

namespace Bank.DIO
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string OpUser = ObterOpUser();

            while(OpUser.ToUpper() != "X")
            {
                switch(OpUser)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "L":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();              
                }
                OpUser = ObterOpUser();
            }
            Console.WriteLine("Obrigado pela preferência!");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
			int indiceContaOrigem = int.Parse(Console.ReadLine());
            Console.Write("Digite o número da conta de destino: ");
			int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double vTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferencia(vTransferencia, listContas[indiceContaDestino]);
        }

        private static void Depositar()
        {
            Console.Write("Digite o número da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor a ser depositado: ");
			double vDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Deposito(vDeposito);    
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor a ser sacado: ");
            double vSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Saque(vSaque);
        }
        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");
            if(listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }
            for(int i = 0;i<listContas.Count;i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova Conta!");
            Console.Write("Informe o Tipo da conta (1 = Pessoa Física, 2 = Pessoa Jurídica): ");
            int entradaTipoConta = int.Parse(Console.ReadLine());
            if(entradaTipoConta != 1 && entradaTipoConta != 2)
            {
                Console.WriteLine("");
                Console.WriteLine("Tipo de Conta Inválido!");
                Console.WriteLine("Vontando ao Menu Inicial...");
            }
            else
            {
            Console.Write("Digite o nome do Cliente: ");
            string entradaNome = Console.ReadLine();
            Console.Write("Informe o Saldo Inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());
            Console.Write("Informe o Crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());
            
            Conta nConta = new Conta((TipoConta)entradaTipoConta, entradaSaldo, entradaCredito, entradaNome);
            listContas.Add(nConta);
            }
        }
        private static string ObterOpUser()
        {
            Console.WriteLine("");
            Console.WriteLine("Bem vindo ao banco digital DIO!");
            Console.WriteLine("");
            Console.WriteLine("Informe a opção desejada:");            
            Console.WriteLine("1- Listar Contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferência");
            Console.WriteLine("4- Saque");
            Console.WriteLine("5- Deposito");
            Console.WriteLine("L- Limpar Tela ");
            Console.WriteLine("X- Sair");
            Console.WriteLine("");

            string OpUser = Console.ReadLine().ToUpper();
            Console.WriteLine("");
            return OpUser;         
        }
    }
}
