using System.Collections;
using UnityEngine;

public class AutoGun : Gun
{

    [SerializeField, Tooltip("Time remaining before the next allowed shot.")]
    private float _lastAttack = 0f;

    // Update is called once per frame
    void Update()
    {

        _lastAttack -= Time.deltaTime;

        if (_lastAttack <= 0)
        {
            StartCoroutine(Fire());
        }

    }



}
