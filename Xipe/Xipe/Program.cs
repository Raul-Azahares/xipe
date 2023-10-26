using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xipe
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Entity> List1 = new List<Entity>
        {
            new Entity { Name = "Process1", Id = 1, TimeProcess = 3 },
            new Entity { Name = "Process2", Id = 2, TimeProcess = 2 },
            new Entity { Name = "Process3", Id = 3, TimeProcess = 4 },
            new Entity { Name = "Process4", Id = 4, TimeProcess = 3 },
            new Entity { Name = "Process5", Id = 5, TimeProcess = 5 }
        };

            List<Entity> List2 = new List<Entity>
        {
            new Entity { Name = "Proces3", Id = 3, TimeProcess = 4 },
            new Entity { Name = "Proces4", Id = 4, TimeProcess = 3 },
            new Entity { Name = "Proces6", Id = 6, TimeProcess = 2 },
            new Entity { Name = "Proces7", Id = 7, TimeProcess = 6 },
            new Entity { Name = "Proces8", Id = 8, TimeProcess = 2 }
        };
            // Merge and remove repeats
            List<Entity> CleanList = List1.Union(List2).Distinct(new EntityComparer()).ToList();

            // Correr los procesos en simultáneo
            var tasks = CleanList.Select(Entity => Entity.Correr()).ToArray();

            Task.WhenAll(tasks).Wait();
        }
    }


    class Entity
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int TimeProcess { get; set; }

        public async Task Correr()
        {
            Console.WriteLine($"The process {Name} with ID {Id} has started.");
            await Task.Delay(TimeProcess * 1000); // Wait 
            Console.WriteLine($"The process {Name} with ID {Id} has finished.");
        }
    }
    class EntityComparer : IEqualityComparer<Entity>
    {
        public bool Equals(Entity x, Entity y)
        {
            return x.Name == y.Name && x.Id == y.Id;
        }

        public int GetHashCode(Entity obj)
        {
            return obj.Name.GetHashCode() ^ obj.Id.GetHashCode();
        }
    }
}
