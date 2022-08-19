using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTable
{
    public TutorialTable(string[] split)
    {
        TutorialID = split[0];
        ImageID = split[1];
        NameStringID = split[2];
        ExplanStringID = split[3];
    }
    private static Dictionary<string, TutorialTable> STR_DIC;

    public string TutorialID;
    public string ImageID;
    public string NameStringID;
    public string ExplanStringID;

    public static string GET_SCRIPT_NAME()
    {
        return "TutorialTable.csv";
    }
    public static bool INIT()
    {
        STR_DIC = new Dictionary<string, TutorialTable>();

        string[] column = DocumentManager.ReadFile(GET_SCRIPT_NAME());
        foreach (var str in column)
        {
            string[] split = str.Split(',');
            TutorialTable table = new TutorialTable(split);
            STR_DIC.Add(split[0], table);
        }

        return true;
    }
    public static TutorialTable GET(string key)
    {
        if (STR_DIC == null)
            return null;

        if (STR_DIC.ContainsKey(key) == false)
            return null;

        return STR_DIC[key];
    }





}
