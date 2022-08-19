using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringTable
{
    public StringTable(string[] split)
    {
        key = split[0];
        desc = split[1];
    }
    private static Dictionary<string, StringTable> STR_DIC;


    public string key;
    public string desc;


    public static string GET_SCRIPT_NAME()
    {
        return "StringTable.csv";
    }
    public static bool INIT()
    {
        STR_DIC = new Dictionary<string, StringTable>();

        string[] column = DocumentManager.ReadFile(GET_SCRIPT_NAME());
        foreach(var str in column)
        {
            string[] split = str.Split(',');

            StringTable table = new StringTable(split);

            STR_DIC.Add(split[0], table);
        }

        return true;
    }
    public static StringTable GET(string key)
    {
        if (STR_DIC == null)
            return null;

        if (STR_DIC.ContainsKey(key) == false)
            return null;

        return STR_DIC[key];
    }
}
