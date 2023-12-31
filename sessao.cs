
using System; 
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class Sessao : IModelo {
  public int id {get; set;}
  public double preco {get; set;}
  public DateTime horario {get; set;}
  public int ingressosDisponiveis {get; set;}

  public Ingresso s_ingresso{get; set;}

  public Sala s_sala {get; set;}

  public Filme f_filme{get; set;}

  public override string ToString(){
    return "Sessão: " + id + 
            "Preço: " + preco + 
            "Horário: "+ horario + 
            "Ingressos Disponíveis: " + ingressosDisponiveis + 
            "Sala: "+ s_sala + 
            "Filme: "+ f_filme;
  }
}

class NSessao : NModelo<Sessao> {
  public NSessao() : base("Sessao.xml") { }
}