using ApiBuilder.Commands;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace ApiBuilder
{
    class Program
    {
        static int Main(string[] args)
        {
            var rootCommand = new RootCommand();
            
            CommandFactory.GetFactory("createapi").CreateCommand(rootCommand);

            rootCommand.Description = "CLI tools for creating aspnet core web api from microsoft sql server procedures and ...";
            
            return rootCommand.InvokeAsync(args).Result;
        }
    }
}
