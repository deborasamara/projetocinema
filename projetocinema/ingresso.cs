namespace projetocinema;
using System; 
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class Ingresso : IModelo {
  private int id{get; set;}
  
  public override string ToString(){
    return "Ingresso: " + id;
  }
}