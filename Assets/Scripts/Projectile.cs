using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float Speed = 1;
    public float Lifetime = 3;
    private float direction = 1;


    public void SetDirection(float x)
    {
        direction = x;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Speed * Time.deltaTime * transform.right;
        Lifetime -= Time.deltaTime;

        if (Lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Projectile Hit Something: " + other.tag);
        if (other.CompareTag("Wall"))
        {
            Debug.Log("Projectile Hit Wall");
            Destroy(gameObject);
        }
    }


}
