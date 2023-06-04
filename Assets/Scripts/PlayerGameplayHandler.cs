using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The PlayerGameplayHandler class keeps track of events such as
/// taking damage, firing weapons, etc. It also keeps track of relevant
/// data such as ammo and HP.
/// </summary>
public class PlayerGameplayHandler : MonoBehaviour
{
    private float maxHitPoints = 100f;
    [SerializeField]
    private float hitPoints;
    [SerializeField]
    private bool isInvincible = false;

    // Start is called before the first frame update
    void Start()
    {
        hitPoints = maxHitPoints;
    }

    /// <summary>
    /// Detects all collisions
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage($"{collision.gameObject.name} collision", 20);
        }
    }

    /// <summary>
    /// Causes the player to take damage.
    /// </summary>
    /// <param name="source">The game object that caused the damage</param>
    /// <param name="damage">The amount of damage recieved</param>
    private void TakeDamage(string source, float damage)
    {
        if (!isInvincible)
        {
            hitPoints -= damage;
            Debug.Log($"Player took {damage} damage from {source}");
            StartCoroutine(BecomeTemporarilyInvincible(0.4f));
        }
    }

    /// <summary>
    /// Makes the player invulnerable to damage for the given amount of time.
    /// </summary>
    /// <param name="duration">The time (in seconds) for the player to be invulnerable</param>
    /// <returns></returns>
    private IEnumerator BecomeTemporarilyInvincible(float duration)
    {
        isInvincible = true;

        yield return new WaitForSeconds(duration);
        isInvincible = false;
    }

    private void shoot()
    {
       
    }
}

