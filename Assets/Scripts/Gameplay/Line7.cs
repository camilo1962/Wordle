using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Line7 : MonoBehaviour
{
    public string currentLineWord7;

   
    
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
        currentLineWord7 = "";
    }

    private void Update() {
        UpdateWord();
    }

    public void UpdateWord() {
        for (int i = 0; i < letterSpots.Count; i++) {
            if (i < currentLineWord7.Length) {
                letterSpots[i].text = currentLineWord7[i].ToString();
            } else {
                letterSpots[i].text = "";
            }
        }
    }
    
    public void CheckWord() {
        if (WordManager7.IsAWord(currentLineWord7)) {
            var comparedValues = WordController7.instance.CompareWord(currentLineWord7);
            for (int i = 0; i < letterSquares.Count; i++) {
                letterSquares[i].sprite = letterSquareSprites[comparedValues[i]];

                var targetKey = GameObject.Find(currentLineWord7[i].ToString());
                var targetKeyScript = targetKey.GetComponent<KeyboardKey7>();
                if (targetKey.GetComponent<Image>().color != WordController7.instance.keyColors[2]) {
                    targetKeyScript.SetColour(WordController7.instance.keyColors[comparedValues[i]]);
                  
                }
            }
            if (!WordController7.instance.CorrectAnswer(currentLineWord7)) {
                WordController7.instance.NextLine();
            }
            

        } else {
            //Envía un mensaje sobre cómo esto no es una palabra.
            Debug.Log("<color=red> Esta palabra no existe: " + currentLineWord7 + "</color>");
            PopupMessageController.instance.NewMessage("¡Esta palabra no está en mi lista!, ¿Existe?...", 3f);
        }
    }
}
