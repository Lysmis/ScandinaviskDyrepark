using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu(fileName = "LanguageStrings_SO", menuName = "Scriptable Objects/LanguageStrings_SO")]
public class LanguageStrings_SO : ScriptableObject
{

    private QuizMemory quizMemory;
    private Dictionary<string, LanguageStringArray> strings;
    [SerializeField, Tooltip("Entries for text with different languages")] private LanguageStringArray[] textFields;

    public string GetString(string key)
    {

        if (quizMemory == null)
            quizMemory = Resources.Load<QuizMemory>("QuizMemory_SO");

        string text = "No text found";

        if (quizMemory != null && strings != null && strings.TryGetValue(key, out LanguageStringArray found))
            text = found.Strings[(int)quizMemory.Language];
        else if (quizMemory == null)
            Debug.Log("No QuizMemory found");
        else
        {

            Debug.Log($"No Value for Key \"{key}\" found");
            text = "No value found";

        }

        return text;

    }

    public void Initialize()
    {

        strings = new Dictionary<string, LanguageStringArray>();
        foreach (LanguageStringArray entry in textFields)
            strings.TryAdd(entry.tag, entry);

    }

}

[Serializable]
public class LanguageStringArray
{

    [Tooltip("Name of the field or button")] public string tag;
    [SerializeField, Tooltip("Danish version")] private string danish;
    [SerializeField, Tooltip("English version")] private string english;
    [SerializeField, Tooltip("German version")] private string german;


    public string[] Strings
    {

        get
        {

            return new string[] { danish, english, german };

        }

    }

}
