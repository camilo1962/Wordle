using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class KeyboardController7 : MonoBehaviour
{
    public string typedString7 = "";
    
    public void GetKey(char key) {
        if (WordController7.instance.typing && typedString7.Length < WordController7.instance.wordLength7) {
            typedString7 += key;
            WordController7.instance.lines7[WordController7.instance.currentLineIndex7].currentLineWord7 = typedString7;
        }
    }

    public void Backspace() {
        if (typedString7.Length > 0) {
            typedString7 = typedString7.Remove(typedString7.Length - 1, 1);
            WordController7.instance.lines7[WordController7.instance.currentLineIndex7].currentLineWord7 = typedString7;
        }
    }

    public void Enter() {
        if (typedString7.Length == WordController7.instance.wordLength7) {
            WordController7.instance.lines7[WordController7.instance.currentLineIndex7].CheckWord();
        } else {
            PopupMessageController.instance.NewMessage("Palabra demasiado corta...", 4f);
        }
    }
}
