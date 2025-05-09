using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covauto.Domain.Entities
{
    public class Auto
    {
        public int Id { get; set; }
        public string naamAuto { get; set; }
        public string kilometerstand { get; set; }
        public string startAdres { get; set;}
        public string eindAdres { get; set; }
        public bool beschikbaarheid { get; set;}
        //public int SchrijverId { get; set; }
        //public virtual Schrijver? Schrijver { get; set; }
    }
}
