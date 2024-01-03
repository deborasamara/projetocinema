
using System; 
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Xml.Serialization;

public class Sessao : IModelo {
  public int id {get; set;}
  public double preco {get; set;}
  public DateTime dia_data{get; set;}
  public string horario {get; set;} 
  public int ingressosDisponiveis {get; set;}
  public int idFilme{get; set;}
  public int idSala{get; set;}

  public override string ToString(){
    return "Sessão: " + id + 
            " Preço: " + preco + 
            " Horário: "+ horario + 
            " Ingressos Disponíveis: " + ingressosDisponiveis + 
            " Sala: "+ idSala + 
            " Filme: "+ idFilme;
  }
}

class NSessao : NModelo<Sessao> {
  public NSessao() : base("Sessao.xml") { }
}