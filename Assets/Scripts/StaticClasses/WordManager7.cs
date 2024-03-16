using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public static class WordManager7
{
    public static List<string> allWords = new List<string>();
    public static List<string> commonWords = new List<string>();
    
    [RuntimeInitializeOnLoadMethod]
    public static void InitFile() {
        //Init the list of all words
        var wordFile7 = Resources.Load<TextAsset>("Words7"); //Get our Words.txt file
        var rawWords7 = wordFile7.text.Split('\n').ToList(); //Split the file into new lines

        foreach (var word in rawWords7) {

            if (!word.Contains("-") && !word.Contains(" ") && !word.Contains(",") && !word.Contains(".") && !word.Contains("&")) {
                allWords.Add(word.Trim().ToUpper());
            }
        }
        
        Debug.Log("<color=green> Todas las palabras se han inicializado con: " + allWords.Count + " words! </color>");
        
        //Init the common words list
        var commonWordFile = Resources.Load<TextAsset>("CommonWords7");
        var rawCommonWords7 = commonWordFile.text.Split('\n').ToList();

        foreach (var word in rawCommonWords7) {
            if (!word.Contains("-") && !word.Contains(" ") && !word.Contains(",") && !word.Contains(".") && !word.Contains("&")) {
                commonWords.Add(word.Trim().ToUpper());
            }
        }
        
        Debug.Log("<color=blue> Las palabras comunes se han inicializado con: " + commonWords.Count + " words! </color>");
    }
    

    public static string GetRandomWord(int length) {
        var wordsOfLength7 = new List<string>();
        foreach (var word in commonWords) {
            if (word.Length == length) {
                wordsOfLength7.Add(word);
            }
        }
        return wordsOfLength7[Random.Range(0, wordsOfLength7.Count)];
    }

    public static bool IsAWord(string wordToCheck) {
        return allWords.Contains(wordToCheck);
    }
}
