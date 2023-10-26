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
            List<Entidad> lista1 = new List<Entidad>
        {
            new Entidad { Nombre = "Proceso1", Id = 1, TiempoProceso = 3 },
            new Entidad { Nombre = "Proceso2", Id = 2, TiempoProceso = 2 },
            new Entidad { Nombre = "Proceso3", Id = 3, TiempoProceso = 4 },
            new Entidad { Nombre = "Proceso4", Id = 4, TiempoProceso = 3 },
            new Entidad { Nombre = "Proceso5", Id = 5, TiempoProceso = 5 }
        };

            List<Entidad> lista2 = new List<Entidad>
        {
            new Entidad { Nombre = "Proceso3", Id = 3, TiempoProceso = 4 },
            new Entidad { Nombre = "Proceso4", Id = 4, TiempoProceso = 3 },
            new Entidad { Nombre = "Proceso6", Id = 6, TiempoProceso = 2 },
            new Entidad { Nombre = "Proceso7", Id = 7, TiempoProceso = 6 },
            new Entidad { Nombre = "Proceso8", Id = 8, TiempoProceso = 2 }
        };

            // Combinar y eliminar repetidos
            List<Entidad> listaLimpia = lista1.Union(lista2).Distinct(new EntidadComparer()).ToList();

            // Correr los procesos en simultáneo
            var tasks = listaLimpia.Select(entidad => entidad.Correr()).ToArray();

            Task.WhenAll(tasks).Wait();
        }
    }


    class Entidad
    {
        public string Nombre { get; set; }
        public int Id { get; set; }
        public int TiempoProceso { get; set; }

        public async Task Correr()
        {
            Console.WriteLine($"El proceso {Nombre} con ID {Id} ha iniciado.");
            await Task.Delay(TiempoProceso * 1000); // Espera en milisegundos
            Console.WriteLine($"El proceso {Nombre} con ID {Id} ha finalizado.");
        }
    }
    class EntidadComparer : IEqualityComparer<Entidad>
    {
        public bool Equals(Entidad x, Entidad y)
        {
            return x.Nombre == y.Nombre && x.Id == y.Id;
        }

        public int GetHashCode(Entidad obj)
        {
            return obj.Nombre.GetHashCode() ^ obj.Id.GetHashCode();
        }
    }
}
