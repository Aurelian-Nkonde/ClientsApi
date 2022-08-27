using System;
using System.Collections.Generic;
using clients.Models;
using clients.Data;
using Microsoft.EntityFrameworkCore;

namespace clients.Repo
{
    public class RepoClients : IClient
    {
        private readonly ApplicationDbContext _databaseContext;

        public RepoClients(ApplicationDbContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public string ApiStatus()
        {
            return $"Api is working fine";
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

        public IEnumerable<Client> GetListOfClients()
        {
            List<Client> clients = _databaseContext.clients.ToList();
            return clients; 
        }


        public bool SaveChanges()
        {
            return (_databaseContext.SaveChanges() >= 1);
        }

        public void UpdateClient(Client dataInput)
        {
            _databaseContext.Entry(dataInput).State = EntityState.Modified;
            _databaseContext.SaveChanges();
        }
    }
}