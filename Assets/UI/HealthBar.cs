using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Destructable))]
public class HealthBar : MonoBehaviour
{
    [Header("UI References")]
    public Image GreenBar;
    public Image YellowBar;


    [Header("Health")]
    public Destructable destructable;
    private float MaxHealth { get => destructable.MaxHealth; }
    private float CurrentHealth { get => destructable.CurrentHealth; }


    [Header("Lerp Settings")]
    public float greenSnapSpeed = 8f;       // speed for green snap
    public float yellowDrainSpeed = 2f;   // slower yellow drain

    void Start()
    {
        destructable = GetComponent<Destructable>();
    }

    void Update()
    {
        float targetFill = CurrentHealth / MaxHealth;

        GreenBar.fillAmount = Mathf.Lerp(GreenBar.fillAmount, targetFill, Time.deltaTime * greenSnapSpeed);
        if (YellowBar != null)
        {
            YellowBar.fillAmount = Mathf.Lerp(YellowBar.fillAmount, targetFill, Time.deltaTime * yellowDrainSpeed);
        }

    }

}
