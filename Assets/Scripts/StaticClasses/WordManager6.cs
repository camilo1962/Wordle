using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using Random = UnityEngine.Random;

public static class WordManager6
{
    public static List<string> allWords = new List<string>();
    public static List<string> commonWords = new List<string>();
    
    [RuntimeInitializeOnLoadMethod]
    public static void InitFile() {
        //Init the list of all words
        var wordFile6 = Resources.Load<TextAsset>("Words6"); //Get our Words.txt file
        var rawWords6 = wordFile6.text.Split('\n').ToList(); //Split the file into new lines

        foreach (var word in rawWords6) {

            if (!word.Contains("-") && !word.Contains(" ") && !word.Contains(",") && !word.Contains(".") && !word.Contains("&")) {
                allWords.Add(word.Trim().ToUpper());
            }
        }
        
        Debug.Log("<color=green> Todas las palabras se han inicializado con: " + allWords.Count + " words! </color>");
        
        //Init the common words list
        var commonWordFile = Resources.Load<TextAsset>("CommonWords6");
        var rawCommonWords6 = commonWordFile.text.Split('\n').ToList();

        foreach (var word in rawCommonWords6) {
            if (!word.Contains("-") && !word.Contains(" ") && !word.Contains(",") && !word.Contains(".") && !word.Contains("&")) {
                commonWords.Add(word.Trim().ToUpper());
            }
        }
        
        Debug.Log("<color=blue> Las palabras comunes se han inicializado con: " + commonWords.Count + " words! </color>");
    }
    

    public static string GetRandomWord(int length) {
        var wordsOfLength6 = new List<string>();
        foreach (var word in commonWords) {
            if (word.Length == length) {
                wordsOfLength6.Add(word);
            }
        }
        return wordsOfLength6[Random.Range(0, wordsOfLength6.Count)];
    }

    public static bool IsAWord(string wordToCheck) {
        return allWords.Contains(wordToCheck);
    }
}
