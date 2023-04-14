using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SndAPI.Clients
{
    public interface IArshaService
    {
        Task<String> GetById(HttpClient httpClient, int id);
    }
}