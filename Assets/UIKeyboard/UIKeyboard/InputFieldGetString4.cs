using System;
using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

public class InputFieldGetString4 : MonoBehaviour
{
    private TMP_InputField inputField;
    private KeyboardController4 kbdController;

    private void Start() {
        inputField = GetComponent<TMP_InputField>();
        kbdController = FindObjectOfType<KeyboardController4>();
    }

    private void Update() {
        var temp = kbdController.typedString4;
        if (temp.Length >= 0) {
            inputField.text = temp;
        }
    }
}
