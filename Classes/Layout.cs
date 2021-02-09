using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DigitalBank.Classes
{
    public class Layout
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();
        private static int opcao = 0;
        public static void TelaPrincipal()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;

            Console.Clear();
        retorna:

            Console.WriteLine("                  Bem-vindo ao DigiBANK               ");

            Console.WriteLine("                                                      ");
            Console.WriteLine("                  Digite a opção desejada:            ");
            Console.WriteLine("            ===================================       ");
            Console.WriteLine("              1 - Criar Conta                         ");
            Console.WriteLine("            ===================================       ");
            Console.WriteLine("              2 - Entrar com CPF e Senha              ");
            Console.WriteLine("            ===================================       ");

            opcao = int.Parse(Console.ReadLine());
                 
                switch (opcao)
                {
                    case 1:
                        TelaCriarConta();
                        break;
                    case 2:
                        TelaDeLogin();
                        break;
                    default:
                    Console.Clear();
                    Console.WriteLine("            Opção Inválida!                                          ");
                    Console.WriteLine("            ======================================                   ");
                    Console.WriteLine("");
                    goto retorna;    
            }
      
        }
        //os metodos estão criados privados porque não é necessário permitir o acesso deles de outra classe, pois o metodo TelaPrincipal() já contem os metodos abaixo.
        private static void TelaCriarConta()
        {
            string nome;
            string cpf;
            string senha;
            string confirmaSenha;

            Console.Clear();
            Console.WriteLine("                  Realizar cadastro                       ");

            
                Console.WriteLine("                                                      ");
                Console.WriteLine("                  Digite o seu nome:                  ");
                 nome = Console.ReadLine();
                Console.WriteLine("            ===================================       ");
                Console.WriteLine("                  Digite o seu CPF:                   ");
                 cpf = Console.ReadLine();
                Console.WriteLine("            ===================================       ");

            do
            {
                Console.WriteLine("                  Digite a senha senha:               ");
                senha = Console.ReadLine();
                Console.WriteLine("            ===================================       ");
                Console.WriteLine("                  Confirme a sua senha:               ");
                confirmaSenha = Console.ReadLine();
                if (senha != confirmaSenha)
                {
                    Console.Clear();
                    Console.WriteLine("As senhas estão diferentes. Digite novamente");
                }
                Console.WriteLine("            ===================================       ");

            } while (senha != confirmaSenha);
            // Criar conta

            ContaCorrente contaCorrente = new ContaCorrente();
            Pessoa pessoa = new Pessoa();


            pessoa.SetNome(nome);
            pessoa.SetCPF(cpf);
            pessoa.SetSenha(senha);
            pessoa.SetConfirmaSenha(confirmaSenha);
            pessoa.Conta = contaCorrente;

            pessoas.Add(pessoa);

            Console.Clear();


            Console.WriteLine("                Conta cadastrada com sucesso          ");
            Console.WriteLine("            ===================================       ");

            // esse código aguarda 1 segundo para direcionar para a tela logada
            Thread.Sleep(1500);

            TelaContaLogada(pessoa);
         
        }

        private static void TelaDeLogin()
        {
            Console.Clear();

            Console.WriteLine("                  Realizar LOGIN no sistema           ");

            Console.WriteLine("                                                      ");
            Console.WriteLine("                  Digite o CPF:                       ");
            string cpf = Console.ReadLine();
            Console.WriteLine("            ===================================       ");
            Console.WriteLine("                  Digite a sua senha:                 ");
            string senha = Console.ReadLine();
            Console.WriteLine("            ===================================       ");

            // Realizar login no sistema

            // FirstOrDefault = busca o primeiro ou o único registro dentro da lista pessoas
            Pessoa pessoa = pessoas.FirstOrDefault(x => x.CPF == cpf && x.Senha == senha);

            if(pessoa != null)
            {
                TelaBoasVindas(pessoa);

                TelaContaLogada(pessoa);
            }
            else
            {
                Console.Clear();


                Console.WriteLine("                Usuário não cadastrado                ");
                Console.WriteLine("            ===================================       ");

                Console.WriteLine();
                Console.WriteLine();
            }

        }

        private static void TelaBoasVindas(Pessoa pessoa)
        {
            string msgIncial = $" Banco:{pessoa.Conta.GetCodigoDoBanco()} | Agência:{pessoa.Conta.GetNumeroAgencia()} | Conta:{pessoa.Conta.GetNumeroConta()} ";
            Console.WriteLine("");
            Console.WriteLine($"Olá {pessoa.Nome.ToUpper()}, seja Bem-Vindo!! | {msgIncial}");
            Console.WriteLine("");
        }

        private static void TelaContaLogada(Pessoa pessoa)
        {
            Console.Clear();
            retorna:

            TelaBoasVindas(pessoa);

            Console.WriteLine("            Por favor, digite a opção desejada                       ");
            Console.WriteLine("            ======================================                   ");
            Console.WriteLine("            1 - Realizar um Depósito                                 ");
            Console.WriteLine("            ======================================                   ");
            Console.WriteLine("            2 - Realizar um Saque                                    ");
            Console.WriteLine("            ======================================                   ");
            Console.WriteLine("            3 - Consultar seu Saldo                                  ");
            Console.WriteLine("            ======================================                   ");
            Console.WriteLine("            4 - Extrato                                              ");
            Console.WriteLine("            ======================================                   ");
            Console.WriteLine("            5 - Retornar para a Tela Principal                       ");
            Console.WriteLine("            ======================================                   ");
            Console.WriteLine("            6 - Sair                                                 ");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao) 
            {
                case 1:
                    
                    double realizaDeposito = 0;

                    Console.WriteLine("            Quanto você deseja depositar?                            ");
                    Console.WriteLine("            ======================================                   ");
                    realizaDeposito = double.Parse(Console.ReadLine());
                    pessoa.Conta.Deposita(realizaDeposito);


                    Console.WriteLine("            Depósito realizado com sucesso!           ");
                    Console.WriteLine("            ===================================       ");
                    Thread.Sleep(2000);

                    Console.Clear();
                   
                    TelaRetornarParaConta(pessoa);
                           
                    break;
                case 2:

                    double realizaSaque = 0;
                   
                    Console.WriteLine($"Seu saldo é de: {pessoa.Conta.ConsultaSaldo()}");
                    Console.WriteLine("            Quanto você deseja sacar ?                               ");
                    Console.WriteLine("            ======================================                   ");
                    realizaSaque = double.Parse(Console.ReadLine());
                    pessoa.Conta.Sacar(realizaSaque);
                
                    Thread.Sleep(2000);
                        
                    Console.Clear();

                    TelaRetornarParaConta(pessoa);

                    break;
                case 3:

                    Console.Clear();

                    Console.WriteLine("            Saldo em Conta Corrente                   ");
                    Console.WriteLine("            ===================================       ");

                    Console.WriteLine("Saldo: " + pessoa.Conta.ConsultaSaldo());

                   

                    TelaRetornarParaConta(pessoa);

                    break;
                case 4:
                    
                    break;
                case 5:
                    TelaPrincipal();
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine("            Programa encerrado. Volte sempre!!        ");
                    Console.WriteLine("            ===================================       ");
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("            Opção Inválida!                                          ");
                    Console.WriteLine("            ======================================                   ");
                    goto retorna;
            }

        }

        public static void TelaRetornarParaConta(Pessoa pessoa)
        {
            Console.WriteLine("            Escolha uma opção abaixo                                 ");
            Console.WriteLine("            ======================================                   ");
            Console.WriteLine("            1 - Voltar para a minha Conta                            ");
            Console.WriteLine("            ======================================                   ");
            Console.WriteLine("            2 - Retornar para a Tela Principal                       ");
            Console.WriteLine("            ======================================                   ");
            Console.WriteLine("            3 - Sair                                                 ");
            Console.WriteLine("            ======================================                   ");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    TelaContaLogada(pessoa);
                    break;
                case 2:
                    TelaPrincipal();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("            Programa encerrado. Volte sempre!!        ");
                    Console.WriteLine("            ===================================       ");
                    Environment.Exit(0);
                    break;
            }
        }


    }
}
