using ApiBuilder.Helpers;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBuilder.Commands
{
    public class CreateApiCommand : CommandFactory
    {
        private FileInfo slnFileInfo = null;
        private string module = null;
        private string pattern = null;

        public override Command CreateCommand(Command parentCommand)
        {
            var module = new Option<string>(new string[] { "-m", "--module" }, () => "TemplateModule", "Module name");
            var pattern = new Option<string>(new string[] { "-p", "--pattern" }, () => "cqrs", "If true api created with cqrs design pattern folder structure. Avilable value empty | mvc | cqrs ");

            var command = new Command(this.GetType().Name.Replace("Command", null).ToLower(), "Create web api module")
            {
                pattern,
                module
            };

            parentCommand.AddCommand(command);

            command.SetHandler(CommandHandler, pattern, module);

            return command;
        }

        private void CommandHandler(string cqrs, string module)
        {
            ConsoleHelper.Handle(() =>
            {
                slnFileInfo = FileHelper.FilePathByExtention(".sln");

                if(slnFileInfo is not null) SlnMessage();

                Validation();

           

            }, StartMessage, EndMessage);
        }

        private void StartMessage() => Console.WriteLine("Start Creating Module...");

        private void SlnMessage() => ConsoleHelper.WriteLineColorize($"Solution {slnFileInfo.Name}", ConsoleColor.Cyan);

        private void EndMessage() => Console.WriteLine("Create module success!");

        private void Validation()
        {
            
            if (slnFileInfo is null)
                throw new FileNotFoundException("Solution file not found. Please use --solution or -sln");

            if (module is null)
                throw new FileNotFoundException("module name undefied. Please use --module or -m");

            if (pattern is null)
                throw new FileNotFoundException("desing pattern undefied. Please use --pattern or -p");
        }

        private void GenerateCqrsTemplate()
        {
            
        }




    }
}
