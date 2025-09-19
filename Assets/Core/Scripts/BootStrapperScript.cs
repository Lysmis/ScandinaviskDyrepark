using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BootStrapperScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private IEnumerator Start()
    {
        yield return SceneManager.LoadSceneAsync("StartScene", LoadSceneMode.Additive);
       // yield return SceneManager.UnloadSceneAsync("BootStrapScene");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
