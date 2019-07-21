//SKRYPT ZROBIONY PRZEZ: tabulator

using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    private Interlocutor inter;
    private bool conversationContinues;
    private short dialogTreeId;
    private short dialogState;
    private short quoteState;

    public GameObject dialogCanvas;
    public TextMeshProUGUI interlocutorNameText;
    public TextMeshProUGUI textToSay;
    public TextMeshProUGUI spaceToSkip;

    private void Awake()
    {
        dialogCanvas.SetActive(false);
        conversationContinues = false;
    }

    private void Update()
    {
        if(conversationContinues)
        {
            if(inter.dialogTrees[dialogTreeId].dialogs[dialogState].quotes[quoteState].personSaying) { interlocutorNameText.text = "Bohater"; }
            else { interlocutorNameText.text = inter.interlocutorName; }

            textToSay.text = inter.dialogTrees[dialogTreeId].dialogs[dialogState].quotes[quoteState].quote;

            if (Input.GetButtonDown("Jump"))
            {
                quoteState++;
                if (quoteState == inter.dialogTrees[dialogTreeId].dialogs[dialogState].quotes.Length)
                {
                    quoteState = 0;
                    dialogState = inter.dialogTrees[dialogTreeId].dialogs[dialogState].nextDialog;
                    if (dialogState == -1) { conversationContinues = false; stopConversation(); }
                }
            }
        }
    }

    public void startConversation(GameObject interlocutor)
    {
        inter = interlocutor.GetComponent<Interlocutor>();
        dialogCanvas.SetActive(true);
        conversationContinues = true;
        FindObjectOfType<Controller>().freezePlayer(true);
        dialogTreeId = 0;
        dialogState = 0;
        quoteState = 0;
    }

    public void stopConversation()
    {
        dialogCanvas.SetActive(false);
        FindObjectOfType<Controller>().freezePlayer(false);
    }
}
