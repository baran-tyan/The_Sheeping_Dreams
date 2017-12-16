using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{

    void OnGUI()
    {
        if (GUI.Button(new Rect(30, 70, 400, 65), "Начать игру"))
        {
            print("Игра началась");
            Application.LoadLevel("PrevievCourseProject");
        }

        if (GUI.Button(new Rect(30, 465, 400, 40), "Выход"))
        {
            print("Выход из игры");
            Application.Quit();
            //Application.LoadLevel("PrevievCourseProject");
        }

    }
}
