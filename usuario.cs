
using System; 
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class Usuario : IModelo {
  public int id{get; set;}
  //private TipoUsuario tipo;
  public string cpf{get; set;}
  public string nome{get; set;}
  public string email{get; set;}
  public string senha{get; set;}

  public override string ToString(){
    return "Usuario: " + id + " - " + nome + " - " + email + " - " + cpf;
  }
}

class NUsuario : NModelo<Usuario> {
  public NUsuario() : base("Usuario.xml") { }
}