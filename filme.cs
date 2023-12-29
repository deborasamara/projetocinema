

using System; 

public class Filme : IModelo {
  public int id{get; set;}
  public DateTime dataInicio{get; set;}
  public DateTime dataFim{get; set;}
  public string genero{get; set;}
  public string titulo{get; set;}
  public string sinopse{get; set;}
  public int classificacao{get; set;}

  public override string ToString(){
    return "Filme: " + id + " - Título:  " + titulo + " - Gênero: " + genero + " - Classificação: " + classificacao + " - Sinopse: " + sinopse + " Data Início: " + dataInicio + " Data Fim: " + dataFim;
  }
}

class NFilme : NModelo<Filme>{
  public NFilme(): base("Filme.xml"){}
}

