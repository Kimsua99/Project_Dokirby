using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyView : UIView
{
    public void Start()
    {
        UIViewManager.Instance.GoView(View.tutorial, null);   
    }
}
