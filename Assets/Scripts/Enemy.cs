using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject Target;
    public float MovementSpeed = 2;

    private Animator _anim;
    private float _cooldown = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_cooldown > 0)
        {
            _cooldown -= Time.deltaTime;
            return;
        }
        _anim.SetBool("isRunning", Target);
        if (!Target) { return; }

        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, Time.deltaTime * MovementSpeed);

        if (Target.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _anim.SetTrigger("Attack");
            _cooldown = 1;
        }
    }


}
