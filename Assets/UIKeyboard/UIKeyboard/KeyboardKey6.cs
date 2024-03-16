using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardKey6 : MonoBehaviour
{
	//Place this on the buttons that act as the keys for the keyboard
	private char keyCharacter;
	private KeyboardController6 kbdController;

	private void Start() {
		keyCharacter = gameObject.name.ToCharArray()[0];
		kbdController = GetComponentInParent<KeyboardController6>(); 
		GetComponent<Button>().onClick.AddListener(KeyPressed);
	}

	public void KeyPressed() {
		if (gameObject.name == "Backspace") {
			kbdController.Backspace();
		}else if (gameObject.name == "Enter") {
			kbdController.Enter();
		} else {
			kbdController.GetKey(keyCharacter);
		}
		
	}

	public void SetColour(Color colorToUse) {
		GetComponent<Image>().color = colorToUse;
	}
}
