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
  public static string UsuarioIdGlobal;
  public static string UsuarioNomeGlobal;

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
        string resposta_login = Login();
          if(resposta_login == "admin"){
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
            
            
          }else if (resposta_login == "usuario"){
          // LOGA COMO CLIENTE
            // Não é admin, então verificar se a conta existe


            Console.WriteLine("Bem vindo, cliente "+ UsuarioNomeGlobal + " !" );
            int op2 = 0;
            // OPÇÕES DO CLIENTE
            while (op2 != 99)
            {
              try{
                 op2 = MenuCliente();
                  switch(op2){
                  case 1: VerFilmesDisponiveis(); break;  
                  case 2: VeringressosComprados(); break;   
                 }

              }catch(Exception){

              }
            }
            
          }else{
            Console.WriteLine("Esse usuário não existe. Tente se cadastrar no sistema e realizar o login novamente.");
            Main();
          }

          break;

        case 2: // Se cadastrar e ir pra tela de login
        UsuarioInserir();  
        Main();
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
    if(VerificarUsuario(email, senha)){
      return "usuario";
    }

    return "Esse usuário não existe.";

  }

 // Verificar se o usuário existe no XML
    public static bool VerificarUsuario(string email, string senha)
    {
        try
        {
            // Criar uma instância XmlDocument
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Usuario.xml");

            // Encontrar o nó correspondente ao usuário
            XmlNode usuarioNode = xmlDoc.SelectSingleNode($"//Usuario[email='{email}' and senha='{senha}']");
            if (usuarioNode != null)
            {
                UsuarioIdGlobal = usuarioNode.SelectSingleNode("id").InnerText;
                UsuarioNomeGlobal = usuarioNode.SelectSingleNode("nome").InnerText;
            }

            // Se o nó for encontrado, o usuário existe
            return usuarioNode != null;

        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao verificar o usuário: " + ex.Message);
            return false;
        }
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
    View.UsuarioListar();
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

  public static void IngressoInserir(){ // Insere ingresso e Atualiza os ingressos da sessão
      Console.WriteLine("Qual sessão você deseja comprar? - Digite o ID da sessão");
      int idDesejoSessao = int.Parse(Console.ReadLine());
      int idUsuarioIngresso = int.Parse(UsuarioIdGlobal);
      View.IngressoInserir(idDesejoSessao, idUsuarioIngresso);
      View.SessaoAtualizarApenasIngresso(idDesejoSessao);
     
  }
  public static void IngressoListar(){
    Console.WriteLine("Ingressos cadastrados no sistema");
    foreach (Ingresso u in View.IngressoListar())
    {
      Console.WriteLine(u.ToString());
    }
  }

  public static void IngressoAtualizar(){
    IngressoListar();
    Console.WriteLine("Qual ingresso você deseja atualizar? Digite o id");
    int id_ingresso = int.Parse(Console.ReadLine());

    Console.WriteLine("Para qual sessão ele é atribuído? Digite o id");
    SessaoListar();
    int id_sessao = int.Parse(Console.ReadLine());

    Console.WriteLine("Para qual usuário ele é atribuído? Digite o id");
    UsuarioListar();
    int id_usuario = int.Parse(Console.ReadLine());

    View.IngressoAtualizar(id_ingresso, id_sessao, id_usuario);
    Console.WriteLine("Ingresso"+ id_ingresso + "atualizado com sucesso!");
  }

  public static void IngressoExcluir(){
    IngressoListar();
  }

  public static void SessaoInserir(){
    Console.WriteLine("Informe o preço dessa sessão");
    double preco = double.Parse(Console.ReadLine());

    Console.WriteLine("Informe o dia dessa sessão - dd/MM/yyyy HH:mm");
    DateTime dataSessao = DateTime.Parse(Console.ReadLine());

    Console.WriteLine("Informe o horário dessa sessão - HH:mm");
    string horariosessao = Console.ReadLine();

    Console.WriteLine("Qual sala das disponíveis? - responder o número de id");
    SalaListar();
    int id_sessao_sala = int.Parse(Console.ReadLine());

    Console.WriteLine("Qual filme dos disponíveis? - responder o número de id");
    FilmeListar();
    // Mostrar os ids dos filmes e entregar o nome do filme escolhido
    int id_sessao_filme = int.Parse(Console.ReadLine());

    Console.WriteLine("Quantos ingressos estarão disponíveis?");
    int ingressos_disponiveis = int.Parse(Console.ReadLine());

    View.SessaoInserir(preco, dataSessao, horariosessao, ingressos_disponiveis, id_sessao_sala, id_sessao_filme);

    Console.WriteLine("Sessão cadastrada!");

  }

  public static void SessaoListar(){
    Console.WriteLine("Cadastro de Sessões: ");
    foreach (Sessao u in View.SessaoListar())
    {
      Console.WriteLine(u.ToString());
    }
    View.SessaoListar();
  }

  public static void SessaoAtualizar(){
    Console.WriteLine("Qual sessão você deseja atualizar? Digite o número");
    SessaoListar();
    int n_sessao = int.Parse(Console.ReadLine());

    Console.WriteLine("Qual o preço?");
    double preco = double.Parse(Console.ReadLine());

    Console.WriteLine("Qual a data? dd/mm/yyy");
    DateTime sessao_data = DateTime.Parse(Console.ReadLine());

    Console.WriteLine("Qual o horário?");
    string sessao_horario = Console.ReadLine();

    Console.WriteLine("Quantos ingressos disponíveis?");
    int sessao_ingressos = int.Parse(Console.ReadLine());

    Console.WriteLine("Qual o id do Filme?");
    int sessao_filme_id = int.Parse(Console.ReadLine());

    Console.WriteLine("Qual o id da Sala?");
    int sessao_sala_id = int.Parse(Console.ReadLine());


    View.SessaoAtualizar(n_sessao, preco, sessao_data, sessao_horario, sessao_ingressos, sessao_filme_id, sessao_sala_id);

    Console.WriteLine("Sessão"+ n_sessao+ "atualizada com sucesso!");
    
  }

  public static void SessaoExcluir(){
    SessaoListar();
    Console.WriteLine("Qual sessão você deseja excluir?");
    int id_sessao = int.Parse(Console.ReadLine());

    View.SessaoExcluir(id_sessao);
    Console.WriteLine("Sessao" + id_sessao + "excluída com sucesso!");
  }

  public static void SalaInserir(){
    Console.WriteLine("Qual o nome da sala que você deseja inserir?");
    string nome_sala = Console.ReadLine();

    View.SalaInserir(nome_sala);
    Console.WriteLine("Sala criada com sucesso!");
  }
  public static void SalaListar(){
    Console.WriteLine("Todas as salas:  ");
    foreach (Sala u in View.SalaListar())
    {
      Console.WriteLine(u.ToString());
    }
    View.SalaListar();
  }

  public static void SalaAtualizar(){
    SalaListar();
    Console.WriteLine("Qual o id sala que você deseja atualizar?");
    int id_sala = int.Parse(Console.ReadLine());
    Console.WriteLine("Qual o nome da sala?");
    string nome_sala = Console.ReadLine();

    View.SalaAtualizar(id_sala, nome_sala);
  }

  public static void SalaExcluir(){
    Console.WriteLine("Qual Sala você deseja excluir? Digite o número");
    SalaListar();
    int num_sala = int.Parse(Console.ReadLine());
    View.SalaExcluir(num_sala);
    Console.WriteLine("Sala" + num_sala + "excluida com sucesso!");
  }

  public static void VerFilmesDisponiveis(){
    Console.WriteLine("Digite a data para qual você deseja ver os filmes disponíveis - dd/MM/yyyy");
    DateTime data_sessao_disponivel = DateTime.Parse(Console.ReadLine());


    XmlDocument documento_xml = new XmlDocument(); // instância da classe XMLDocument
    documento_xml.Load("Sessao.xml"); // Carrega o conteúdo do XML do arquivo para ser consultado e manipulado
    XmlNodeList sessoes_ = documento_xml.SelectNodes("//Sessao"); // Usa um método que seleciona todas as partes que se relacionam com "sessão" no arquivo. O xmlNodeList vai ter todos os elementos de sessão
    bool filmesDisponiveisSimNao = false;

    if(sessoes_ != null){
      Console.WriteLine($"Filmes disponíveis em {data_sessao_disponivel:dd/MM/yyyy}:");

      foreach(XmlNode x in sessoes_){ // iterar os filmes do xml
        DateTime dataSessao = DateTime.Parse(x.SelectSingleNode("dia_data").InnerText).Date; // selecionar o nó chamado "data" dentro do nó da sessão. Ao encontrar o primeiro "Nó" com a data pedida, retornar.
        if( dataSessao == data_sessao_disponivel.Date){ // comparação. Se a data existir, então:
          filmesDisponiveisSimNao = true;

          string idFilme = x.SelectSingleNode("idFilme").InnerText; // Vai encontrar o id do filme. Precisamos acessar a lista XML dos filmes para pegar o título desse filme.
          string idSessao = x.SelectSingleNode("id").InnerText;
          string horario_filme = x.SelectSingleNode("horario").InnerText;
          string precoFilmeString = x.SelectSingleNode("preco").InnerText;
          string ingressosDisponiveisString = x.SelectSingleNode("ingressosDisponiveis").InnerText;


          List<string> titulosFilmesDisponiveis = new List<string>();

          // xml da classe filme
          XmlDocument documentoXmlFilme = new XmlDocument();
          documentoXmlFilme.Load("Filme.xml");
          XmlNode filmeNode = documentoXmlFilme.SelectSingleNode($"//Filme[id='{idFilme}']"); // achar o id do filme e procurar

          string tituloFilmeString = filmeNode.SelectSingleNode("titulo").InnerText;
          titulosFilmesDisponiveis.Add(tituloFilmeString);

          Console.WriteLine($" Id da Sessão: {idSessao}\n Título do filme: {tituloFilmeString}\n Preço:{precoFilmeString}R$ \n Ingressos Disponíveis:  {ingressosDisponiveisString} \n Horario:  {horario_filme}h\n");


        }
      }
      if(filmesDisponiveisSimNao == false){
          Console.WriteLine("Não há sessões disponíveis!!");
          // volta o fluxo

      }

    }
    if(filmesDisponiveisSimNao == true){ // Se existir filmes disponíveis:
      IngressoInserir();
    }

  }

  public static void VeringressosComprados(){
    XmlDocument xml_ingressos = new XmlDocument(); // instância da classe XMLDocument 
    xml_ingressos.Load("Ingresso.xml"); 
    XmlNodeList ingressos_ = xml_ingressos.SelectNodes("//Ingresso"); 

    int string_id_user = int.Parse(UsuarioIdGlobal);

    Console.WriteLine($"Ingressos comprados :");
    foreach(XmlNode z in ingressos_){
      int id_usuario_ingresso = int.Parse(z.SelectSingleNode("idUsuario").InnerText);
      int id_sessao_ingresso = int.Parse(z.SelectSingleNode("idSessao").InnerText);
      

      if(id_usuario_ingresso == string_id_user){
        Console.WriteLine("Informações do ingresso: ");
        Console.WriteLine($"Número da Sessão: {id_sessao_ingresso}");

        Console.WriteLine(" ");


      }
    }
  }

} // Chave do arquivo program




