using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using clients.Models;

namespace clients.Repo
{
    public interface IClient
    { 
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<Client>> GetListOfClients();
        void CreateClient(Client dataInput);
        void UpdateClient(Client dataInput);
        void DeleteClient(Client dataInput);
        string ApiStatus();
    }
}