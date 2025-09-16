using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "QuizMemory", menuName = "Scriptable Objects/QuizMemory")]
public class QuizMemory : ScriptableObject
{

    public List<int> previousQuestions;

}