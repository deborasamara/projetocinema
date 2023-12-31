
using System; 
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class Ingresso : IModelo {
  public int id{get; set;}
  public int idSessao {get; set;} 
  public int idUsuario{get; set;}
  public override string ToString(){
    return "Ingresso: " + id + "Sessão: "+ idSessao;
  }
}

class NIngresso : NModelo<Ingresso> {
  public NIngresso() : base("Ingresso.xml") { }
}