using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LevelSelectionScript : MonoBehaviour
{
    private Button bearLevelButton;
    private Button deerLevelButton;
    private Button eagleLevelButton;
    private Button foxLevelButton;
    private Button polarBearLevelButton;
    private Button wolfLevelButton;
    [SerializeField, Tooltip("The name of the scene that should be used. Make sure to  type it exactly as it is shown in the project window in the unity editor")] private string bearLevelName;
    [SerializeField, Tooltip("The name of the scene that should be used. Make sure to  type it exactly as it is shown in the project window in the unity editor")] private string deerLevelName;
    [SerializeField, Tooltip("The name of the scene that should be used. Make sure to  type it exactly as it is shown in the project window in the unity editor")] private string eagleLevelName;
    [SerializeField, Tooltip("The name of the scene that should be used. Make sure to  type it exactly as it is shown in the project window in the unity editor")] private string foxLevelName;
    [SerializeField, Tooltip("The name of the scene that should be used. Make sure to  type it exactly as it is shown in the project window in the unity editor")] private string polarBearLevelName;
    [SerializeField, Tooltip("The name of the scene that should be used. Make sure to  type it exactly as it is shown in the project window in the unity editor")] private string wolfLevelName;
    [SerializeField, Tooltip("The name of the scene used for UI/HUD on the chosen level")] string UILevelName;
    [SerializeField, Tooltip("The opacity of buttons with no referenced scene"), Range(0, 1)] private float unappliedButtonOpacity = 0.3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void OnEnable()
    {
        //References for all the buttons in the UI document
        var doc = GetComponent<UIDocument>();
        var root = doc.rootVisualElement;
        bearLevelButton = root.Q<Button>("BearLevelButton");
        deerLevelButton = root.Q<Button>("DeerLevelButton");
        eagleLevelButton = root.Q<Button>("EagleLevelButton");
        foxLevelButton = root.Q<Button>("FoxLevelButton");
        polarBearLevelButton = root.Q<Button>("PolarBearLevelButton");
        wolfLevelButton = root.Q<Button>("WolfLevelButton");

        SetButtonOpacities();

        //Actions added to buttons
        bearLevelButton.clicked += OnBearPressed;
        deerLevelButton.clicked += OnDeerPressed;
        eagleLevelButton.clicked += OnEaglePressed;
        foxLevelButton.clicked += OnFoxPressed;
        polarBearLevelButton.clicked += OnPolarBearPressed;
        wolfLevelButton.clicked += OnWolfPressed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Loads the appropriate scenes for the corresponding button (level and UI) and calls mehtods to unload the level selection scene. 
    /// </summary>
    private void OnBearPressed()
    {
        if (bearLevelName != string.Empty)
        {
            SceneManager.LoadSceneAsync(bearLevelName, LoadSceneMode.Additive);
            SceneManager.LoadSceneAsync(UILevelName, LoadSceneMode.Additive);
            UnloadLevelSelectionScene();
        }

    }
    /// <summary>
    /// Loads the appropriate scenes for the corresponding button (level and UI) and calls mehtods to unload the level selection scene. 
    /// </summary>
    private void OnDeerPressed()
    {
        if (deerLevelName != string.Empty)
        {
            SceneManager.LoadSceneAsync(deerLevelName, LoadSceneMode.Additive);
            SceneManager.LoadSceneAsync(UILevelName, LoadSceneMode.Additive);
            UnloadLevelSelectionScene();
        }
    }
    /// <summary>
    /// Loads the appropriate scenes for the corresponding button (level and UI) and calls mehtods to unload the level selection scene. 
    /// </summary>
    private void OnEaglePressed()
    {
        if (eagleLevelName != string.Empty)
        {
            SceneManager.LoadSceneAsync(eagleLevelName, LoadSceneMode.Additive);
            SceneManager.LoadSceneAsync(UILevelName, LoadSceneMode.Additive);
            UnloadLevelSelectionScene();
        }
    }
    /// <summary>
    /// Loads the appropriate scenes for the corresponding button (level and UI) and calls mehtods to unload the level selection scene. 
    /// </summary>
    private void OnFoxPressed()
    {
        if (foxLevelName != string.Empty)
        {
            SceneManager.LoadSceneAsync(foxLevelName, LoadSceneMode.Additive);
            SceneManager.LoadSceneAsync(UILevelName, LoadSceneMode.Additive);
            UnloadLevelSelectionScene();
        }
    }
    /// <summary>
    /// Loads the appropriate scenes for the corresponding button (level and UI) and calls mehtods to unload the level selection scene. 
    /// </summary>
    private void OnPolarBearPressed()
    {
        if (polarBearLevelName != string.Empty)
        {
            SceneManager.LoadSceneAsync(polarBearLevelName, LoadSceneMode.Additive);
            SceneManager.LoadSceneAsync(UILevelName, LoadSceneMode.Additive);
            UnloadLevelSelectionScene();
        }
    }
    /// <summary>
    /// Loads the appropriate scenes for the corresponding button (level and UI) and calls mehtods to unload the level selection scene. 
    /// </summary>
    private void OnWolfPressed()
    {
        if (wolfLevelName != string.Empty)
        {
            SceneManager.LoadSceneAsync(wolfLevelName, LoadSceneMode.Additive);
            SceneManager.LoadSceneAsync(UILevelName, LoadSceneMode.Additive);
            UnloadLevelSelectionScene();
        }
    }

    /// <summary>
    /// Unloads the LevelSelectionScene
    /// </summary>
    private void UnloadLevelSelectionScene()
    {
        SceneManager.UnloadSceneAsync("LevelSelectionScene");
    }

    /// <summary>
    /// Sets the opacities of the buttons, according to wether or not they have a scene they reference. 
    /// </summary>
    private void SetButtonOpacities()
    {

        if (bearLevelName == string.Empty)
        {
            bearLevelButton.style.opacity = unappliedButtonOpacity;
        }
        if (deerLevelName == string.Empty)
        {
            deerLevelButton.style.opacity = unappliedButtonOpacity;
        }
        if (eagleLevelName == string.Empty)
        {
            eagleLevelButton.style.opacity = unappliedButtonOpacity;
        }
        if (foxLevelName == string.Empty)
        {
            foxLevelButton.style.opacity = unappliedButtonOpacity;
        }
        if (polarBearLevelName == string.Empty)
        {
            polarBearLevelButton.style.opacity = unappliedButtonOpacity;
        }
        if (wolfLevelName == string.Empty)
        {
            wolfLevelButton.style.opacity = unappliedButtonOpacity;
        }
    }
}
