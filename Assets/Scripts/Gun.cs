using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [Header("Projectile")]
    [Tooltip("Projectile prefab to spawn when firing.")]
    public Projectile Projectile;

    [Tooltip("Where the projectile spawns from.")]
    public GameObject Muzzle;

    [Header("Gun System")]
    [Min(0f)]
    [Tooltip("Time in seconds between trigger pulls.")]
    public float AttackSpeed = 2f;

    [Min(1)]
    [Tooltip("Bullets fired per trigger pull.")]
    public int BurstCount = 1;   // int makes more sense for a count

    [Min(0f)]
    [Tooltip("Timing between bullets within a burst.")]
    public float CycleTime = 0.2f;

    [Min(0f)]
    [Tooltip("Shot spread in degrees.")]
    public float Spread = 0f;


    public IEnumerator Fire()
    {

        for (int i = 0; i < BurstCount; i++)
        {
            var rotation = new Vector3(0, 0, Random.Range(-Spread, Spread));
            Projectile p = Instantiate(Projectile, Muzzle.transform.position, Quaternion.Euler(rotation));
            p.SetDirection(-transform.localScale.x);

            yield return new WaitForSeconds(CycleTime);
        }

        yield return null;

    }


}
