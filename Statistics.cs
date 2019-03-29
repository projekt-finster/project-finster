// SKRYPT ZROBIONY PRZEZ: tabulator

using UnityEngine;

public class Statistics : MonoBehaviour
{
    // c -> character
    private string c_Name;
    private string c_Guild;

    // zmienna którą tppcontroller będzie porzyczał,
    // gdyż nawet linkując w controlerze rigidbody
    // funkcja OnCollisionEnter(); nie zbiera kolizji
    [HideInInspector]public bool jumped;

    private void OnCollisionEnter(Collision collision)
    {
        jumped = false;
    }
}
