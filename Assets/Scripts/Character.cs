using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Characters", order = 1)]
public class Character : ScriptableObject
{

    [Header("Character Info")]
    public string Name;
    public string Description;

    [Header("Character Visuals")]
    public RuntimeAnimatorController Animator;
    public Sprite Icon;


    [Header("Character Stats")]
    public float MovementSpeed = 1;
    public float Health = 5;

}
