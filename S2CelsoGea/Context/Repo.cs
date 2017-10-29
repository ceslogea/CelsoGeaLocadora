using S2CelsoGea.Context.ContextModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace S2CelsoGea.Context
{
    public class Repo<T> : IDisposable where T : EntityBase
    {
        /// <summary>
        /// Instancia do DataBase.
        /// </summary>
        protected readonly S2CelsoGeaContext db;

        /// <summary>
        /// Objeto T em memória volátil pela chamada de sua Interface.
        /// </summary>
        private DbSet<T> Entity { get { return db.Set<T>(); } }

        public Repo()
        {
            db = new S2CelsoGeaContext();
        }

        public IEnumerable<T> List()
        {
            return Entity.AsEnumerable();
        }

        public T First(int id)
        {
            return Entity.FirstOrDefault(r=>r.Id == id);
        }

        public void Save(T obj)
        {
            if (obj.Id > 0)
                Update(obj);
            else
                Add(obj);
        }

        private void Add(T obj)
        {
            Entity.Add(obj);
            Commit();
        }

        private void Update(T obj)
        {
            var old = Entity.Find(obj.Id);
            var entry = db.Entry(old);
            entry.CurrentValues.SetValues(obj);
            Commit();
        }

        public void Delete(T obj)
        {
            if (obj.Id > 0)
            {
                var old = Entity.Find(obj.Id);
                Entity.Remove(old);
                Commit();
            }
        }

        public void ExecuteQuery(string query)
        {
            db.Database.ExecuteSqlCommand(query);
            Commit();
        }

        private void Commit()
        {
            try
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}