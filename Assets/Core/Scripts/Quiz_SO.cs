using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quiz_SO", menuName = "Scriptable Objects/Quiz", order = 0)]
public class Quiz_SO : ScriptableObject
{

    [Header("Quiz Data")]
    [Tooltip("Language the questions are in")] public LanguageOptions language;
    [Tooltip("Approximated difficulty of quiz")] public QuizDifficulty difficulty;
    [Tooltip("List of questions")] public List<QuestionEntry> questions = new List<QuestionEntry>();

}

[System.Serializable]
public class QuestionEntry
{

    #region Fields

    [SerializeField, TextArea, Tooltip("Type in the question")] private string question;
    [Space]
    [SerializeField, Tooltip("Type in 3 different answering options")] private AnswerArray answers = new AnswerArray();
    [Space]
    [SerializeField, Tooltip("Select which of the 3 is the correct answer")] private QuestionOptions correctAnswer;

    #endregion
    #region Properties

    public string Question { get => question; }
    public AnswerArray Answers { get => answers; }
    public int CorrectAnswer { get => (int)correctAnswer; }

    #endregion
}

[System.Serializable]
public class AnswerArray
{

    #region Fields

    [SerializeField] private string option1;
    [SerializeField] private string option2;
    [SerializeField] private string option3;
    private string[] options;

    #endregion
    #region Properties

    public string[] Options
    {
        get
        {

            if (options == null)
                options = new string[3] { option1, option2, option3 };

            return options;

        }
    }

    #endregion

}

public enum LanguageOptions 
{
    Dansk,
    English,
    Deutsch
}

public enum QuizDifficulty
{
    Easy,
    Normal,
    Hard
}

public enum QuestionOptions
{
    Option1,
    Option2, 
    Option3
}