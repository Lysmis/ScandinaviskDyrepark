using UnityEngine;
using UnityEngine.UIElements;

public class StartMenuScript : MonoBehaviour
{
    private Button startButton;
    private Button danishLanguageButton;
    private Button englishLanguageButton;
    private Button germanLanguageButton;
    private Quiz_Script script;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void OnEnable()
    {
        script = Resources.Load<QuizMemory>("QuizMemory_SO").Quiz.GetComponent<Quiz_Script>();
        var doc = GetComponent<UIDocument>();
        var root = doc.rootVisualElement;
        startButton = root.Q<Button>("StartButton");
        danishLanguageButton = root.Q<Button>("DanishLanguageButton");
        englishLanguageButton = root.Q<Button>("EnglishLanguageButton");
        germanLanguageButton = root.Q<Button>("GermanLanguageButton");

        startButton.clicked += OnStartPressed;
        danishLanguageButton.clicked += OnDanishPressed;
        englishLanguageButton.clicked += OnEnglishPressed;
        germanLanguageButton.clicked += OnGermanPressed;
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnStartPressed()
    {
        //Load LevelSelection Scene
    }

    private void OnDanishPressed()
    {
        SetLanguage(LanguageOptions.Dansk);
    }

    private void OnEnglishPressed()
    {
        SetLanguage(LanguageOptions.English);
    }

    private void OnGermanPressed()
    {
        SetLanguage(LanguageOptions.Deutsch);
    }

    private void SetLanguage(LanguageOptions language)
    {
        script.Language = language;
        switch (language)
        {
            case LanguageOptions.Dansk:
                danishLanguageButton.style.opacity = 100;
                englishLanguageButton.style.opacity = 50;
                germanLanguageButton.style.opacity= 50;
                break;
            case LanguageOptions.English:
                danishLanguageButton.style.opacity = 50;
                englishLanguageButton.style.opacity = 100;
                germanLanguageButton.style.opacity = 50;
                break;
            case LanguageOptions.Deutsch:
                danishLanguageButton.style.opacity = 50;
                englishLanguageButton.style.opacity = 50;
                germanLanguageButton.style.opacity = 100;
                break;
            default: return;

        }
    }

}
