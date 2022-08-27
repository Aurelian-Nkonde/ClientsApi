using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using clients.Models;
using clients.Data;
using Microsoft.EntityFrameworkCore;

namespace clients.Repo
{
    public  class RepoClients : IClient
    {
        private readonly ApplicationDbContext _databaseContext;

        public RepoClients(ApplicationDbContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public string ApiStatus()
        {
            return $"Api is working fine, active";
        }

        public void CreateClient(Client dataInput)
        {
            _databaseContext.clients.Add(dataInput);
            _databaseContext.SaveChanges();
        }

        public void DeleteClient(Client dataInput)
        {
            _databaseContext.clients.Remove(dataInput);
            _databaseContext.SaveChanges();
        }

        public async Task<IEnumerable<Client>> GetListOfClients()
        {
            List<Client> clients = await _databaseContext.clients.ToListAsync();
            return clients; 
        }



        public async Task<bool> SaveChangesAsync()
        {
            return (await _databaseContext.SaveChangesAsync() >= 1);
        }

        public void UpdateClient(Client dataInput)
        {
            _databaseContext.Entry(dataInput).State = EntityState.Modified;
            _databaseContext.SaveChanges();
        }
    }
}