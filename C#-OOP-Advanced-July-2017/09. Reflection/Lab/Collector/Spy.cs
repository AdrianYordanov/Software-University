using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] fieldsName)
    {
        var classType = Type.GetType(className);
        var classFields = classType.GetFields(BindingFlags.Instance |
            BindingFlags.Static |
            BindingFlags.Public |
            BindingFlags.NonPublic);
        var searchedFields = classFields.Where(field => fieldsName.Contains(field.Name));
        var exampleInstance = Activator.CreateInstance(classType);
        var result = new StringBuilder();
        result.AppendLine($"Class under investigation: {classType}");
        foreach (var field in searchedFields)
        {
            result.AppendLine($"{field.Name} = {field.GetValue(exampleInstance)}");
        }

        return result.ToString();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        var result = new StringBuilder();
        var classType = Type.GetType(className);
        var publicFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public)
           .Select(field => $"{field.Name} must be private!");
        var privateGetters = classType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic)
           .Where(getter => getter.Name.StartsWith("get"))
           .Select(getter => $"{getter.Name} have to be public!");
        var publicSetters = classType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public)
           .Where(setter => setter.Name.StartsWith("set"))
           .Select(setter => $"{setter.Name} have to be private!");
        result.AppendLine(string.Join(Environment.NewLine, publicFields));
        result.AppendLine(string.Join(Environment.NewLine, privateGetters));
        result.AppendLine(string.Join(Environment.NewLine, publicSetters));
        return result.ToString();
    }

    public string RevealPrivateMethods(string className)
    {
        var classType = Type.GetType(className);
        var baseClass = classType.BaseType;
        var privateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        var result = new StringBuilder();
        result.AppendLine($"All Private Methods of Class: {className}");
        result.AppendLine($"Base Class: {baseClass.Name}");
        foreach (var privateMethod in privateMethods)
        {
            result.AppendLine(privateMethod.Name);
        }

        return result.ToString();
    }

    public string CollectGettersAndSetters(string className)
    {
        var classType = Type.GetType(className);
        var allMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        var getMethods = allMethods.Where(method => method.Name.StartsWith("get"));
        var setMethods = allMethods.Where(method => method.Name.StartsWith("set"));
        var result = new StringBuilder();
        foreach (var method in getMethods)
        {
            result.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (var method in setMethods)
        {
            result.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return result.ToString();
    }
}