//SKRYPT ZROBIONY PRZEZ: tabulator

using UnityEngine;

public class PlayerStatistics : MonoBehaviour
{
    public GameObject target;

    [HideInInspector] public float movementSpeed;
    [HideInInspector] public float jumpForce;
    [HideInInspector] public bool jumped;

    public byte playerGuild;

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

    [Space]

    [Header("Machlojstwo")]
    public byte dishonesty;
    [Tooltip("Ogłuszanie/skrytobójstwo")]
    public bool takedowns;
    [Tooltip("Kradzież")]
    public bool robbery;
    [Tooltip("Włamywanie")]
    public bool hacking;

    [Space]

    [Header("Charyzma")]
    public byte charisma;
    [Tooltip("Perswazja")]
    public bool persuasion;
    [Tooltip("Zastraszanie")]
    public bool intimidate;
    [Tooltip("Targowanie")]
    public bool bargaining;

    [Space]

    [Header("Rzemieślnictwo")]
    public byte craftsmanship;
    [Tooltip("Kowalstwo")]
    public bool smithing;
    [Tooltip("Płatnerstwo")]
    public bool armoring;
    [Tooltip("Łuczarstwo")]
    public bool fletching;
    [Tooltip("Strzały i bełty")]
    public bool arrowsNBolts;
    [Tooltip("Górnictwo")]
    public bool mining;
    [Tooltip("Stolarstwo")]
    public bool carpentry;
    [Tooltip("Browarnictwo")]
    public bool brewing;

    [Space]

    [Header("Alchemia")]
    public byte alchemy;
    [Tooltip("Napoje")]
    public bool potions;
    [Tooltip("Petardy")]
    public bool petards;
    [Tooltip("Oleje")]
    public bool oils;
    [Tooltip("Uprawa ziół")]
    public bool cropping;

    [Space]

    [Header("Inne")]
    [Tooltip("Odporność na zatrucie")]
    public bool poisonImmune;
    [Tooltip("Odporność na osłabienie")]
    public bool weaknessImmune;
    [Tooltip("Odporność na ogłuszenie")]
    public bool stunImmune;
    [Tooltip("Mocna głowa")]
    public bool strongHead;
    [Tooltip("Pływanie")]
    public bool swimming;
    [Tooltip("Wspinaczka")]
    public bool climbing;
    [Tooltip("Skradanie")]
    public bool sneaking;
    [Tooltip("Gotowanie")]
    public bool cooking;

    private void Awake()
    {
        movementSpeed = FindObjectOfType<GameManager>().humanSpeed;
        jumpForce = FindObjectOfType<GameManager>().humanJumpForce;
    }

    private void OnCollisionEnter(Collision collision)
    {
        jumped = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Interactable") { target = other.gameObject; }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == target) { target = null; }
    }

}
