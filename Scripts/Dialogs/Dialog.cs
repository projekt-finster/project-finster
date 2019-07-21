//SKRYPT ZROBIONY PRZEZ: tabulator

using UnityEngine;

[CreateAssetMenu(fileName = "New Dialog")]
public class Dialog : ScriptableObject
{
    [Tooltip("Wpisz numer 'dialog' który ma się znaleźć po tym.\n Jeśli opcja ma zamknąć dialog, wpisz -1")]
    public short nextDialog;

    public Quote[] quotes;
}
