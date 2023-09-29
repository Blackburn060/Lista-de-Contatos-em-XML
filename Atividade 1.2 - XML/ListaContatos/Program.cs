using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace SalvarContatosEmXML
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Contato> contatos = new List<Contato>();

            while (true)
            {

                Console.Clear();

                Console.WriteLine("Escolha uma opção: \n1- Adicionar Contato \n2- Sair");
                string opcao = Console.ReadLine();

                if (opcao.ToLower() == "2")
                    break;

                Console.Clear();

                Console.WriteLine("Digite o nome do contato:");
                string nome = Console.ReadLine();

                Console.WriteLine("Digite o número de telefone do contato:");
                string telefone = Console.ReadLine();

                Console.WriteLine("Digite o e-mail do contato:");
                string email = Console.ReadLine();

                Contato contato = new Contato(nome, telefone, email);
                contatos.Add(contato);
            }

            Console.Clear();

            SalvarContatosEmXML(contatos);
            Console.WriteLine("Contatos salvos em arquivo XML.");
        }

        static void SalvarContatosEmXML(List<Contato> contatos)
        {
            XElement xmlContatos = new XElement("Contatos");

            foreach (Contato contato in contatos)
            {
                XElement xmlContato = new XElement("Contato",
                    new XElement("Nome", contato.Nome),
                    new XElement("Telefone", contato.Telefone),
                    new XElement("Email", contato.Email)
                );

                xmlContatos.Add(xmlContato);
            }

            string caminhoArquivo = "contatos.xml";
            xmlContatos.Save(caminhoArquivo);
        }
    }

    class Contato
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public Contato(string nome, string telefone, string email)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
        }
    }
}