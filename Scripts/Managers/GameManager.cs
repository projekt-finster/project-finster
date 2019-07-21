//SKRYPT ZROBIONY PRZEZ: tabulator

using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject player;

    [Header("Offset Kamery względem bohatera")]
    [Tooltip("Jak daleko ma być kamera od gracza?")]
    public float offsetFromPlayer;
    [Tooltip("O ile wyżej ma być kamera od gracza")]
    public float offsetY;

    [Space]

    [Header("Ogólne Statystyki: Humanoidzi")]
    [Tooltip("Prędkość poruszania się")]
    public float humanSpeed;
    [Tooltip("Siła z jaką wyskoczy w górę człowiek")]
    public float humanJumpForce;
    [Tooltip("Zasięg widzenia humanoidów")]
    public float humanLookDistance;

    private void Awake()
    {
        player = FindObjectOfType<PlayerStatistics>().gameObject;
    }

    public void playerInteraction()
    {
        GameObject targetedObject = FindObjectOfType<PlayerStatistics>().target;
        if (targetedObject != null)
        {
            if (targetedObject.GetComponent<Interlocutor>() != null) { FindObjectOfType<DialogManager>().startConversation(targetedObject); }
        }
    }
}
