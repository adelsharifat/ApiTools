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
        private FileInfo _slnFileInfo = null;
        private string _sln = null;
        private string _module = null;
        private string _pattern = null;

        private string[] _allowedPattern = new string[] { "cqrs", "mvc" }; 

        public override Command CreateCommand(Command parentCommand)
        {
            var sln = new Option<string>(new string[] { "-sln", "--sln" }, () => null, "Sln file");
            var module = new Option<string>(new string[] { "-m", "--module" }, () => "TemplateModule", "Module name");
            var pattern = new Option<string>(new string[] { "--pattern" }, () => "cqrs", "If true api created with cqrs design pattern folder structure. Avilable value empty | mvc | cqrs ");

            var command = new Command(this.GetType().Name.Replace("Command", null).ToLower(), "Create web api module")
            {
                sln,
                pattern,
                module
            };

            parentCommand.AddCommand(command);

            command.SetHandler(CommandHandler, sln, module, pattern);

            return command;
        }

        private void CommandHandler(string sln, string module, string pattern)
        {
            ConsoleHelper.Handle(() =>
            {
                _sln = sln;
                _module = module;
                _pattern = pattern;
              
                if (_sln is null)
                    _slnFileInfo = FileHelper.FilePathByExtention(".sln");
                else
                    _slnFileInfo = FileHelper.FilePathByName(_sln);

                if(_slnFileInfo is not null) SlnMessage();
            
                Validation();

                //continue building module at here

                GenerateModuleTemplate();




            }, StartMessage, EndMessage);
        }

        private void StartMessage() => Console.WriteLine("Start Creating Module...");

        private void SlnMessage() => ConsoleHelper.WriteLineColorize($"Solution {_slnFileInfo.Name}", ConsoleColor.Cyan);

        private void EndMessage() => Console.WriteLine("Create module success!");

        private void Validation()
        {
            
            if (_slnFileInfo is null)
                throw new FileNotFoundException("Solution file not found. Please use --sln or -sln");

            if (_module is null)
                throw new FileNotFoundException("Module name undefied. Please use --module or -m");

            if (_pattern is null)
                throw new FileNotFoundException("Design pattern undefied. Please use --pattern or -p");

            if(!_allowedPattern.Contains(_pattern, StringComparer.OrdinalIgnoreCase))
                throw new FileNotFoundException($"Invalid design pattern name. Avilable value are {string.Join(" | ", _allowedPattern)}");
        }

        private void GenerateModuleTemplate()
        {
            ConsoleHelper.Handle(() => {
                StringBuilder code = new StringBuilder();

                code.AppendLine("<Project Sdk=\"Microsoft.NET.Sdk\">");
                code.AppendLine();
                code.AppendIndent(1, "<PropertyGroup>").AppendLine();
                code.AppendIndent(2, "<TargetFramework>net6.0</TargetFramework>").AppendLine();
                code.AppendIndent(2, "<ImplicitUsings>enable</ImplicitUsings>").AppendLine();
                code.AppendIndent(2, "<Nullable>enable</Nullable>").AppendLine();
                code.DecreaseIndent(1, "</PropertyGroup>").AppendLine();
                code.AppendIndent(1, "<ItemGroup>").AppendLine();
                code.AppendIndent(2, "<Folder Include=\"Features\" />").AppendLine();
                code.AppendIndent(2, "<Folder Include=\"Data\" />").AppendLine();
                code.AppendIndent(2, "<Folder Include=\"Controllers\" />").AppendLine();
                code.DecreaseIndent(1, "</ItemGroup>").AppendLine();
                code.DecreaseIndent(2, "</Project>").AppendLine();








            });
        }




    }
}
