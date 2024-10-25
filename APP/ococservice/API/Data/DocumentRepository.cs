using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using API.Entities;

namespace API.Data
{
    public class DocRepository : CommonRepository<Documento>, IDocRepository
    {
        private readonly DataContex _context;
        private readonly IMapper _mapper;

        public DocRepository(DataContex context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // public void Add(Documento document)
        // {
        //     _context.Entry(document).State = EntityState.Added;
        // }        

        public async Task<IEnumerable<Documento>> GetDocumentsAsync()
        {
            return await _context.Documentos.OrderBy(d => d.Title).ToListAsync();
        }

        // public async Task<bool> SaveAllAsync()
        // {
        //     return await _context.SaveChangesAsync() > 0;
        // }

        // public void Update(Documento document)
        // {
        //     _context.Entry(document).State = EntityState.Modified;
            
        // }
    }

}