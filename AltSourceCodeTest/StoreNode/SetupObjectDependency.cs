using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UseCase;
using UseCase.Persistance;

namespace StoreNode
{
    public static class InitObjectAndDependency
    {
        public static void Setup()
        {
            IPersistance persistance = new InMemoryDb();

            StoreLogic.HardSetupSingletonStore(persistance);
        }
    }
}
