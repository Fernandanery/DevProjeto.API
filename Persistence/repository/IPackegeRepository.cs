using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevProjeto.API.Entities;

namespace DevProjeto.API.Persistence.repository
{
    public interface IPackegeRepository
    {
        List<Packege> GetAll();
        Packege GetByCode(string code);
        void Add(Packege packege);
        void Update(Packege packege);
    }
}