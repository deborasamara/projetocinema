namespace projetocinema;

using System; 
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class Usuario : IModelo {
  private int id;
  //private TipoUsuario tipo;
  private int cpf;
  private string nome;
  private string email;
  private string senha;

  public override string ToString(){
    return "Usuario: " + id + " - " + nome + " - " + email + " - " + cpf;
  }
}