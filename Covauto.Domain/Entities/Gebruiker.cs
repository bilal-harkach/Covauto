﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covauto.Domain.Entities
{
    public class Gebruiker
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public virtual ICollection<Auto>? Autos { get; set; }
    }
}
