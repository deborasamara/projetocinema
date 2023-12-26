namespace projetocinema;

using System; 
using System.Collections.Generic;
using System.IO; 
using System.Xml.Serialization;

public class Program {

  public static void Main() {
    
    Console.WriteLine("Bem vindo ao Sistema de Gerenciamento de Cinema");
    Console.WriteLine();

    // Escolher Logar ou Se Cadastrar se não tiver uma conta
    Console.WriteLine("Digite 1 se deseja logar ou 2 se deseja se cadastrar");
    int op = 0;

    if(int.TryParse(Console.ReadLine(), out op)){
      switch(op){
        case 1: // Logar
          if(Login() == "admin"){
            Console.WriteLine();
            Console.WriteLine("Bem vindo, Admin!");
            int op2 = MenuAdmin();
            // OPÇÕES DO ADMIN


            
          }else{
            // Ver se a conta existe
            Console.WriteLine("Bem vindo, Cliente!");
            int op2 = MenuCliente();
            // OPÇÕES DO CLIENTE
            
          }

          break;

        case 2: // Se cadastrar e ir pra tela de login

        break;

        default:
          Console.WriteLine("Digite um número válido!");
          break;

      }


    }else{
          Console.WriteLine("Digite um número válido!");
    }
    
  }
  // LOGIN AO SISTEMA
  public static string Login() {
    Console.WriteLine("Informe seu email de usuário: ");
    Console.Write("E-mail: ");
    string email = Console.ReadLine();
    Console.WriteLine();
    Console.WriteLine("Informe sua senha: ");
    Console.Write("Senha: ");
    string senha = Console.ReadLine();
    if (email == "admin@gmail.com" && senha == "123456" ) {
      return "admin";
    }
    // verificar se o usuario existe
    
    return "usuario";
  }

  public static int MenuAdmin() {
    Console.WriteLine("OPÇÕES DO ADMINISTRADOR");
    Console.WriteLine();
    Console.WriteLine("Menu Usuarios");
    Console.WriteLine("01 - Inserir");
    Console.WriteLine("02 - Listar");
    Console.WriteLine("03 - Listar por Categoria");
    Console.WriteLine("04 - Atualizar");
    Console.WriteLine("05 - Excluir");
    Console.WriteLine();
    Console.WriteLine("Menu Filmes");
    Console.WriteLine("06 - Inserir");
    Console.WriteLine("07 - Listar");
    Console.WriteLine("08 - Atualizar");
    Console.WriteLine("09 - Excluir");
    Console.WriteLine();
    Console.WriteLine("Menu Ingressos");
    Console.WriteLine("10 - Inserir");
    Console.WriteLine("11 - Listar");
    Console.WriteLine("12 - Atualizar");
    Console.WriteLine("13 - Excluir");
    Console.WriteLine();
    Console.WriteLine("Menu Sessões");
    Console.WriteLine("14 - Inserir");
    Console.WriteLine("15 - Listar");
    Console.WriteLine("16 - Atualizar");
    Console.WriteLine("17 - Excluir");
    Console.WriteLine();
    Console.WriteLine("99 - Sair");
    Console.Write("\nOpção: ");
    return int.Parse(Console.ReadLine());
  }

  public static int MenuCliente() {
    Console.WriteLine("OPÇÕES DO CLIENTE");
    Console.WriteLine();
    Console.WriteLine("01 - Ver Filmes");
    Console.WriteLine("02 - Ver Ingressos Comprados");
    Console.WriteLine("03 - Comprar Ingresso");
    Console.WriteLine();
    Console.WriteLine("99 - Sair");
    Console.Write("\nOpção: ");
    return int.Parse(Console.ReadLine());
  }
}
