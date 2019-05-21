using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    private TPPController player;
    private Text dialogText;
    public Vector3[] cameraAngles;
    public Transform cameraTarget;

    private void Awake()
    {
        player = FindObjectOfType<TPPController>();
        dialogText = GetComponent<Text>();
    }

    public void Conversation(GameObject interlocutor)
    {
        player.doMove = false;
        if (interlocutor.GetComponent<Interlocutor>().dialogs[0].speaker) { cameraTarget = interlocutor.transform; }
        else { cameraTarget = player.transform; }
    }
}
