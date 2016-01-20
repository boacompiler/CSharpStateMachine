using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineTest.Classes
{
    class EntityManager
    {
        private List<BaseEntity> entity;
        
        private static readonly EntityManager instance = new EntityManager();

        internal static EntityManager Instance
        {
            get
            {
                return instance;
            }
        }

        private EntityManager()
        {
            entity = new List<BaseEntity>();
        }

        public void RegisterEntity(BaseEntity register)
        {
            entity.Add(register);
        }
        public BaseEntity GetEntityByID(int entityID)
        {
            return entity.Find(e => e.ID == entityID);
        }
        public void RemoveEntity(BaseEntity register)
        {
            entity.Remove(register);
        }
    }
}
