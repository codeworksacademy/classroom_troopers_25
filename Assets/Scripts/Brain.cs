using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class Brain : MonoBehaviour
{

    public Gun StompGun;
    public Gun TailGun;
    public Collider2D ChargeCollider;

    private float MaxTransitionTime = 3;
    private float _timeTillTransition = 0;

    private string _currentState = "Idle";

    private List<string> _states = new()
    {
        // "Idle",
        // "Walk",
        "Fire",
        "StompAttack",
        "StartCharge"
    };


    private Animator _anim;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _timeTillTransition -= Time.deltaTime;

        if (_timeTillTransition <= 0)
        {
            _timeTillTransition = MaxTransitionTime;
            string nextState = _states[Random.Range(0, _states.Count)];
            _currentState = nextState;
            _anim.SetTrigger(_currentState);
        }
    }


    public void OnStompLanding()
    {
        StartCoroutine(StompGun.Fire());
    }
    public void FireTailGun()
    {
        StartCoroutine(TailGun.Fire());
    }

    public void StartCharging()
    {
        ChargeCollider.enabled = true;
    }
    public void EndCharging()
    {
        ChargeCollider.enabled = false;
    }





}
