using DataCore.Infrastructure;
using DomainCore.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceCore
{
    public class ServiceCoreClient : IClientService
    {
        static public DataBaseFactory dbFactory;
        UnitOfWork utwk;

        public ServiceCoreClient()
        {
            dbFactory = new DataBaseFactory();
            utwk = new UnitOfWork(dbFactory);
        }


        public void AddClient(Client e)
        {
            utwk.getRepository<Client>().Add(e);
            utwk.Commit();
        }

        public void deleteClient(long id)
        {
            throw new NotImplementedException();
        }

        public void editClient(Client e)
        {
            utwk.getRepository<Client>().Update(e);
            utwk.Commit();
        }

        public Client findClientByID(int id)
        {
          return   utwk.getRepository<Client>().GetById(id);
        }

        public List<Client> findClientByIdContains(long id)
        {
            throw new NotImplementedException();
        }

        public List<Client> findClientByNom(string nom)
        {
            return utwk.getRepository<Client>().GetMany(t => t.Nom == "hah", null).ToList();
        }

        public List<Client> getAllClient()
        {
            return utwk.getRepository<Client>().GetMany(null, null).ToList();
        }
    }
    public interface IClientService
    {
        void AddClient(Client e);
        List<Client> getAllClient();
        Client findClientByID(int id);
        void editClient(Client e);
        void deleteClient(long id);
        List<Client> findClientByNom(string nom);

        List<Client> findClientByIdContains(long id);
    }
}
