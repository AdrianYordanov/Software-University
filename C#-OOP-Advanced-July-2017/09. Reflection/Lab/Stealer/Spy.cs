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
}