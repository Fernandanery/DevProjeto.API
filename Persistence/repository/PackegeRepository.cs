using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevProjeto.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevProjeto.API.Persistence.repository
{
    public class PackegeRepository : IPackegeRepository
    {
        private readonly devProjContext _context;
        public PackegeRepository(devProjContext context)
        {
            _context = context;
        }

        public void Add(Packege packege)
        {
           _context.Packeges.Add(packege);
           _context.SaveChanges();

        }

        public List<Packege> GetAll()
        {
            return _context.Packeges.ToList();
        }

        public Packege GetByCode(string code)
        {
            return _context
            .Packeges
            .Include(p => p.Updates)
            .SingleOrDefault(p => p.Code == code);
        }

        public void Update(Packege packege)
        {
            _context.Entry(packege).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}