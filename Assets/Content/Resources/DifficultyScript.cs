using System;
using UnityEngine;
using UnityEngine.UIElements;

public class DifficultyScript : MonoBehaviour
{

    private Button easy, normal, hard;
    private QuizMemory memory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

        memory = Resources.Load<QuizMemory>("QuizMemory_SO");

        var root = GetComponent<UIDocument>().rootVisualElement;

        if (root != null)
        {

            easy = root.Q<Button>("easy");
            normal = root.Q<Button>("normal");
            hard = root.Q<Button>("hard");

        }

    }


    private void OnEnable()
    {

        if (easy != null)
            easy.clicked += SetEasy;
        if (normal != null)
            normal.clicked += SetNormal;
        if (hard != null)
            hard.clicked += SetHard;

    }


    private void OnDisable()
    {

        if (easy != null)
            easy.clicked -= SetEasy;
        if (normal != null)
            normal.clicked -= SetNormal;
        if (hard != null)
            hard.clicked -= SetHard;

    }

    private void SetEasy() => memory.Difficulty = QuizDifficulty.Easy;

    private void SetNormal() => memory.Difficulty = QuizDifficulty.Normal;

    private void SetHard() => memory.Difficulty = QuizDifficulty.Hard;

}
