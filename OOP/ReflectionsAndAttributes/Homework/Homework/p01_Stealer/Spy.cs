using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldsNames)
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Class under investigation: {className}");

            Type classType = Type.GetType(className);
            object classInstance = Activator.CreateInstance(classType);

            foreach (var fieldName in fieldsNames)
            {
                FieldInfo hackerInfo = classType.GetField(fieldName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

                result.AppendLine($"{fieldName} = {hackerInfo.GetValue(classInstance)}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
