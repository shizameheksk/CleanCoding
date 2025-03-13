﻿
using System.Net.Security;

namespace TemplateEngine;

public class Class1
{

}

public class TemplateEngine
{
    private string template;
    private Dictionary<string, string> variables = new Dictionary<string, string>();

    public string Evaluate()
    {
        string result = template;
        foreach (var variable in variables)
        {
            result = result.Replace("{" + variable.Key + "}", variable.Value);
        }
        return result;
    }

    public void SetTemplate(string template)
    {
        this.template = template;
    }

    public void SetVariable(string name, string value)
    {
        variables[name] = value;
    }
}

