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
    [SerializeField] private string bearLevelName;
    [SerializeField] private string deerLevelName;
    [SerializeField] private string eagleLevelName;
    [SerializeField] private string foxLevelName;
    [SerializeField] private string polarBearLevelName;
    [SerializeField] private string wolfLevelName;
    [SerializeField, Tooltip("The opacity of buttons with no referenced scene"), Range(0, 1)] private float unappliedButtonOpacity = 0.3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void OnEnable()
    {
        var doc = GetComponent<UIDocument>();
        var root = doc.rootVisualElement;
        bearLevelButton = root.Q<Button>("BearLevelButton");
        deerLevelButton = root.Q<Button>("DeerLevelButton");
        eagleLevelButton = root.Q<Button>("EagleLevelButton");
        foxLevelButton = root.Q<Button>("FoxLevelButton");
        polarBearLevelButton = root.Q<Button>("PolarBearLevelButton");
        wolfLevelButton = root.Q<Button>("WolfLevelButton");

        SetButtonOpacities();
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

    private void OnBearPressed()
    {
        if (bearLevelName != string.Empty)
        {
            SceneManager.LoadScene(bearLevelName);
            UnloadLevelSelectionScene();
        }

    }
    private void OnDeerPressed()
    {
        if (deerLevelName != string.Empty)
        {
            SceneManager.LoadScene(deerLevelName);
            UnloadLevelSelectionScene();
        }
    }
    private void OnEaglePressed()
    {
        if (eagleLevelName != string.Empty)
        {
            SceneManager.LoadScene(eagleLevelName); UnloadLevelSelectionScene();
        }
    }
    private void OnFoxPressed()
    {
        if (foxLevelName != string.Empty)
        {
            SceneManager.LoadScene(foxLevelName); UnloadLevelSelectionScene();
        }
    }
    private void OnPolarBearPressed()
    {
        if (polarBearLevelName != string.Empty)
        {
            SceneManager.LoadScene(polarBearLevelName); UnloadLevelSelectionScene();
        }
    }
    private void OnWolfPressed()
    {
        if (wolfLevelName != string.Empty)
        {
            SceneManager.LoadScene(wolfLevelName); UnloadLevelSelectionScene();
        }
    }

    private void UnloadLevelSelectionScene()
    {
        SceneManager.UnloadSceneAsync("LevelSelectionScene");
    }

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
