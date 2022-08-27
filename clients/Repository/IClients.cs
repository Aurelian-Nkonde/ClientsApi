using System;
using System.Collections.Generic;
using clients.Models;

namespace clients.Repo
{
    public interface IClient
    { 
        bool SaveChanges();
        IEnumerable<Client> GetListOfClients();
        void CreateClient(Client dataInput);
        void UpdateClient(Client dataInput);
        void DeleteClient(Client dataInput);
        string ApiStatus();
    }
}