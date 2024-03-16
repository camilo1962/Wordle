using System;
using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

public class InputFieldGetString7 : MonoBehaviour
{
    private TMP_InputField inputField;
    private KeyboardController7 kbdController;

    private void Start() {
        inputField = GetComponent<TMP_InputField>();
        kbdController = FindObjectOfType<KeyboardController7>();
    }

    private void Update() {
        var temp = kbdController.typedString7;
        if (temp.Length >= 0) {
            inputField.text = temp;
        }
    }
}
