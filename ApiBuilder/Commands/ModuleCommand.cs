using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBuilder.Commands
{
    public class ModuleCommand : CommandFactory
    {
        public override Command CreateCommand(Command parentCommand = null!)
        {
            var testOption = new Option<string>("--test", "Stored Procedure Name");
         
            var command = new Command(this.GetType().Name.Replace("Command",null).ToLower(), "Generates an API client from SQL procedures")
            {
                testOption
            };

            if (parentCommand != null)
                parentCommand.AddCommand(command);

            command.SetHandler(CommandHandler, testOption);

            return command;
        }

        private void CommandHandler(string arg1)
        {
            Console.Write($"Executed {this.GetType().Name}");
        }
    }
}
