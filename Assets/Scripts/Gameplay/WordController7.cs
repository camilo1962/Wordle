using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;
using UnityEngine;

public class WordController7 : MonoBehaviour
{
    public static WordController7 instance;

    private void Awake() {
        instance = this;
    }

    public Color[] keyColors;

    public int wordLength7 = 7;
    public string currentWord7;
    public int score;
    public TMP_Text scoreText;
    int scoreFallido;
    int jugadas;
    public TMP_Text jugadasText;
    public TMP_Text scoreFallidoText;
    public TMP_Text mejorRachaText;
    public TMP_Text solucionText;
    public GameObject panelEstadisticas;
   


    public int currentLineIndex7 = 0;
    public List<Line7> lines7 = new List<Line7>();

    public bool typing = true;
    
    public void Start() {
        StartGameplay();
        score = 0;
        mejorRachaText.text = PlayerPrefs.GetInt("RecordText6", 0).ToString();
        panelEstadisticas.SetActive(false);
    
    }
    public void Update()
    {
        solucionText.text = currentWord7;
        jugadas = score + scoreFallido;
        scoreText.text = score.ToString();
        jugadasText.text = jugadas.ToString();
        scoreFallidoText.text = scoreFallido.ToString();
    }

    public void StartGameplay() {
        currentWord7 = WordManager7.GetRandomWord(wordLength7);
        Debug.Log("Palabra actual: " + currentWord7);
        typing = true;
        currentLineIndex7 = 0;
        lines7[currentLineIndex7].enabled = true;
        panelEstadisticas.SetActive(false);
    }

    //Retorna una matriz que muestra la comparación entre las dos palabras
    //0 = Letra no en word
    //1 = Letra en word, pero lugar equivocado
    //2 = Letra en el lugar correcto
    //E.G Freak y amigos == [2, 0, 0, 0, 2]
    //E.G Break & Freak == [0, 2, 2, 2, 2]
    public int[] CompareWord(string wordToCompare) {
        int[] wordComparrison = new int[currentWord7.Length]; //Crear una matriz de enteros de la longitud de nuestra palabra actual
        for (int i = 0; i < currentWord7.Length; i++) {
            if (!currentWord7.Contains(wordToCompare[i])) {
                wordComparrison[i] = 0;
            } else {
                if (wordToCompare[i] == currentWord7[i]) {
                    wordComparrison[i] = 2;
                } else {
                    wordComparrison[i] = 1;
                }
            }
        }
        // Debug.Log("ToCompare: " + wordToCompare + " CurrentWord: " + currentWord + " = [" + wordComparrison[0] + "," + wordComparrison[1] + "," +wordComparrison[2] + "," +wordComparrison[3] + "," +wordComparrison[4] + "]");
        if (CorrectAnswer(wordToCompare)) {
            Debug.Log("<color=green>GANADOR!</color>");
            panelEstadisticas.SetActive(true);
            //PopupMessageController.instance.NewMessage("¡lo clavaste! Felicidades ._.", 120f);
            score++;
            if (score > PlayerPrefs.GetInt("RecordText7", 0))
            {
                PlayerPrefs.SetInt("RecordText7", score);
                mejorRachaText.text = score.ToString();
            }
                
            typing = false;

        }
        return wordComparrison;
    }

    public bool CorrectAnswer(string wordToCompare) {
        if (wordToCompare.ToUpper() == currentWord7.ToUpper()) {
            return true;
        } else {
            return false;
        }
    }

    
    public void NextLine() {
        lines7[currentLineIndex7].enabled = false;
        currentLineIndex7++;
        
        if (currentLineIndex7 < lines7.Count) {
            lines7[currentLineIndex7].enabled = true;
        }else if (currentLineIndex7 == lines7.Count) {
            Debug.Log("<color=red>Has palmao!</color>");
            PopupMessageController.instance.NewMessage("¡No te cabrees!\n" + " Inténtalo de nuevo... \n" + " La palabra era " + currentWord7, 5f);
            scoreFallido++;
            typing = false;
        }

        FindObjectOfType<KeyboardController7>().typedString7 = "";
    }


    public void ResetGame() {
        ResetBoard();
        StartGameplay();
    }

    public void ResetBoard() {
        foreach (var line in lines7) {
            line.Reset();
        }

        currentLineIndex7 = 0;
        lines7[currentLineIndex7].enabled = true;
        
        PopupMessageController.instance.ClearMessages();

        FindObjectOfType<KeyboardController7>().typedString7 = "";

        var allKeys = FindObjectsOfType<KeyboardKey7>();
        foreach (var key in allKeys) {
            key.SetColour(Color.white);
        }
    }

    public void Merindo()
    {
        scoreFallido++;
        PopupMessageController.instance.NewMessage("<color=red>La palabra es </color>\n" + "\n" + currentWord7 + "\n" + "<color=red>¡intentalo de nuevo!</color>\n", 5f);
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void BorrarRacha()
    {
        PlayerPrefs.DeleteKey("RecordText7");
    }


    
}
