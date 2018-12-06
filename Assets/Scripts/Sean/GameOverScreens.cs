// Sean Anderson

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreens : scoreupdatescript
{

    void OnGUI()
    {
        GUIStyle fontStyle = new GUIStyle(GUI.skin.GetStyle("label"));
        fontStyle.fontSize = 32;
        fontStyle.normal.textColor = Color.white;

        stringToEdit = GUI.TextField(new Rect((Screen.width/2)-350, 0, 700, 50), "<b>You had a score of </b>" + score.ToString() + "<b>! You needed 20 to win.</b>", fontStyle);
    }
}