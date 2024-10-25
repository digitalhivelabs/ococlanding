using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Semaphore = API.Entities.Semaphore;

namespace API.Interfaces
{
    public interface ISemaphoreRepository: ICommonRepository<Semaphore>
    {
        Semaphore GetByName(string NameOrAbbr);
    }
}