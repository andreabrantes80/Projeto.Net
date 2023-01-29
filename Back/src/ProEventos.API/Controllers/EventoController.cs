using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
   
   public IEnumerable<Evento> _evento = new Evento[]{
            new Evento(){
               EventoId = 1,
               Tema = "Angular e .NET",
               Local = "Brasília",
               Lote = "1 Lote",
               QtdPessoas = 250,
               DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
         },
         new Evento(){
               EventoId = 2,
               Tema = "Angular e Java",
               Local = "Minas Gerais",
               Lote = "100 Lote",
               QtdPessoas = 250,
               DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy")
         }
      };
    public EventoController()
    {
     
    }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
      return _evento;
       
    }

    [HttpGet("{id}")]
    public IEnumerable<Evento> GetById(int id)
    {
      return _evento.Where(evento => evento.EventoId == id);
       
    }

     [HttpPost]
    public string Post()
    {
       return "Exemplo de POst";
    }

      [HttpPut("{id}")]
    public string Put(int id)
    {
       return $"Exemplo de Put {id}";
    }

     [HttpDelete("{id}")]
    public string Delete(int id)
    {
       return $"Exemplo de Delete {id}";
    }
}
