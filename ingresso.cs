
using System; 
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class Ingresso : IModelo {
  public int id{get; set;}
  
  public override string ToString(){
    return "Ingresso: " + id;
  }
}

class NIngresso : NModelo<Ingresso> {
  public NIngresso() : base("Ingresso.xml") { }
}