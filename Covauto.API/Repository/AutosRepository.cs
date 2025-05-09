using Covauto.Application.DTO.Boeken;
using Covauto.Domain.Data;
using Covauto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Covauto.API.Repositories
{
    public class AutosRepository
    {
        private readonly AutosContext autosContext;

        public AutosRepository(AutosContext autosContext)
        {
            this.autosContext = autosContext;
        }

       
}