using System.Collections.Generic;
using UnityEngine;

public class DamageApplier : MonoBehaviour
{
    public float Damage = .25f;
    public List<string> HurtObjectsWithTags = new();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {

        var canDamage = HurtObjectsWithTags.Find(tag => other.CompareTag(tag));

        if (canDamage != null)
        {
            var x = other.GetComponent<Destructable>();
            x.ApplyDamage(Damage);
        }

    }

}
