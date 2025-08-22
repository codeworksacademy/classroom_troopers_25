using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{

    private VisualElement _root;

    public List<string> LevelSelect = new();

    private List<Character> _characters;

    private string selectedLevel = "SampleScene";


    void OnEnable()
    {
        _root = GetComponent<UIDocument>().rootVisualElement;
        _characters = Resources.LoadAll<Character>("characters").ToList();

        VisualElement main = _root.Q<VisualElement>("main");

        LevelSelect.ForEach(levelName =>
        {
            Button button = new();
            Label label = new() { text = levelName };
            button.Add(label);
            button.clicked += () => selectedLevel = levelName;
            button.AddToClassList("main-button");
            main.Add(button);
        });

        _characters.ForEach(character =>
        {
            Button button = new Button();
            Image icon = new();
            Label label = new() { text = character.name };
            button.AddToClassList("main-button");
            button.AddToClassList("character-button");
            icon.AddToClassList("character-icon");
            icon.style.backgroundImage = new StyleBackground(character.Icon);
            button.Add(icon);
            button.Add(label);

            main.Add(button);

            button.clicked += () => SetCharacter(character);
            button.clicked += StartGame;
        });
    }


    void SetCharacter(Character character)
    {
        GameManager.Instance.SetCurrentCharacter(character);
    }


    void StartGame()
    {
        SceneManager.LoadScene(selectedLevel);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
