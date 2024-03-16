using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class KeyboardController6 : MonoBehaviour
{
    public string typedString6 = "";
    
    public void GetKey(char key) {
        if (WordController6.instance.typing && typedString6.Length < WordController6.instance.wordLength6) {
            typedString6 += key;
            WordController6.instance.lines6[WordController6.instance.currentLineIndex6].currentLineWord6 = typedString6;
        }
    }

    public void Backspace() {
        if (typedString6.Length > 0) {
            typedString6 = typedString6.Remove(typedString6.Length - 1, 1);
            WordController6.instance.lines6[WordController6.instance.currentLineIndex6].currentLineWord6 = typedString6;
        }
    }

    public void Enter() {
        if (typedString6.Length == WordController6.instance.wordLength6) {
            WordController6.instance.lines6[WordController6.instance.currentLineIndex6].CheckWord();
        } else {
            PopupMessageController.instance.NewMessage("Palabra demasiado corta...", 3f);
        }
    }
}
