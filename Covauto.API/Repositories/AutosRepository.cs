using Covauto.Application.DTO.Boeken;
using Covauto.Domain.Data;
using Covauto.Domain.Entities;
using Covauto.Domain.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Covauto.Applicatie.DTO.Auto;

namespace Covauto.API.Repositories
{
    public class AutosRepository
    {
        private readonly AutosContext autosContext;

        public AutosRepository(AutosContext autosContext)
        {
            this.autosContext = autosContext;
        }

        public IEnumerable<AutoListItem> GeefAlleAutos()
        {
            return autosContext
                .Autos
                .Select(b => new BoekListItem
                {
                    ID = b.Id,
                    Titel = b.Titel,
                    Schrijver = b.Schrijver.Naam
                }).ToList();
        }

        public IEnumerable<AutoListItem> ZoekBoeken(string titel)
        {
            return autosContext
                .Boeken
                .Where(b => b.Titel.ToLower().Contains(titel.ToLower()))
                .Select(b => new AutoListItem()
                {
                    ID = b.Id,
                    Titel = b.Titel,
                    Schrijver = b.Schrijver.Naam
                }).ToList();
        }

        public FullAuto? GeefAuto(int id)
        {
            Boek? boek = autosContext.Autos.Include(b => b.Schrijver).SingleOrDefault(n => n.Id == id);
            return MapBoek(boek);
        }

        public int CreateBoek(CreateBoek boek)
        {
            if (!autosContext.Schrijvers.Any(b => b.Id == boek.SchrijverId))
            {
                throw new Exception("Not a correct SchrijverId");
            }

            var boekEnt = new Boek
            {
                Titel = boek.Titel,
                AantalBladzijden = boek.AantalBladzijden,
                Publicatiejaar = boek.Publicatiejaar,
                SchrijverId = boek.SchrijverId
            };

            autosContext.Auto.Add(autoEnt);

            autosContext.SaveChanges();
            return autoEnt.Id;
        }

        public void UpdateBoek(int id, UpdateBoek boek)
        {
            if (id != boek.Id)
            {
                throw new ValidationException("Ids are not corresponding");
            }

            if (!boeken2025Context.Schrijvers.Any(n => n.Id == boek.SchrijverId))
            {
                throw new Exception("Not a correct SchrijverId");
            }

            Boek? boekEnt = boeken2025Context.Boeken.SingleOrDefault(n => n.Id == id);

            if (boekEnt == null)
            {
                throw new Exception("No Boek found");
            }
            MapBoek(boekEnt, boek);

            boeken2025Context.SaveChanges();
        }

        public void DeleteBoek(int id)
        {
            var boek = boeken2025Context.Boeken.Find(id);
            if (boek == null)
                throw new Exception("No Boek found");
            boeken2025Context.Boeken.Remove(boek);
            boeken2025Context.SaveChanges();
        }

        private void MapBoek(Boek boekEnt, UpdateBoek boek)
        {
            boekEnt.Publicatiejaar = boek.Publicatiejaar;
            boekEnt.SchrijverId = boek.SchrijverId;
            boekEnt.AantalBladzijden = boek.AantalBladzijden;
            boekEnt.Titel = boek.Titel;
        }

        private FullBoek? MapBoek(Boek? boek)
        {
            if (boek == null) return null;
            return new FullBoek()
            {
                Id = boek.Id,
                Titel = boek.Titel,
                AantalBladzijden = boek.AantalBladzijden,
                Publicatiejaar = boek.Publicatiejaar,
                SchrijverId = boek.SchrijverId,
                SchrijverNaam = boek.Schrijver.Naam
            };
        }
    }
}