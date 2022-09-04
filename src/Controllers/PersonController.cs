using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

using src.Models;
using src.Persistence;

namespace src.Controllers;


[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase {
    private     Dbcontext  _context { get; set; }
    public PersonController(Dbcontext context){
        this._context = context;
    }
    [HttpGet]
    public ActionResult< List<Person>> Get(){
         //Person person = new Person("Arthur",31 ,00000);
        // Contract newContract = new Contract(50,"0000");
        // person.contracts.Add(newContract);

       var result =_context.Persons.Include(person => person.contracts).ToList();
       if(!result.Any())return NoContent();
       
       return Ok(result);
     
    }
    [HttpPost]
    public Person Post(Person person)
    {
        _context.Persons.Add(person);
        _context.SaveChanges();
        return person;

    }
    [HttpPut("{Id}")]
    public ActionResult<Object> Update(
    [FromRoute]int id,
    [FromBody] Person person
    )
    { var result = _context.Persons.SingleOrDefault(e => e.Id == id);

        if(result is null ){
            return NotFound(new {
                msg = "Resgistro não encontado",
                status = HttpStatusCode.NotFound
            });
        }
        
        try
    {
        _context.Persons.Update(person);
        _context.SaveChanges();
    }
    catch (System.Exception)
    {
         return BadRequest (new { 
            msg = "Houve erro ao enviar a solicitação do "+ id ,
            status = HttpStatusCode.OK
            }) ;
        throw;
    }
        

        return Ok (new { 
            msg = "Dados do id "+ id +" atualizados ",
            status = HttpStatusCode.OK
            }) ;
    }

    [HttpDelete("{id}")]
    public ActionResult <Object> Delete ([FromRoute]int id)
    {
        var result = _context.Persons.SingleOrDefault(e => e.Id == id);

        if(result is null ){
            return BadRequest(new{
                msg = "solicitação invalida",
                status = HttpStatusCode.BadRequest
            });
        }

        _context.Persons.Remove(result);
        _context.SaveChanges();
        return Ok(new {msg = "deletado pessoa de Id " + id,
        status = HttpStatusCode.OK
    });

    }
    
}