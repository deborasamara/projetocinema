using System; 
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Linq.Expressions;
using System.Xml.Serialization;
using System.Linq;
using System.Xml.Linq;
using System.Globalization;

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
        // LOGA COMO ADMIN
          if(Login() == "admin"){
            int op2 = 0;
          
            Console.WriteLine();
            Console.WriteLine("Bem vindo, Admin!");
            while (op2 != 99)
            {
              try{
                 op2 = MenuAdmin();
                 // OPÇÕES DO ADMIN
                  switch(op2){
                  case 1: UsuarioInserir(); break;
                  case 2: UsuarioListar(); break;
                  case 3: UsuarioAtualizar(); break;
                  case 4: UsuarioExcluir(); break;
                  case 5: FilmeInserir(); break;
                  case 6: FilmeListar(); break;
                  case 7: FilmeAtualizar(); break;
                  case 8: FilmeExcluir(); break;
                  case 9: IngressoInserir(); break;
                  case 10: IngressoListar(); break;
                  case 11: IngressoAtualizar(); break;
                  case 12: IngressoExcluir(); break;
                  case 13: SessaoInserir(); break;
                  case 14: SessaoListar(); break;
                  case 15: SessaoAtualizar(); break;
                  case 16: SessaoExcluir(); break;
                  case 17: SalaInserir(); break;
                  case 18: SalaListar(); break;
                  case 19: SalaAtualizar(); break;
                  case 20: SalaExcluir(); break;
                 }

              }catch(Exception){

              }
            }
            
            
          }else{
          // LOGA COMO CLIENTE
            // Não é admin, então verificar se a conta existe


            Console.WriteLine("Bem vindo, Cliente!");
            int op2 = 0;
            // OPÇÕES DO CLIENTE
            while (op2 != 99)
            {
              try{
                 op2 = MenuCliente();
                 // OPÇÕES DO ADMIN
                  switch(op2){
                  case 1: UsuarioInserir(); break;  // 
                  case 2: UsuarioListar(); break;   //
                  case 3: UsuarioAtualizar(); break; //
                 }

              }catch(Exception){

              }
            }
            
          }

          break;

        case 2: // Se cadastrar e ir pra tela de login
        UsuarioInserir();  
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
    Console.WriteLine();
    Console.WriteLine("OPÇÕES DO ADMINISTRADOR");
    Console.WriteLine();
    Console.WriteLine("Menu Usuarios");
    Console.WriteLine("01 - Inserir");
    Console.WriteLine("02 - Listar");
    Console.WriteLine("03 - Atualizar");
    Console.WriteLine("04 - Excluir");
    Console.WriteLine();
    Console.WriteLine("Menu Filmes");
    Console.WriteLine("05 - Inserir");
    Console.WriteLine("06 - Listar");
    Console.WriteLine("07 - Atualizar");
    Console.WriteLine("08 - Excluir");
    Console.WriteLine();
    Console.WriteLine("Menu Ingressos");
    Console.WriteLine("09 - Inserir");
    Console.WriteLine("10 - Listar");
    Console.WriteLine("11 - Atualizar");
    Console.WriteLine("12 - Excluir");
    Console.WriteLine();
    Console.WriteLine("Menu Sessões");
    Console.WriteLine("13 - Inserir");
    Console.WriteLine("14 - Listar");
    Console.WriteLine("15 - Atualizar");
    Console.WriteLine("16 - Excluir");
    Console.WriteLine();
    Console.WriteLine("Menu Salas");
    Console.WriteLine("17 - Inserir");
    Console.WriteLine("18 - Listar");
    Console.WriteLine("19 - Atualizar");
    Console.WriteLine("20 - Excluir");
    Console.WriteLine();
    Console.WriteLine("99 - Sair");
    Console.Write("\nOpção: ");
    return int.Parse(Console.ReadLine());
  }

  public static int MenuCliente() {
    Console.WriteLine();
    Console.WriteLine("OPÇÕES DO CLIENTE");
    Console.WriteLine();
    Console.WriteLine("01 - Ver Filmes Disponíveis");
    Console.WriteLine("02 - Ver Ingressos Comprados");
    Console.WriteLine();
    Console.WriteLine("99 - Sair");
    Console.Write("\nOpção: ");
    return int.Parse(Console.ReadLine());
  }

  // FUNÇÕES ADMIN
  public static void UsuarioInserir()
  {
  //  cpf, nome, email, senha
      Console.WriteLine("Informe o nome do usuário do sistema ");
      string nome = Console.ReadLine();

      Console.WriteLine("Informe o cpf do usuário do sistema ");
      string cpf = Console.ReadLine();

      Console.WriteLine("Informe o e-mail do usuário do sistema ");
      string email = Console.ReadLine();

      Console.WriteLine("Informe a senha do usuário do sistema ");
      string senha = Console.ReadLine();

      View.UsuarioInserir(nome, cpf, email, senha);

      Console.WriteLine("Usuário cadastrado com sucesso!!");

  }

  public static void UsuarioListar(){
    Console.WriteLine("Cadastro de Usuários");
    foreach (Usuario u in View.UsuarioListar())
    {
      Console.WriteLine(u.ToString());
    }
  }

  public static void UsuarioAtualizar(){
    UsuarioListar();

    Console.Write("Informe o id do usuário a ser atualizado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o cpf do usuário: ");
    string cpf = Console.ReadLine();
    Console.Write("Informe o nome: ");
    string nome = Console.ReadLine();
    Console.Write("Informe o email: ");
    string email = Console.ReadLine();
    Console.Write("Informe a senha: ");
    string senha = Console.ReadLine();

    View.UsuarioAtualizar(id, cpf, nome, email, senha);
    Console.WriteLine("Usuário atualizado com sucesso");

  }

  public static void UsuarioExcluir(){
    UsuarioListar();

    Console.Write("Informe o id do usuário a ser excluído: ");
    int id = int.Parse(Console.ReadLine());
    View.UsuarioExcluir(id);
    Console.WriteLine("Usuário excluído com sucesso");
    
  }

  public static void FilmeInserir(){

    Console.WriteLine("Informe a data de Início do filme no cartaz do cinema - No formato dd/MM/yyyy");
    DateTime dataInicio = DateTime.Parse(Console.ReadLine());

    Console.WriteLine("Informe a data de fim do filme no cartaz do cinema - No formato dd/MM/yyyy");
    DateTime dataFim = DateTime.Parse(Console.ReadLine());

    Console.WriteLine("Informe o gênero: ");
    string genero = Console.ReadLine();

    Console.WriteLine("Informe o título: ");
    string titulo = Console.ReadLine();

    Console.WriteLine("Informe a sinopse: ");
    string sinopse = Console.ReadLine();

    Console.WriteLine("Informe a classificação indicativa: ");
    int classificacao = int.Parse(Console.ReadLine());

    View.FilmeInserir(dataInicio, dataFim, genero, titulo, sinopse, classificacao);

    Console.WriteLine("Filme cadastrado com sucesso!!");


  }
  public static void FilmeListar(){
    Console.WriteLine("Filmes cadastrados");
    foreach (Filme u in View.FilmeListar())
    {
      Console.WriteLine(u.ToString());
    }
  }

  public static void FilmeAtualizar(){
    FilmeListar();
    Console.Write("Informe o id do filme a ser atualizado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe a data de inicío: ");
    DateTime dataInicio = DateTime.Parse(Console.ReadLine());
    Console.Write("Informe a data de fim: ");
    DateTime dataFim = DateTime.Parse(Console.ReadLine());
    Console.Write("Informe o gênero: ");
    string genero = Console.ReadLine();
    Console.Write("Informe o titulo ");
    string titulo = Console.ReadLine();
    Console.Write("Informe a sinopse: ");
    string sinopse = Console.ReadLine();
    Console.Write("Informe a classificacao ");
    int classificacao = int.Parse(Console.ReadLine());

    View.FilmeAtualizar(id, dataInicio, dataFim, genero, titulo, sinopse, classificacao);
    Console.WriteLine("Usuário atualizado com sucesso");
  }

  public static void FilmeExcluir(){
    FilmeListar();

    Console.Write("Informe o id do filme a ser excluído: ");
    int id = int.Parse(Console.ReadLine());
    View.FilmeExcluir(id);
    Console.WriteLine("Filme excluído com sucesso");
    
  }

  public static void IngressoInserir(){
    Console.Write("Informe o id da sessão: ");
    int idSessao = int.Parse(Console.ReadLine());


    View.IngressoInserir(idSessao);
  }
  public static void IngressoListar(){
    Console.WriteLine("Ingressos cadastrados");
    foreach (Ingresso u in View.IngressoListar())
    {
      Console.WriteLine(u.ToString());
    }
  }

  public static void IngressoAtualizar(){
    IngressoListar();
  }

  public static void IngressoExcluir(){
    IngressoListar();
  }

  public static void SessaoInserir(){
    Console.WriteLine("Informe o preço dessa sessão");
    double preco = double.Parse(Console.ReadLine());

    Console.WriteLine("Informe o dia e horário dessa sessão - dd/MM/yyyy HH:mm");
    DateTime dataSessao = DateTime.Parse(Console.ReadLine());

    Console.WriteLine("Qual sala das disponíveis? - responder o número de id");
    SalaListar();
    int id_sessao_sala = int.Parse(Console.ReadLine());

    Console.WriteLine("Qual filme dos disponíveis? - responder o número de id");
    FilmeListar();
    // Mostrar os ids dos filmes e entregar o nome do filme escolhido
    int id_sessao_filme = int.Parse(Console.ReadLine());

    Console.WriteLine("Quantos ingressos estarão disponíveis?");
    int ingressos_disponiveis = int.Parse(Console.ReadLine());

    View.SessaoInserir(preco, dataSessao, ingressos_disponiveis, id_sessao_sala, id_sessao_filme);

    Console.WriteLine("Sessão cadastrada!");

  }

  public static void SessaoListar(){
    View.SessaoListar();
  }

  public static void SessaoAtualizar(){
    View.SessaoAtualizar();
    
  }

  public static void SessaoExcluir(){
    SessaoListar();
    
  }

  public static void SalaInserir(){
    View.SalaInserir();
    Console.WriteLine("Sala criada com sucesso!");
  }
  public static void SalaListar(){
    View.SalaListar();

  }

  public static void SalaAtualizar(){
    View.SalaAtualizar();
    
  }

  public static void SalaExcluir(){
    Console.WriteLine("Qual Sala você deseja excluir? Digite o número");
    int num_sala = int.Parse(Console.ReadLine());
    SalaListar();
    View.SalaExcluir(num_sala);
    
  }

} // Chave do arquivo program




