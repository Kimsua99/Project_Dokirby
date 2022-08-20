using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChange : MonoBehaviour
{
    public string patternName = "";

    public void GetPattern(string Name)
    {
        patternName = Name;
        switch (Name)
        {
            case "spring" : ChangeSpring();
                break;
            case "Umbrella": ChangeUmbrella();
                break;

            default:
                break;
        }
    }

    public void ChangeSpring()
    { 
        
    }

    public void ChangeUmbrella()
    {

    }
}
