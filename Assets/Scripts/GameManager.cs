using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Character Player1 { get; private set; }

    internal void SetCurrentCharacter(Character character)
    {
        Player1 = character;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Prevent duplicate instances
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Persist across scenes
        Player1 = Resources.Load<Character>("characters/Soldier");
    }



    void Update()
    {
    }


    public void GoToMainMenu()
    {
        Debug.Log("loading main scene");
        SceneManager.LoadScene("MainMenu");
    }



}
