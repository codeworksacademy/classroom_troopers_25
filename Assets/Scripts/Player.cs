using UnityEngine;

public class Player : MonoBehaviour
{

    public Character CharacterStats;

    private Destructable _destructable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        CharacterStats = GameManager.Instance.Player1;

        _destructable = GetComponent<Destructable>();
        _destructable.SetMaxHealth(CharacterStats.Health);
        _destructable.ApplyDamage(-CharacterStats.Health);
        GetComponent<Animator>().runtimeAnimatorController = CharacterStats.Animator;
    }

    // Update is called once per frame
    void Update()
    {
    }


    void OnDestroy()
    {
        Debug.Log("player is dead");
        GameManager.Instance.GoToMainMenu();
    }

}
