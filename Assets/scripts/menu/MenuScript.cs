using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    void OnGUI()
    {
        if (GUI.Button(new Rect(50,20,100,100),"Начать игру"))
        {
            print("Игра началась");
            Application.LoadLevel("almost_died");
        }
            
    }
}
