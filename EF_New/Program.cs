using System;
using System.Linq;

namespace EF_New
{
    class Program
    {
        static void Main(string[] args)
        {
            //Inserir();
            Listar();
            Excluir();
            Listar();
            Estudante fernando = new Estudante();
            
            Console.ReadLine();
        }

        static void Excluir()
        {
            using( var context = new ApplicationDbContext())
            {
                var filter = context.Estudantes.Where(x => x.Nome == "Roberto").FirstOrDefault();
                context.Remove(filter);
                context.SaveChanges();
            }
        }
        static void Listar()
        {
            using (var context = new ApplicationDbContext())
            {
                var estudante = context.Estudantes.ToList();
                foreach (var item in estudante)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
        static void Inserir()
        {
            using (var context = new ApplicationDbContext())
            {
                Estudante estudantes = new Estudante()
                {
                    Nome = "Francisco"
                };
                context.Add(estudantes);

                context.SaveChanges();
            }
            Console.WriteLine("Salvou");
        }
    }

    class Estudante
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public override string ToString()
        {
            return "Id: " + Id + " Nome: " + Nome;
        }
    }
}
