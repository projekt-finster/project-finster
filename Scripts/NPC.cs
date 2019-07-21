//SKRYPT ZROBIONY PRZEZ: tabulator

using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    public Character character;

    private Transform target;
    private NavMeshAgent agent;

    public float cHealth;
    public float cMana;
    public float cStamina;
    public float cStrength;
    public float cAgility;
    public float cPower;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        cHealth = character.health;
        cMana = character.mana;
        cStamina = character.stamina;
        cStrength = character.strength;
        cAgility = character.agility;
        cPower = character.power;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, FindObjectOfType<GameManager>().humanLookDistance);
    }
}
