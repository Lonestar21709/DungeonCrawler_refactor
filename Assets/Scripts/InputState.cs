﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ButtonState{
	public bool value;
	public float holdTime = 0;
}

public class InputState : MonoBehaviour {

	private Dictionary<Buttons, ButtonState> buttonStates = new Dictionary<Buttons, ButtonState> ();

	public void SetButtonValue(Buttons key, bool value){
		if (!buttonStates.ContainsKey (key))
			buttonStates.Add (key, new ButtonState());
		var state = buttonStates [key];
		if (state.value && !value) {
			state.holdTime = 0;
		} else if (state.value && value) {
			state.holdTime += Time.deltaTime;
			//Debug.Log ("Button " + key + " down " + state.holdTime);
		}
		state.value = value;
	}

	public bool GetButtonValue(Buttons key){
		//Debug.Log (buttonStates.Keys);
		if (buttonStates.ContainsKey (key)) {
			//Debug.Log (buttonStates [key].value);
			return buttonStates [key].value;
		}
		else
			return false;
	}

}
