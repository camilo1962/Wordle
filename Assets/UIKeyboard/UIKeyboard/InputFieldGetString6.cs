using System;
using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

public class InputFieldGetString6 : MonoBehaviour
{
    private TMP_InputField inputField;
    private KeyboardController6 kbdController;

    private void Start() {
        inputField = GetComponent<TMP_InputField>();
        kbdController = FindObjectOfType<KeyboardController6>();
    }

    private void Update() {
        var temp = kbdController.typedString6;
        if (temp.Length >= 0) {
            inputField.text = temp;
        }
    }
}
