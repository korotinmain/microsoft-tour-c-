using System;
using System.Threading.Tasks;

namespace WebApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var repositories = Processes.getRepositories().Result;

            foreach (var repo in repositories)
                System.Console.WriteLine(repo.Name);
        }
    }
}
