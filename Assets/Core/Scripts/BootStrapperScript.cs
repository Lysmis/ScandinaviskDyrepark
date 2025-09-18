using UnityEngine;
using UnityEngine.SceneManagement;

public class BootStrapperScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadScenes();
        UnloadBootStrapper();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadScenes()
    {
        SceneManager.LoadSceneAsync("QuizScene", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("StartScene", LoadSceneMode.Additive);
    }

    public void UnloadBootStrapper()
    {
        SceneManager.UnloadSceneAsync("BootStrapScene");
    }

}
