using UnityEngine;

public class CoinSoundScript : MonoBehaviour
{

    private AudioSource coinSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        coinSound = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);

    }

    private void OnEnable()
    {

        Resources.Load<QuizMemory>("QuizMemory_SO").CoinSoundTrigger += PlaySound;

    }

    private void OnDisable()
    {

        Resources.Load<QuizMemory>("QuizMemory_SO").CoinSoundTrigger -= PlaySound;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlaySound()
    {

        coinSound.PlayOneShot(coinSound.clip);

    }

}
