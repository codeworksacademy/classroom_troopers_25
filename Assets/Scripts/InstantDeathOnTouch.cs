using System;
using System.Collections.Generic;
using UnityEngine;

public class InstantDeathOnTouch : MonoBehaviour
{
    public int Pierce = 1;

    public List<string> HurtObjectsWithTags = new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    void OnTriggerEnter2D(Collider2D other)
    {

        var canDamage = HurtObjectsWithTags.Find(tag => other.CompareTag(tag));

        if (canDamage != null)
        {
            Destroy(other.gameObject);

            Pierce--;
            if (Pierce <= 0)
            {
                // NOTE this is the ouchy
                Destroy(gameObject);
            }
        }

    }


}
