using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IDocRepository: ICommonRepository<Documento>
    {
        /*
        void Update(Documento document);
        void Add(Documento document);
        Task<bool> SaveAllAsync();
        */
        Task<IEnumerable<Documento>> GetDocumentsAsync();
    }
}