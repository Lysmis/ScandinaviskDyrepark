using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Carries persistant data for which Quiz's have been displayed
/// </summary>
[CreateAssetMenu(fileName = "QuizMemory", menuName = "Scriptable Objects/QuizMemory")]
public class QuizMemory : ScriptableObject
{
    
    public List<int> previousQuestions;
    public Action<float> CorrectAnswer; //Rewards time bonus

    /// <summary>
    /// Remote access to reactivate Quiz
    /// </summary>
    public GameObject Quiz { get; set; }

    /// <summary>
    /// Language setting and default value
    /// </summary>
    public LanguageOptions Language { get; set; }

    /// <summary>
    /// Difficulty setting and default value
    /// </summary>
    public QuizDifficulty Difficulty { get; set; }

    /// <summary>
    /// Method to instantiate a new List<int>
    /// </summary>
    public void InitializeAndResetMemory()
    {

        previousQuestions = new List<int>();
        Language = LanguageOptions.Dansk;
        Difficulty = QuizDifficulty.Easy;

    }

}

/// <summary>
/// Provides On-build run of method
/// </summary>
public class Startup
{

    /// <summary>
    /// Method runs before scenes are loaded
    /// </summary>
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void InitOnPlay()
    {

        QuizMemory so = Resources.Load<QuizMemory>("QuizMemory_SO");

        if (so != null)
            so.InitializeAndResetMemory();

    }

}
