using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class KeyboardController4 : MonoBehaviour
{
    public string typedString4 = "";
    
    public void GetKey(char key) {
        if (WordController4.instance.typing && typedString4.Length < WordController4.instance.wordLength4) {
            typedString4 += key;
            WordController4.instance.lines4[WordController4.instance.currentLineIndex4].currentLineWord4 = typedString4;
        }
    }

    public void Backspace() {
        if (typedString4.Length > 0) {
            typedString4 = typedString4.Remove(typedString4.Length - 1, 1);
            WordController4.instance.lines4[WordController4.instance.currentLineIndex4].currentLineWord4 = typedString4;
        }
    }

    public void Enter() {
        if (typedString4.Length == WordController4.instance.wordLength4) {
            WordController4.instance.lines4[WordController4.instance.currentLineIndex4].CheckWord();
        } else {
            PopupMessageController.instance.NewMessage("Palabra demasiado corta...", 3f);
        }
    }
}
