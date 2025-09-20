using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartMenuScript : MonoBehaviour
{
    private Button startButton;
    private Button danishLanguageButton;
    private Button englishLanguageButton;
    private Button germanLanguageButton;
    private QuizMemory quiz_so;
    [SerializeField, Tooltip("The opacity a button should have, when it is selected."), Range(0f, 1f)]
    private float OpacityWhenSelected = 1f;
    [SerializeField, Tooltip("The opacity a button should have, when it is NOT selected."), Range(0f, 1f)]
    private float OpacityWhenNotSelected = 0.5f;
    [SerializeField, Tooltip("The name of the next scene(s) to be loaded\nBeware that both a level scene and HUD/UI scene might be needed")] string[] scenes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void OnEnable()
    {
        quiz_so = Resources.Load<QuizMemory>("QuizMemory_SO");
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

        SetLanguage(LanguageOptions.Dansk);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    /// <summary>
    /// Handles loading an unloading scenes when the start button is pressed
    /// </summary>
    private void OnStartPressed()
    {
            foreach (string scene in scenes)
            {
                SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
            }
            SceneManager.UnloadSceneAsync("StartScene");
    }

    /// <summary>
    /// Sets the language to danish
    /// </summary>
    private void OnDanishPressed()
    {
        SetLanguage(LanguageOptions.Dansk);
    }
    /// <summary>
    /// Sets the language to english
    /// </summary>
    private void OnEnglishPressed()
    {
        SetLanguage(LanguageOptions.English);
    }
    /// <summary>
    /// Sets the language to german
    /// </summary>
    private void OnGermanPressed()
    {
        SetLanguage(LanguageOptions.Deutsch);
    }

    /// <summary>
    /// Handles setting the language, by suing the quiz scriptble objects.
    /// Also changes the opacities of buttons of selected and not selected languages. 
    /// </summary>
    /// <param name="language">The LanguageOptions enum for thelanguage selected </param>
    private void SetLanguage(LanguageOptions language)
    {
        quiz_so.Language = language;
        switch (language)
        {
            case LanguageOptions.Dansk:
                danishLanguageButton.style.opacity = OpacityWhenSelected;
                englishLanguageButton.style.opacity = OpacityWhenNotSelected;
                germanLanguageButton.style.opacity = OpacityWhenNotSelected;
                break;
            case LanguageOptions.English:
                danishLanguageButton.style.opacity = OpacityWhenNotSelected;
                englishLanguageButton.style.opacity = OpacityWhenSelected;
                germanLanguageButton.style.opacity = OpacityWhenNotSelected;
                break;
            case LanguageOptions.Deutsch:
                danishLanguageButton.style.opacity = OpacityWhenNotSelected;
                englishLanguageButton.style.opacity = OpacityWhenNotSelected;
                germanLanguageButton.style.opacity = OpacityWhenSelected;
                break;
            default: return;

        }
    }

}
