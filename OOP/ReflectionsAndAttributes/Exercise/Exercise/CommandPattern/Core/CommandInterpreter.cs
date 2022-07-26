using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CommandPattern.Core.Commands;
using CommandPattern.Core.Contracts;
namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] splitArguments = args.Split(" ");

            string commandName = splitArguments[0];
            string[] commandArgs = splitArguments.Skip(1).ToArray();

            Assembly assembly = Assembly.GetEntryAssembly();
            Type commandType = assembly
                .GetTypes()
                .FirstOrDefault(c => c.Name == $"{commandName}Command" &&
                                    c.GetInterfaces().Any(x => x == typeof(ICommand)));

            if (commandType == null)
            {
                throw new ArgumentNullException($"Command type {commandName}Command not found");
            }

            ICommand command = Activator.CreateInstance(commandType) as ICommand;

            string result = command.Execute(commandArgs);

            return result;
        }
    }
}
