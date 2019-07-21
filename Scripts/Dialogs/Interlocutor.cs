//SKRYPT ZROBIONY PRZEZ: tabulator

using UnityEngine;

public class Interlocutor : MonoBehaviour
{
    public string interlocutorName;
    public DialogTree[] dialogTrees;

    private void Awake()
    {
        if (GetComponent<NPC>() != null) { interlocutorName = GetComponent<NPC>().character.characterName; }
    }
}
