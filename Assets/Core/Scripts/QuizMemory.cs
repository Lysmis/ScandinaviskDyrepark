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
    /// Method to instantiate a new List<int>
    /// </summary>
    public void InitializeList()
    {

        previousQuestions = new List<int>();

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
            so.InitializeList();

    }

}
