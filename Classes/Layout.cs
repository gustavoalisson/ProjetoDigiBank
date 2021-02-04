using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalBank.Classes
{
    public class Layout
    {
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
        // os metodos estão criados privados porque não é necessário permitir o acesso deles de outra classe, pois o metodo TelaPrincipal() já contem os metodos abaixo.
        private static void TelaCriarConta()
        {
            Console.Clear();

            Console.WriteLine("                  Realizar cadastro                   ");

            Console.WriteLine("                                                      ");
            Console.WriteLine("                  Digite o seu nome:                  ");
            string nome = Console.ReadLine();
            Console.WriteLine("            ===================================       ");
            Console.WriteLine("                  Digite o seu CPF:                   ");
            string cpf = Console.ReadLine();
            Console.WriteLine("            ===================================       ");
            Console.WriteLine("                  Digite a senha senha:               ");
            string senha = Console.ReadLine();
            Console.WriteLine("            ===================================       ");
            Console.WriteLine("                  Confirme a sua senha:               ");
            string confirmaSenha = Console.ReadLine();
            Console.WriteLine("            ===================================       ");

            // Criar conta
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
