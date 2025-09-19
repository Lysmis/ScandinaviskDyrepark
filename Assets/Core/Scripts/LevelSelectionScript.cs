using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class LevelSelectionScript : MonoBehaviour
{
    private Button bearLevelButton;
    private Button deerLevelButton;
    private Button eagleLevelButton;
    private Button foxLevelButton;
    private Button polarBearLevelButton;
    private Button wolfLevelButton;
    private Button[] buttons;
    [SerializeField] private string bearLevelName;
    [SerializeField] private string deerLevelName;
    [SerializeField] private string eagleLevelName;
    [SerializeField] private string foxLevelName;
    [SerializeField] private string polarBearLevelName;
    [SerializeField] private string wolfLevelName;
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
        if (wolfLevelName == string.Empty)
        {
            wolfLevelButton.style.opacity = 0.3f;
        }

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
            SceneManager.LoadScene(bearLevelName);
    }
    private void OnDeerPressed()
    {
        if (deerLevelName != string.Empty)
            SceneManager.LoadScene(deerLevelName);
    }
    private void OnEaglePressed()
    {
        if (eagleLevelName != string.Empty)
            SceneManager.LoadScene(eagleLevelName);
    }
    private void OnFoxPressed()
    {
        if (foxLevelName != string.Empty)
            SceneManager.LoadScene(foxLevelName);
    }
    private void OnPolarBearPressed()
    {
        if (polarBearLevelName != string.Empty)
            SceneManager.LoadScene(polarBearLevelName);
    }
    private void OnWolfPressed()
    {
        if (wolfLevelName != string.Empty)
            SceneManager.LoadScene(wolfLevelName);
    }


}
