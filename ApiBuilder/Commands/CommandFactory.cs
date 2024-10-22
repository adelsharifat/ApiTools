using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBuilder.Commands
{
    public abstract class CommandFactory
    {
        public abstract Command CreateCommand(Command parentCommand);

        public static CommandFactory GetFactory(string commandType)
        {
            return commandType switch
            {
                "createapi" => new CreateApiCommand(),
                "module" => new ModuleCommand(),
                // Add other command factories here
                _ => throw new ArgumentException("Invalid command type")
            };

        }
    }
}
