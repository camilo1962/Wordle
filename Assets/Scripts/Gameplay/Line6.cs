using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Line6 : MonoBehaviour
{
    public string currentLineWord6;

   
    
   [HideInInspector] public List<TMP_Text> letterSpots = new List<TMP_Text>();
   [HideInInspector] public List<Image> letterSquares = new List<Image>();

    public Sprite blankLetterSprite;
    public Sprite[] letterSquareSprites;

    public void Start() {
        //Get our letter and image spots
        letterSpots = GetComponentsInChildren<TMP_Text>().ToList();
        letterSquares = GetComponentsInChildren<Image>().ToList();
        
        //Make all squares blank
        for (int i = 0; i < letterSpots.Count; i++) {
            letterSpots[i].text = "";
            letterSquares[i].sprite = blankLetterSprite;
        }
    }

    public void Reset() {
        //Make all squares blank
        for (int i = 0; i < letterSpots.Count; i++) {
            letterSpots[i].text = "";
            letterSquares[i].sprite = blankLetterSprite;
        }
        currentLineWord6 = "";
    }

    private void Update() {
        UpdateWord();
    }

    public void UpdateWord() {
        for (int i = 0; i < letterSpots.Count; i++) {
            if (i < currentLineWord6.Length) {
                letterSpots[i].text = currentLineWord6[i].ToString();
            } else {
                letterSpots[i].text = "";
            }
        }
    }
    
    public void CheckWord() {
        if (WordManager6.IsAWord(currentLineWord6)) {
            var comparedValues = WordController6.instance.CompareWord(currentLineWord6);
            for (int i = 0; i < letterSquares.Count; i++) {
                letterSquares[i].sprite = letterSquareSprites[comparedValues[i]];

                var targetKey = GameObject.Find(currentLineWord6[i].ToString());
                var targetKeyScript = targetKey.GetComponent<KeyboardKey6>();
                if (targetKey.GetComponent<Image>().color != WordController6.instance.keyColors[2]) {
                    targetKeyScript.SetColour(WordController6.instance.keyColors[comparedValues[i]]);
                  
                }
            }
            if (!WordController6.instance.CorrectAnswer(currentLineWord6)) {
                WordController6.instance.NextLine();
            }
            

        } else {
            //Envía un mensaje sobre cómo esto no es una palabra.
            Debug.Log("<color=red> Esta palabra no existe: " + currentLineWord6 + "</color>");
            PopupMessageController.instance.NewMessage("¡Esta palabra no está en mi lista!, ¿Existe?...", 3f);
        }
    }
}
