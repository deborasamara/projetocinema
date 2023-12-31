using System;
using System.Collections.Generic;

static class View {
    // CRUDs USUÁRIO
    public static void UsuarioInserir(string Nome, string Cpf, string Email, string Senha){
        Usuario x = new Usuario{nome = Nome, cpf = Cpf, email = Email, senha = Senha};
        NUsuario y = new NUsuario();
        y.Inserir(x);
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
     public static void IngressoInserir(){
        Ingresso x = new Ingresso{};
        NIngresso y = new NIngresso();
        y.Inserir(x);
    }
    
    public static List<Ingresso> IngressoListar(){
        NIngresso x = new NIngresso();
        return x.Listar();
    }

    public static void IngressoAtualizar(){
        Ingresso x = new  Ingresso{};
        NIngresso y = new NIngresso();
        y.Atualizar(x);
    }

    public static void IngressoExcluir(int Id) {
        Ingresso x = new  Ingresso{id = Id};
        NIngresso y = new NIngresso();
        y.Excluir(x);
    }

    // CRUDs sessoes
     public static void SessaoInserir(double Preco, DateTime DataSessao, int  Ingressos_disponiveis, int Sessao_sala, int Filme){
        Sessao x = new Sessao{preco = Preco,  horario = DataSessao, ingressosDisponiveis = Ingressos_disponiveis, s_sala = Sessao_sala, f_filme = Filme};
        NSessao y = new NSessao();
        y.Inserir(x);
    }
    
    public static List<Sessao> SessaoListar(){
        NSessao x = new NSessao();
        return x.Listar();
    }

    public static void SessaoAtualizar(){
        Sala x = new  Sala{};
        NSala y = new NSala();
        y.Atualizar(x);
    }

    public static void SessaoExcluir(int Id) {
        Sessao x = new  Sessao{id = Id};
        NSessao y = new NSessao();
        y.Excluir(x);
    }

    // CRUDs sala
     public static void SalaInserir(){
        Sala x = new Sala{};
        NSala y = new NSala();
        y.Inserir(x);
    }
    
    public static List<Sala> SalaListar(){
        NSala x = new NSala();
        return x.Listar();
    }

    public static void SalaAtualizar(){
        Sala x = new  Sala{};
        NSala y = new NSala();
        y.Atualizar(x);
    }

    public static void SalaExcluir(int Id) {
        Sala x = new  Sala{id = Id};
        NSala y = new NSala();
        y.Excluir(x);
    }








}