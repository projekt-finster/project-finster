//SKRYPT ZROBIONY PRZEZ: tabulator

using UnityEngine;

[CreateAssetMenu(fileName = "New DialogTree")]
public class DialogTree : ScriptableObject
{
    [Tooltip("Tu wrzuć wszystkie 'dialogs' do danego drzewka.\n Liczba występująca po słowie Element to numer danej 'dialog' w drzewku.\n Tam gdzie pisze size wpisz numer odpowiadający ilości 'dialogs' jakie chcesz zapakować do drzewka.")]
    public Dialog[] dialogs;
}
