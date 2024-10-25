using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface ILogApi
    {
        void Record(string error, string path, string method, string inputs);
    }
}