using System;
using System.Collections.Generic;


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
                        Console.WriteLine("Opção inválida, digite uma opção válida.");
                        Console.WriteLine(" ");
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

        }
    }
}
