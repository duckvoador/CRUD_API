using System.Collections.Generic;
namespace src.Models;
public class Contract
{
    public Contract()
    {
        this.DateCreation = DateTime.Now;
        this.Value = 0;
        this.TokenId = "00000";
        this.PaidOut = false;
        
    }
     public Contract(double Value, string TokenId){ 
        this.DateCreation = DateTime.Now;
        this.TokenId = TokenId;
        this.Value = Value;
        this.PaidOut = false;

     }

    public int Id { get; set; }
    public DateTime DateCreation { get; set; }
    public string TokenId { get; set; }
    public double Value { get; set; }

    public bool PaidOut { get; set; } 
    public int PersonId { get; set; }

    
}
