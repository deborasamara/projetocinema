
using System; 
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class Sala : IModelo {
  public int id {get; set;}

  public override string ToString(){
    return "Sala: " + id;
  }
  
}

class NSala : NModelo<Sala> {
  public NSala() : base("Sala.xml") { }
}