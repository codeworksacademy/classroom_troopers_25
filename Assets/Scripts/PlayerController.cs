using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 _movementInput = new();
    private Rigidbody2D _rb;
    private Animator _anim;
    private Player _player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetButtonDown("Pause"))
        {
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        }


        _movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _movementInput.Normalize();


        if (_movementInput.x > .1f)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if (_movementInput.x < -.1f)
        {
            transform.localScale = new Vector2(1, 1);
        }

        if (Math.Abs(_movementInput.magnitude) > .1f)
        {
            _anim.SetBool("isWalking", true);
        }
        else
        {
            _anim.SetBool("isWalking", false);
        }

    }

    // Called once per physics tick
    void FixedUpdate()
    {
        _rb.linearVelocity = _movementInput * (_player?.CharacterStats?.MovementSpeed ?? 1);
    }

    public void OnDeath()
    {
        _anim.enabled = false;
        enabled = false;
    }

}
