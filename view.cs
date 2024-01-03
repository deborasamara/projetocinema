using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

static class View {
    // CRUDs USUÁRIO
    public static void UsuarioInserir(string Nome, string Cpf, string Email, string Senha){
        try{
            Usuario x = new Usuario{nome = Nome, cpf = Cpf, email = Email, senha = Senha};
            NUsuario y = new NUsuario();
            y.Inserir(x);
        }catch(Exception ex){
            Console.WriteLine($"Algo deu errado no cadastro do Usuário! {ex.Message}");
        }
    }

    public static List<Usuario> UsuarioListar(){
        NUsuario x = new NUsuario();
        return x.Listar();
    }

    public static void UsuarioAtualizar(int Id, string Cpf, string Nome, string Email, string Senha){
        Usuario x = new Usuario{id = Id, nome = Nome, cpf = Cpf, email = Email, senha = Senha};
        NUsuario y = new NUsuario();
        y.Atualizar(x);
    }

    public static void UsuarioExcluir(int Id) {
        Usuario x = new Usuario{id = Id};
        NUsuario y = new NUsuario();
        y.Excluir(x);
    }

    // CRUDs FILMES
    public static void FilmeInserir(DateTime DataInicio, DateTime DataFim, string Genero, string Titulo, string Sinopse, int Classificacao){
        try{
            Filme x = new  Filme{dataInicio = DataInicio, dataFim = DataFim, genero = Genero, titulo = Titulo, sinopse =  Sinopse, classificacao = Classificacao};
            NFilme y = new NFilme();
            y.Inserir(x);
        }catch(Exception ex){
            Console.WriteLine($"Algo deu errado no cadastro do filme! {ex.Message}");
        }
    }
    
    public static List<Filme> FilmeListar(){
        NFilme x = new NFilme();
        return x.Listar();
    }

    public static void FilmeAtualizar(int Id, DateTime DataInicio, DateTime DataFim, string Genero, string Titulo, string Sinopse, int Classificacao){
        Filme x = new  Filme{id = Id, dataInicio = DataInicio, dataFim = DataFim, genero = Genero, titulo = Titulo, sinopse = Sinopse, classificacao = Classificacao };
        NFilme y = new NFilme();
        y.Atualizar(x);
    }

    public static void FilmeExcluir(int Id) {
        Filme x = new  Filme{id = Id};
        NFilme y = new NFilme();
        y.Excluir(x);
    }

    // CRUDs Ingressos
     public static void IngressoInserir(int IdSessaop, int idUsuariop){
        try{
            Ingresso x = new Ingresso{idSessao = IdSessaop, idUsuario = idUsuariop};
            NIngresso y = new NIngresso();
            y.Inserir(x);
        }catch(Exception ex){
            Console.WriteLine($"Algo deu errado no cadastro do ingresso! {ex.Message}");
        }
    }
    
    public static List<Ingresso> IngressoListar(){
        NIngresso x = new NIngresso();
        return x.Listar();
    }

    public static void IngressoAtualizar(int id_ingresso, int id_sessao, int id_usuario){
        Ingresso x = new  Ingresso{id = id_ingresso, idSessao = id_sessao, idUsuario = id_usuario};
        NIngresso y = new NIngresso();
        y.Atualizar(x);
    }

    public static void IngressoExcluir(int Id) {
        Ingresso x = new  Ingresso{id = Id};
        NIngresso y = new NIngresso();
        y.Excluir(x);
    }

    // CRUDs sessoes
     public static void SessaoInserir(double Preco, DateTime DataSessao, string horariosessao, int ingressos_disponiveis, int id_sessao_sala, int id_sessao_filme){
        try{
            Sessao x = new Sessao{preco = Preco,  dia_data = DataSessao,  horario = horariosessao, ingressosDisponiveis = ingressos_disponiveis, idSala = id_sessao_sala, idFilme = id_sessao_filme};
            NSessao y = new NSessao();
            y.Inserir(x);

        }catch(Exception ex){
            Console.WriteLine($"Algo deu errado no cadastro da sessão! {ex.Message}");
        }
    }
    
    public static List<Sessao> SessaoListar(){
        NSessao x = new NSessao();
        return x.Listar();
    }

    public static void SessaoAtualizar(int n_sessao, double Preco, DateTime DataSessao, string horariosessao, int ingressos_disponiveis, int id_sessao_sala, int id_sessao_filme){
        Sessao x = new  Sessao{id = n_sessao, preco = Preco,  dia_data = DataSessao,  horario = horariosessao, ingressosDisponiveis = ingressos_disponiveis, idSala = id_sessao_sala, idFilme = id_sessao_filme };
        NSessao y = new NSessao();
        y.Atualizar(x);
    }

    public static void SessaoAtualizarApenasIngresso(int n_sessao){
        // Cria objeto do tipo XML para que eu possa carregar e manipular 
        XmlDocument documento = new XmlDocument();
        // Carrega o conteúdo do arquivo XML no objeto 
        documento.Load("Sessao.xml");
        //Seleciona todos os nós da sessão dentro do caminho 
        XmlNodeList sessoesNodes = documento.SelectNodes("/ArrayOfSessao/Sessao");
        //Encontra o primeiro nó da Sessão que o Id seja igual ao valor dito
        /*
        
        sessoesNodes -> Coleção de nós XML
        .Cast<XmlNode> -> converter os elementos da coleção em "sessoesNodes", já que o xmlNodeList não é enumerável
        .FirstOrDefault -> Encontrar o primeiro elemento que atenda a exigência.
        n -> XmlNode
        n.SelectSingleNode("id")  -> Seleciona o id dentro do XmLnode
        n.SelectSingleNode("id).InnerText -: Obtem o texto
        n_sessao.ToString() -> converte o valor da sessao pedida em string
        
        */
        XmlNode sessaoNode = sessoesNodes.Cast<XmlNode>()
        .FirstOrDefault(n => n.SelectSingleNode("id").InnerText == n_sessao.ToString());
        // Seleciona o "nó" ingressos disponíveis 
        XmlNode ingressosNode = sessaoNode.SelectSingleNode("ingressosDisponiveis");  
        // Converte o valor desse nó de string para int
        int ingressosDisponiveis = int.Parse(ingressosNode.InnerText);
        // decrementa o valor dos ingressos e atualiza o valor no "nó"
        ingressosNode.InnerText = (ingressosDisponiveis - 1).ToString();
        // Salva as alterações
        documento.Save("Sessao.xml");
        // Avisa que deu certo
        Console.WriteLine("Ingresso comprado com sucesso!");            
    }

    public static void SessaoExcluir(int Id) {
        Sessao x = new  Sessao{id = Id};
        NSessao y = new NSessao();
        y.Excluir(x);
    }

    // CRUDs sala
     public static void SalaInserir(string nome_sala){
        try{
            Sala x = new Sala{nome = nome_sala};
            NSala y = new NSala();
            y.Inserir(x);
        }catch(Exception ex){
            Console.WriteLine($"Algo deu errado no cadastro da sala! {ex.Message}");
        }
    }
    
    public static List<Sala> SalaListar(){
        NSala x = new NSala();
        return x.Listar();
    }

    public static void SalaAtualizar(int Id, string nome_sala){
        Sala x = new  Sala{id = Id, nome = nome_sala};
        NSala y = new NSala();
        y.Atualizar(x);
    }

    public static void SalaExcluir(int Id) {
        Sala x = new  Sala{id = Id};
        NSala y = new NSala();
        y.Excluir(x);
    }








}