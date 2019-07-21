//SKRYPT ZROBIONY PRZEZ: tabulator

using UnityEngine;

[CreateAssetMenu(fileName = "Nowa Postać")]
public class Character : ScriptableObject
{
    [Header("Ogólne")]
    [Tooltip("Imię")]
    public string characterName;
    [Tooltip("Gildia (tu będzie lista ok)")]
    public byte characterGuild;
    [Tooltip("Poziom Agresji(?)(Jego znaczenie i działanie do obgadania)")]
    public byte behaviour;

    [Space]

    [Header("Bierne")]
    [Tooltip("Zdrowie postaci")]
    public float health;
    [Tooltip("Mana postaci")]
    public float mana;
    [Tooltip("Wytrzymałość postaci")]
    public float stamina;

    [Space]

    [Header("Główne")]
    [Tooltip("Siła postaci")]
    public float strength;
    [Tooltip("Zręczność postaci")]
    public float agility;
    [Tooltip("Moc postaci")]
    public float power; //force?

    [Space]

    [Header("Wprawy w Walce")]
    [Tooltip("Fechtunek (broń szybka)")]
    public byte fencing;
    [Tooltip("Broń drzewcowa")]
    public byte polearms;
    [Tooltip("Miecze")]
    public byte swords;
    [Tooltip("Topory i obuchy")]
    public byte axesNBlunts;
    [Tooltip("Broń ciężka (dwuręczna)")]
    public byte twoHanded;
    [Tooltip("Łuki")]
    public byte bows;
    [Tooltip("Kusze")]
    public byte crossbows;
    [Tooltip("Dmuchawki")]
    public byte blowers;

    [Space]

    [Header("Specjalizacje w Walce")]
    [Tooltip("Dwie Bronie")]
    public bool twoWeapons;
    [Tooltip("Parowanie")]
    public bool parrying;
    [Tooltip("Uniki")]
    public bool dodge;
    [Tooltip("Rozbrajanie")]
    public bool disarming;

    [Space]

    [Header("Wprawy w Magii")]
    [Tooltip("Siła woli")]
    public byte willpower;
    [Tooltip("Opatrzność natury")]
    public byte providence;
    [Tooltip("Wiedza")]
    public byte knowledge;

    [Space]

    [Header("Specjalizacje w Magii")]
    [Tooltip("Regeneracja Many")]
    public bool manaRegen;

}
