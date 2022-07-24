using System;
using System.Collections.Generic;
using System.Linq;
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

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder result = new StringBuilder();

            Type classType = Type.GetType(className);

            FieldInfo[] publicFields = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            MethodInfo[] publicMethods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            foreach (var publicField in publicFields)
            {
                result.AppendLine($"{publicField.Name} must be private!");
            }

            foreach (var privateMethod in privateMethods.Where(pm => pm.Name.StartsWith("get")))
            {
                result.AppendLine($"{privateMethod.Name} must be public!");
            }

            foreach (var publicMethod in publicMethods.Where(pm => pm.Name.StartsWith("set")))
            {
                result.AppendLine($"{publicMethod.Name} must be private!");
            }

            return result.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            StringBuilder result = new StringBuilder();

            Type classType = Type.GetType(className);

            MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            result.AppendLine($"All Private Methods of Class: {classType.Name}");
            result.AppendLine($"Base Class: {classType.BaseType.Name}");

            result.AppendLine(String.Join(Environment.NewLine, privateMethods.Select(x => x.Name)));

            return result.ToString().TrimEnd();
        }
    }
}
