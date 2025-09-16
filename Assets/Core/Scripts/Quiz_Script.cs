using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class Quiz_Script : MonoBehaviour
{

    public Quiz_SO quiz;
    [SerializeField] private QuizMemory quizMemory;
    private Label question;
    private Button option1, option2, option3;
    private int questionIndex;
    private bool closingQuiz = false;
    private string result = string.Empty;
    private float closingIn = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {

        if (quizMemory.previousQuestions == null || quizMemory.previousQuestions.Count == 0)
        {
            quizMemory.previousQuestions = new List<int>();
            Debug.Log("Quizmemory instantiated");
        }
        else
            Debug.Log("Quizmemory already instantiated");

        var root = GetComponent<UIDocument>().rootVisualElement;

        if (root != null)
        {
            question = root.Q<Label>("textbox");
            option1 = root.Q<Button>("option1");
            option2 = root.Q<Button>("option2");
            option3 = root.Q<Button>("option3");
        }

        if (quiz != null && root != null)
            InitiateQuiz();

        closingQuiz = false;
        closingIn = 5;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (closingQuiz)
        {
            closingIn -= Time.deltaTime;
            question.text = result + $"\n\n {(int)closingIn}";
        }

    }


    private void CorrectAnswer()
    {

        switch (quiz.language)
        {
            case LanguageOptions.Dansk:
                question.text = "Rigtigt svar";
                break;
            case LanguageOptions.English:
                question.text = "Correct Answer";
                break;
            case LanguageOptions.Deutsch:
                question.text = "Richtige antwort";
                break;
        }
        StartCoroutine(CloseQuiz());

    }

    private void WrongAnswer()
    {

        switch (quiz.language)
        {
            case LanguageOptions.Dansk:
                question.text = "Forkert svar";
                break;
            case LanguageOptions.English:
                question.text = "Wrong answer";
                break;
            case LanguageOptions.Deutsch:
                question.text = "Falsche antwort";
                break;
        }
        StartCoroutine(CloseQuiz());

    }

    private void InitiateQuiz()
    {

        do
        {
            if (quiz.questions.Count == quizMemory.previousQuestions.Count)
            {
                Debug.Log("QuizMemory cleared");
                quizMemory.previousQuestions.Clear();
            }

            questionIndex = Random.Range(0, quiz.questions.Count);
        }
        while (quizMemory.previousQuestions.Contains(questionIndex));
        quizMemory.previousQuestions.Add(questionIndex);

        question.text = quiz.questions[questionIndex].Question;
        option1.text = quiz.questions[questionIndex].Answers.Options[0];
        option2.text = quiz.questions[questionIndex].Answers.Options[1];
        option3.text = quiz.questions[questionIndex].Answers.Options[2];

        switch (quiz.questions[questionIndex].CorrectAnswer)
        {
            case 0:
                option1.clicked += CorrectAnswer;
                option2.clicked += WrongAnswer;
                option3.clicked += WrongAnswer;
                break;
            case 1:
                option2.clicked += CorrectAnswer;
                option1.clicked += WrongAnswer;
                option3.clicked += WrongAnswer;
                break;
            case 2:
                option3.clicked += CorrectAnswer;
                option2.clicked += WrongAnswer;
                option1.clicked += WrongAnswer;
                break;
        }

    }

    private void OnDisable()
    {



    }

    private void DisableButtons()
    {

        switch (quiz.questions[questionIndex].CorrectAnswer)
        {
            case 0:
                option1.clicked -= CorrectAnswer;
                option2.clicked -= WrongAnswer;
                option3.clicked -= WrongAnswer;
                break;
            case 1:
                option2.clicked -= CorrectAnswer;
                option1.clicked -= WrongAnswer;
                option3.clicked -= WrongAnswer;
                break;
            case 2:
                option3.clicked -= CorrectAnswer;
                option2.clicked -= WrongAnswer;
                option1.clicked -= WrongAnswer;
                break;
        }

    }

    private IEnumerator CloseQuiz()
    {

        DisableButtons();
        closingQuiz = true;
        result = question.text;

        yield return new WaitForSeconds(5f);

        yield return SceneManager.UnloadSceneAsync(gameObject.scene);

    }

}
