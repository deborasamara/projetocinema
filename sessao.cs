
using System; 
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class Sessao : IModelo {
  public int id {get; set;}
  public double preco {get; set;}
  public DateTime horario {get; set;}
  public int ingressosDisponiveis {get; set;}

  public override string ToString(){
    return "Sessão: " + id;
  }
}

class NSessao : NModelo<Sessao> {
  public NSessao() : base("Sessao.xml") { }
}