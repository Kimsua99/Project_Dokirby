using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

public class DocumentManager
{
    public static void Initialize()
    {
        if (StringTable.INIT() == false)
            Debug.LogError("StringTable Documnet Error");

        if(TalkTable.INIT() == false)
            Debug.LogError("TalkTable Documnet Error");

        if (TutorialTable.INIT() == false)
            Debug.LogError("TutorialTable Documnet Error");
    }


    public static string[] ReadFile(string fileName)
    {
        TextAsset textasset = Resources.Load<TextAsset>($"Docu/{fileName}");

        string[] lines = null;
        if (textasset != null)
            lines = textasset.text.Split('\n');
        else
            lines = null;

        return lines;
    }


}
