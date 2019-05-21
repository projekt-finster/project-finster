using UnityEngine;

[CreateAssetMenu(fileName = "New Dialog")]
public class Dialog : ScriptableObject
{
    [Tooltip("Tu wprowadź wypowiedź podmiotu")]
    public string quoteToSay;
    [Tooltip("Odznacz jeśli mówić ma gracz i na odwrót")]
    public bool speaker;
    [Tooltip("Wartość potrzebna do wyświetlenia kwestii dialogowej")]
    public byte quoteId;
    [Tooltip("Wartość dialogu który ma zostać wyświetlony po tym")]
    public byte nextQuoteId;
}
