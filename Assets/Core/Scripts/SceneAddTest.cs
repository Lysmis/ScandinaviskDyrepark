using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAddTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     SceneManager.LoadSceneAsync("HUD", LoadSceneMode.Additive);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
