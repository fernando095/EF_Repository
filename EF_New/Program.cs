using System;
using System.Collections.Generic;
using System.Linq;

namespace EF_New
{
    class Program
    {
        static void Main(string[] args)
        {
            //Inserir();
            Listar();
            InserirEstudanteEnderecoRelacional();
            //Excluir();
            //Editar();
            Listar();

            Console.ReadLine();
        }

        static void Editar()
        {
            Estudante result;
            using (var context = new ApplicationDbContext())
            {
                result = context.Estudantes.Where(x => x.Nome == "Fernando").FirstOrDefault();
                result.Nome = "Fernando";
                context.Estudantes.Update(result);
                context.SaveChanges();

            }
        }
        static void Excluir()
        {
            using (var context = new ApplicationDbContext())
            {
                var filter = context.Estudantes.Where(x => x.Nome == "Fernando").FirstOrDefault();
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
                    Console.WriteLine(item);
                }
            }
        }
        static void Inserir()
        {
            using (var context = new ApplicationDbContext())
            {
                Estudante estudantes = new Estudante()
                {
                    Nome = "Fernando"
                };
                context.Add(estudantes);

                context.SaveChanges();
            }
            Console.WriteLine("Salvou");
        }

        static void InserirEstudanteEndereco()
        {
            Estudante estudante = new Estudante()
            {
                Nome = "Estudante 1",
                Idade = 22,
                Enderecos = new Endereco()
                {
                    Rua = "Jamelao"
                }
            };

            using (var context = new ApplicationDbContext())
            {
                context.Add(estudante);
                context.SaveChanges();
            }
        }
        static void InserirEstudanteEnderecoRelacional()
        {
            Estudante estudante = new Estudante()
            {
                Id = 1
            };
            Endereco endereco = new Endereco()
            {
                EstudanteId = estudante.Id,
                Rua = "Rua 1"
            };

            using (var context = new ApplicationDbContext())
            {
                context.Enderecos.Add(endereco);
                context.SaveChanges();
            }
        }
    }
    class Estudante
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public int Idade { get; set; }

        public Endereco Enderecos { get; set; }

        public int TurmaId { get; set; }


        public override string ToString()
        {
            return "Id: " + Id + " Nome: " + Nome;
        }
    }

    class Endereco
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public int EstudanteId { get; set; }
    }
    class Turma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Estudante> Estudantes { get; set; }
    }
}
