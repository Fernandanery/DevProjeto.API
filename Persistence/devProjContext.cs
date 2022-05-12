using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevProjeto.API.Entities;

namespace DevProjeto.API.Persistence
{
    public class devProjContext
    {
        public devProjContext() {
        Packeges = new List<Packege>();
        }
        public List<Packege> Packeges { get; set; }
        
        
    }
}