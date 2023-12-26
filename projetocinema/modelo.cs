namespace projetocinema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

interface IModelo {
    private int id { get; set; }
}

// Classe genérica
/*  Classes genéricas possibilitam a escrita de classes com comportamentos
padronizados, evitando a reescrita de código*/
class NModelo<T> where T : IModelo {
  private List<T> objetos = new List<T>();
  private string nomeArquivo;
  public NModelo(string nomeArquivo) {
    this.nomeArquivo = nomeArquivo;
  }

  public void ToXML() {
    XmlSerializer xml = new XmlSerializer(typeof(List<T>));
    StreamWriter f = new StreamWriter(nomeArquivo);
    xml.Serialize(f, objetos);
    f.Close();
  }
  public void FromXML() {
    try {
      XmlSerializer xml = new XmlSerializer(typeof(List<T>));
      StreamReader f = new StreamReader(nomeArquivo);
      objetos = (List<T>) xml.Deserialize(f);
      f.Close();
    }
    catch (FileNotFoundException)
    {
    }
  }
  public void Inserir(T p) {
    FromXML();
    int id = 0;
    foreach(T obj in objetos) 
      if (obj.id > id) id = obj.id;
    p.id = id + 1;
    objetos.Add(p);
    ToXML();
  }
  // Sobrecarga
  public List<T> Listar() {
    FromXML();
    return objetos;
  }
  public T Listar(int id) {
    FromXML();
    foreach(T obj in objetos) 
      if (obj.id == id) return obj;
    return default(T);
  }
  public void Atualizar(T p) {
    FromXML();
    T obj = Listar(p.id);
    if (obj != null) {
      objetos.Remove(obj);
      objetos.Add(p);
    }
    ToXML();
  }
  public void Excluir(T p) {
    FromXML();
    T obj = Listar(p.id);
    if (obj != null) objetos.Remove(obj);
    ToXML();
  }
}



