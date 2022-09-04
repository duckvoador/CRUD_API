using System.Collections.Generic;
namespace src.Models;

public class Person
{
    public Person()
    {
       this.Name = "Bolinha de golf";
       this.Years = 0; 
       this.contracts = new List<Contract>();
       this.StatusAccount = true;
    }
    public Person (string Nome, int Years , int Cpf){
        this.Name = Nome;
        this.Years = Years;
        this.Cpf = Cpf;
        this.contracts = new List<Contract>();
        this.StatusAccount = true;
    }
    //nome, idade, cpf, ativa
    public int Id { get; set; }
    public string Name {get; set;}
    public int Years { get; set; }
    public int? Cpf { get; set; }
    public bool StatusAccount { get; set; }
    public List<Contract> contracts{get;set;}
}