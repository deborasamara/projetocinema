namespace projetocinema;

using System; 

public class Filme : IModelo {
  private int id{get; set;}
  private DateTime dataInicio{get; set;}
  private DateTime dataFim{get; set;}
  private string genero{get; set;}
  private string titulo{get; set;}
  private string sinopse{get; set;}
  private int classificacao{get; set;}

  public override string ToString(){
    return "Filme: " + id + " - Título:  " + titulo + " - Gênero: " + genero + " - Classificação: " + classificacao + " - Sinopse: " + sinopse;
  }
  
  
}