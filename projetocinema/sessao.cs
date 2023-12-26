namespace projetocinema;

using System; 
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class Sessao : IModelo {
  private int id {get; set;}
  private double preco {get; set;}
  private DateTime horario {get; set;}
  private int ingressosDisponiveis {get; set;}

  public override string ToString(){
    return "Sessão: " + id;
  }
}