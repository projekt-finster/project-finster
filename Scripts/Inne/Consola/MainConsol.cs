//By Blahkhan

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainConsol : MonoBehaviour
{

    public GameObject console;

    private void Update()
    {
        
    }

    //Odpowiada za chowanie i wysuwanie się konsoli
    void ShowCloaseConsole()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            if (console.active)
            {
                console.SetActive(false);
            }
            else
            {
                console.SetActive(true);
            }
        }
    }

}
