
using System; 
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Xml.Serialization;

public class Sala : IModelo {
  public int id {get; set;}

  public string nome {get; set;}

  public override string ToString(){
    return "Número: " +id + " Sala: " + nome;
  }
  
}

class NSala : NModelo<Sala> {
  public NSala() : base("Sala.xml") { }
}