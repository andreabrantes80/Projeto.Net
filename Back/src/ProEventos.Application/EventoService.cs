using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist geralPersist;
        public IEventoPersist eventoPersist;
        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
        {
            this.eventoPersist = eventoPersist;
            this.geralPersist = geralPersist;

        }
        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                geralPersist.Add<Evento>(model);
                if(await geralPersist.SaveChangesAsync())
                {
                    return await eventoPersist.GetAllEventosByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Evento> UpDateEvento(int eventoId, Evento model)
        {
           try
           {
                var evento = await eventoPersist.GetAllEventosByIdAsync(eventoId, false);
                if(evento == null) return null;

                model.Id = eventoId;

                geralPersist.UpDate(model);
                if (await geralPersist.SaveChangesAsync())
                {
                    return await eventoPersist.GetAllEventosByIdAsync(model.Id, false);
                }
                return null;
            }
           catch (Exception ex)
           {
            throw new Exception(ex.Message);
           }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await eventoPersist.GetAllEventosByIdAsync(eventoId, false);
                if (evento == null) throw new Exception("Evento não encontrado");

                geralPersist.Delete<Evento>(evento);
                return await geralPersist.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await eventoPersist.GetAllEventosAsync(includePalestrantes);
                if(eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetAllEventosByIdAsync(int eventoId, bool includePalestrantes)
        {
            try
            {
                var eventos = await eventoPersist.GetAllEventosByIdAsync(eventoId, includePalestrantes);
                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);
                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}