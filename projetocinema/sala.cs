namespace projetocinema;
using System; 
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class Sala : IModelo {
  private int id {get; set;}

  public override string ToString(){
    return "Sala: " + id;
  }
  
}

/*public class NSala : <Sala>{
  public NSala() : base("Sala.xml");
  public List<Sala> Listar

}*/