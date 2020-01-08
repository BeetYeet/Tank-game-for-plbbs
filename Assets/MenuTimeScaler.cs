using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTimeScaler : MonoBehaviour
{
    void Update()
    {
        // för att lösa en bug då timescalen ändras till 0.1f när man en av spelarna dör. Ta ej bort!
        Time.timeScale = 1f;
    }
}
