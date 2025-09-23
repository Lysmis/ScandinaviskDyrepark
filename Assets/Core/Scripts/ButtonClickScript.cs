using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ButtonClickScript : MonoBehaviour
{

    private AudioSource clickSource;

    void Awake()
    {

        DontDestroyOnLoad(gameObject); // persist across additive scenes

    }

    void OnEnable()
    {

        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    void OnDisable()
    {

        SceneManager.sceneLoaded -= OnSceneLoaded;

    }

    void Start()
    {

        clickSource = GetComponent<AudioSource>();
        TryBindFromAllUIDocuments();

    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        // Wait a frame so UI Toolkit has initialized
        StartCoroutine(BindNextFrame(scene));

    }

    private IEnumerator BindNextFrame(Scene scene)
    {

        yield return null;
        TryBindFromAllUIDocuments();

    }

    private void TryBindFromAllUIDocuments()
    {

        UIDocument[] docs = FindObjectsByType<UIDocument>(FindObjectsSortMode.None);
        foreach (var doc in docs)
        {

            var root = doc.rootVisualElement;
            if (root == null) 
                continue;

            // Find all UI Toolkit buttons
            var buttons = root.Query<UnityEngine.UIElements.Button>().ToList();

            foreach (var b in buttons)
            {

                // Unregister to avoid duplicates
                b.clicked -= PlayClick;
                b.clicked += PlayClick;

            }

        }

    }

    private void PlayClick()
    {

        if (clickSource != null && clickSource.clip != null)
            clickSource.PlayOneShot(clickSource.clip);

    }
}
