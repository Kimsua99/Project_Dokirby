using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkTable : MonoBehaviour
{
    public TalkTable(string[] split)
    {
        TalkID = split[0];
        StringID = split[1];

        TalkType = int.Parse(split[2]);
        NameStringID = split[3];
        ImageType = int.Parse(split[4]);
        ImageID = split[5];
        AddImageType = int.Parse(split[6]);
        AddImageID = split[7];
    }

    private static Dictionary<string, TalkTable> STR_DIC;
    private static List<TalkTable> STR_LIST;


    public string TalkID;
    public string StringID;
    public int TalkType;
    public string NameStringID;
    public int ImageType;
    public string ImageID;
    public int AddImageType;
    public string AddImageID;   // "-1"은 의미없음

    public static string GET_SCRIPT_NAME()
    {
        return "TalkTable.csv";
    }
    public static bool INIT()
    {
        STR_DIC = new Dictionary<string, TalkTable>();
        STR_LIST = new List<TalkTable>();

        string[] column = DocumentManager.ReadFile(GET_SCRIPT_NAME());
        foreach (var str in column)
        {
            string[] split = str.Split(',');

            TalkTable table = new TalkTable(split);

            STR_DIC.Add(split[0], table);
            STR_LIST.Add(table);
        }

        return true;
    }
    public static TalkTable GET(string key)
    {
        if (STR_DIC == null)
            return null;

        if (STR_DIC.ContainsKey(key) == false)
            return null;

        return STR_DIC[key];
    }
    public static List<TalkTable> GET_LIST()
    {
        return STR_LIST;
    }
}
