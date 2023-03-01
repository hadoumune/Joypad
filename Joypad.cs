#if (UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX)
	#define UNITY_OSX
#elif (UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN)
	#define UNITY_WIN
#endif
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputMan{
	public enum JoypadCode {
		A = 0,
		B,
		X,
		Y,
		L1,
		R1,
		L2,
		R2,
		L3,
		R3,
		Up,
		Down,
		Left,
		Right,
		Start,
		Select,
		Ok,
		Cancel,
		Allow,
		Buttons,
		Any,
	}

public class Joypad : SingletonMonoBehaviour<Joypad>
{
	public enum Mode{
		Mouse,
		Keyboard,
		Joypad,
	}

	KeyCode [][] keyCodes = {
		new KeyCode[]{KeyCode.X,},//A = 0,
		new KeyCode[]{KeyCode.Z,},//B,
		new KeyCode[]{KeyCode.A,},//X,
		new KeyCode[]{KeyCode.S,},//Y,
		new KeyCode[]{KeyCode.Q,},//L1,
		new KeyCode[]{KeyCode.W,},//R1,
		new KeyCode[]{KeyCode.Alpha1,},//L2,
		new KeyCode[]{KeyCode.Alpha2,},//R2,
		new KeyCode[]{KeyCode.Alpha3,},//L3,
		new KeyCode[]{KeyCode.Alpha4,},//R3,
		new KeyCode[]{KeyCode.UpArrow,},//UP,
		new KeyCode[]{KeyCode.DownArrow,},//DOWN,
		new KeyCode[]{KeyCode.LeftArrow,},//Left,
		new KeyCode[]{KeyCode.RightArrow,},//Right,
		new KeyCode[]{KeyCode.Space,KeyCode.Return},//Start,
		new KeyCode[]{KeyCode.LeftShift,},//Select,
		new KeyCode[]{KeyCode.X,KeyCode.S,KeyCode.Space,KeyCode.Return},//Ok,
		new KeyCode[]{KeyCode.Z,KeyCode.A,KeyCode.Escape},//Cancel,
		new KeyCode[]{KeyCode.UpArrow,KeyCode.DownArrow,KeyCode.LeftArrow,KeyCode.RightArrow,},//Allow,
		new KeyCode[]{KeyCode.X,KeyCode.Z,KeyCode.A,KeyCode.S,KeyCode.Q,KeyCode.W,KeyCode.Alpha1,KeyCode.Alpha2,KeyCode.Alpha3,KeyCode.Alpha4,},//Buttons,
	};

	JoypadCode [][] joyToKey = {
		new JoypadCode[]{JoypadCode.A,},//A = 0,
		new JoypadCode[]{JoypadCode.B,},//B,
		new JoypadCode[]{JoypadCode.X,},//X,
		new JoypadCode[]{JoypadCode.Y,},//Y,
		new JoypadCode[]{JoypadCode.L1,},//L1,
		new JoypadCode[]{JoypadCode.R1,},//R1,
		new JoypadCode[]{JoypadCode.L2,},//L2,
		new JoypadCode[]{JoypadCode.R2,},//R2,
		new JoypadCode[]{JoypadCode.L3,},//L3,
		new JoypadCode[]{JoypadCode.R3,},//R3,
		new JoypadCode[]{JoypadCode.Up,},//UP,
		new JoypadCode[]{JoypadCode.Down,},//DOWN,
		new JoypadCode[]{JoypadCode.Left,},//Left,
		new JoypadCode[]{JoypadCode.Right,},//Right,
		new JoypadCode[]{JoypadCode.Start},//Start,
		new JoypadCode[]{JoypadCode.Select,},//Select,
		new JoypadCode[]{JoypadCode.A,JoypadCode.X,JoypadCode.Start},//Ok,
		new JoypadCode[]{JoypadCode.B,JoypadCode.Y,},//Cancel,
		new JoypadCode[]{JoypadCode.Up,JoypadCode.Down,JoypadCode.Left,JoypadCode.Right,},//Allow,
		new JoypadCode[]{JoypadCode.A,JoypadCode.B,JoypadCode.X,JoypadCode.Y,JoypadCode.L1,JoypadCode.R1,JoypadCode.L2,JoypadCode.R2,JoypadCode.L3,JoypadCode.R3,},//Buttons,
	};

	string [] joyName =
	{
#if UNITY_OSX_OLD
		"joystick button 1",//A = 0,
		"joystick button 0",//B,
		"joystick button 3",//X,
		"joystick button 4",//Y,
		"joystick button 6",//L1,
		"joystick button 7",//R1,
		"",//L2,
		"",//R2,
		"",//L3,
		"",//R3,
		"",//Up,
		"",//Down,
		"",//Left,
		"",//Right,
		"joystick button 11",//Start,
		"joystick button 10",//Select,
		"",//Ok,
		"",//Cancel,
		"",//Allow,
		"",//Buttons,
		"",//Any,
#elif UNITY_OSX
		"joystick button 0",//A = 0,
		"joystick button 1",//B,
		"joystick button 2",//X,
		"joystick button 3",//Y,
		"joystick button 6",//L1,
		"joystick button 7",//R1,
		"",//L2,
		"",//R2,
		"joystick button 8",//L3,
		"joystick button 9",//R3,
		"",//Up,
		"",//Down,
		"",//Left,
		"",//Right,
		"joystick button 6",//Start,
		"joystick button 7",//Select,
		"",//Ok,
		"",//Cancel,
		"",//Allow,
		"",//Buttons,
		"",//Any,
#else //if UNITY_WIN
		"joystick button 0",//A = 0,
		"joystick button 1",//B,
		"joystick button 2",//X,
		"joystick button 3",//Y,
		"joystick button 4",//L1,
		"joystick button 5",//R1,
		"",//L2,
		"",//R2,
		"joystick button 8",//L3,
		"joystick button 9",//R3,
		"",//Up,
		"",//Down,
		"",//Left,
		"",//Right,
		"joystick button 6",//Start,
		"joystick button 7",//Select,
		"",//Ok,
		"",//Cancel,
		"",//Allow,
		"",//Buttons,
		"",//Any,
#endif		
	};

	bool [] oldJoyPressed = {
		false,//A = 0,
		false,//B,
		false,//X,
		false,//Y,
		false,//L1,
		false,//R1,
		false,//L2,
		false,//R2,
		false,//L3,
		false,//R3,
		false,//Up,
		false,//Down,
		false,//Left,
		false,//Right,
		false,//Start,
		false,//Select,
		false,//Ok,
		false,//Cancel,
		false,//Allow,
		false,//Buttons,
		false,//Any,
	};

	bool [] joyPressed = {
		false,//A = 0,
		false,//B,
		false,//X,
		false,//Y,
		false,//L1,
		false,//R1,
		false,//L2,
		false,//R2,
		false,//L3,
		false,//R3,
		false,//Up,
		false,//Down,
		false,//Left,
		false,//Right,
		false,//Start,
		false,//Select,
		false,//Ok,
		false,//Cancel,
		false,//Allow,
		false,//Buttons,
		false,//Any,
	};

	float [] joyAxis = {
		0,//A = 0,
		0,//B,
		0,//X,
		0,//Y,
		0,//L1,
		0,//R1,
		0,//L2,
		0,//R2,
		0,//L3,
		0,//R3,
		0,//Up,
		0,//Down,
		0,//Left,
		0,//Right,
		0,//Start,
		0,//Select,
		0,//Ok,
		0,//Cancel,
		0,//Allow,
		0,//Buttons,
		0,//Any,
	};

	float repeatStartWait = 0.2f;
	float repeatDuration = 0.1f;

	float [] repeatStartTimer = {
		0,//A = 0,
		0,//B,
		0,//X,
		0,//Y,
		0,//L1,
		0,//R1,
		0,//L2,
		0,//R2,
		0,//L3,
		0,//R3,
		0,//Up,
		0,//Down,
		0,//Left,
		0,//Right,
		0,//Start,
		0,//Select,
		0,//Ok,
		0,//Cancel,
		0,//Allow,
		0,//Buttons,
		0,//Any,
	};

	float [] repeatTimer = {
		0,//A = 0,
		0,//B,
		0,//X,
		0,//Y,
		0,//L1,
		0,//R1,
		0,//L2,
		0,//R2,
		0,//L3,
		0,//R3,
		0,//Up,
		0,//Down,
		0,//Left,
		0,//Right,
		0,//Start,
		0,//Select,
		0,//Ok,
		0,//Cancel,
		0,//Allow,
		0,//Buttons,
		0,//Any,
	};

	bool [] repeatMask = {
		false,//A = 0,
		false,//B,
		false,//X,
		false,//Y,
		false,//L1,
		false,//R1,
		false,//L2,
		false,//R2,
		false,//L3,
		false,//R3,
		false,//Up,
		false,//Down,
		false,//Left,
		false,//Right,
		false,//Start,
		false,//Select,
		false,//Ok,
		false,//Cancel,
		false,//Allow,
		false,//Buttons,
		false,//Any,
	};


	Mode curMode_ = Mode.Mouse;
	public Mode curMode {
		get{
			return curMode_;
		}
		private set{
			var prevMode = curMode_;
			curMode_ = value;
			if ( prevMode != curMode_ ){
				isModeChange = true;
			}
		}
	}
	bool isModeChange_ = false;
	public bool isModeChange {
		get{ 
			bool val = isModeChange_;
			isModeChange_ = false;
			return val;
		}
		private set{
			isModeChange_ = value;
		}
	}

	bool getKeyDownRepeat(JoypadCode code){
		bool pressed = getKey(code);
		bool down = getKeyDown(code);
		int codei = (int)code;
		bool repeatMask = this.repeatMask[codei];
		return pressed & repeatMask | down;
	}

	bool getKeyDown(JoypadCode code,bool repeat=false){
		if ( repeat ) return getKeyDownRepeat(code);
		int codei = (int)code;
		if ( code == JoypadCode.Any ){
			return getKeyDown(JoypadCode.Allow)||getKeyDown(JoypadCode.Buttons)||getKeyDown(JoypadCode.Start)||getKeyDown(JoypadCode.Select);
		}
		if ( codei >= keyCodes.Length ) return false;
		foreach(var kcode in keyCodes[codei]){
			if ( Input.GetKeyDown(kcode) ){
				curMode = Mode.Joypad;
				return true;
			}
		}
		foreach(var jcode in joyToKey[codei]){
			int jcodei = (int)jcode;
			if ( !oldJoyPressed[jcodei] && joyPressed[jcodei] ){
				curMode = Mode.Joypad;
				return true;
			}
		}
		return false;
	}

	bool getKey(JoypadCode code){
		int codei = (int)code;
		if ( code == JoypadCode.Any ){
			return getKey(JoypadCode.Allow)||getKey(JoypadCode.Buttons)||getKey(JoypadCode.Start)||getKey(JoypadCode.Select);
		}
		if ( codei >= keyCodes.Length ) return false;
		foreach(var kcode in keyCodes[codei]){
			if ( Input.GetKey(kcode) ){
				curMode = Mode.Joypad;
				return true;
			}
		}
		foreach(var jcode in joyToKey[codei]){
			int jcodei = (int)jcode;
			if ( joyPressed[jcodei] ){
				curMode = Mode.Joypad;
				return true;
			}
		}
		return false;
	}

	public static Mode GetMode(){
		return Instance.curMode;
	}

	public static void SetMode(Mode value){
		Instance.curMode = value;
	}

	public static bool GetKeyDownRepeat(JoypadCode code){
		return Instance.getKeyDownRepeat(code);
	}

	public static bool GetKeyDown(JoypadCode code,bool repeat=false){
		return Instance.getKeyDown(code,repeat);
	}

	public static bool GetKey(JoypadCode code){
		return Instance.getKey(code);
	}

	// Start is called before the first frame update
	void Start()
	{
		
	}

	static int pcnt = 0;

	// Update is called once per frame
	void Update()
	{
		for(int idx = 0 ; idx < joyName.Length ; idx++ ){
			var jn = joyName[idx];
			oldJoyPressed[idx] = joyPressed[idx];
			if ( jn == "" ){
				continue;
			}
			joyPressed[idx] = Input.GetKey(jn);
			//Debug.Log($"{jn}:{joyPressed[idx]}");
		}

		// 十字キーとアナログを混ぜる.
		{
#if UNITY_OSX_OLD
			// Mac環境だとXIputのパッドの十字キーがめちゃくちゃな事になっている.
			float lsh = Input.GetAxis ("L_Stick_H");
			float pdh = Input.GetAxis ("D_Pad_H");
			float pdv = Input.GetAxis ("D_Pad_V");
			// 1,-1 ↑
			// -1,1 ↓
			// -1,-1 <-
			// 1,1 ->
			// other nopress
			float dh = 0;
			float dv = 0;
			if ( pdh > 0.5f && pdv < -0.5f ) dv = -1;
			if ( pdh < -0.5f && pdv > 0.5f ) dv = 1;
			if ( pdh < -0.5f && pdv < -0.5f ) dh = -1;
			if ( pdh > 0.5f && pdv > 0.5f ) dh = 1;
#elif UNITY_OSX
			float lsh = Input.GetAxis ("L_Stick_H");
			float pdh = Input.GetAxis ("8th-Axis");
			float pdv = Input.GetAxis ("7th-Axis");
			pcnt++;
			pcnt %= 10;
			if ( pcnt == 0 ){
				//Debug.Log($"6th:{pdh} 7th:{pdv}");
			}
			// 1,-1 ↑
			// -1,1 ↓
			// -1,-1 ->
			// 1,1 <-
			// other nopress
			float dh = 0;
			float dv = 0;
			if ( pdh > 0.5f && pdv < -0.5f ) dv = -1;
			if ( pdh < -0.5f && pdv > 0.5f ) dv = 1;
			if ( pdh < -0.5f && pdv < -0.5f ) dh = 1;
			if ( pdh > 0.5f && pdv > 0.5f ) dh = -1;

#else
			float lsh = Input.GetAxis ("L_Stick_H");
			float dh = Input.GetAxis ("6th-Axis");
			float dv = Input.GetAxis ("7th-Axis");
#endif
			if ( lsh > 0.2f || dh > 0.2f ){
				joyPressed[(int)JoypadCode.Right] = true;
				joyPressed[(int)JoypadCode.Left] = false;
			}
			else if ( lsh < -0.2f || dh < -0.2f ) {
				joyPressed[(int)JoypadCode.Right] = false;
				joyPressed[(int)JoypadCode.Left] = true;
			}
			else{
				joyPressed[(int)JoypadCode.Right] = false;
				joyPressed[(int)JoypadCode.Left] = false;
			}

			float lsv = Input.GetAxis ("L_Stick_V");
			//Debug.Log($"DPadH:{dh} DPadV:{dv}");
			if ( lsv > 0.2f || dv > 0.2f ){
				joyPressed[(int)JoypadCode.Up] = false;
				joyPressed[(int)JoypadCode.Down] = true;
			}
			else if ( lsv < -0.2f || dv < -0.2f ) {
				joyPressed[(int)JoypadCode.Up] = true;
				joyPressed[(int)JoypadCode.Down] = false;
			}
			else{
				joyPressed[(int)JoypadCode.Up] = false;
				joyPressed[(int)JoypadCode.Down] = false;
			}
		}

		// リピート処理.
		for(int keyIdx = 0 ; keyIdx < repeatTimer.Length ; keyIdx++ ){
			var code = (JoypadCode)keyIdx;
			// リピートリセット.
			if ( !getKey(code) ){
				repeatStartTimer[keyIdx] = 0.0f;
				repeatTimer[keyIdx] = 0.0f;
				repeatMask[keyIdx] = false;
			}
			else{
				float oldStartTimer = repeatStartTimer[keyIdx];
				float newStartTimer = repeatStartTimer[keyIdx] + Time.deltaTime;;
				float deltaStartTime = newStartTimer - oldStartTimer;
				// 最初.
				if ( oldStartTimer < repeatStartWait && newStartTimer >= repeatStartWait ){
					repeatMask[keyIdx] = true;
					repeatStartTimer[keyIdx] = repeatStartWait;
				}
				// リピート処理中.
				else if ( newStartTimer >= repeatStartWait ){
					float oldTimer = repeatTimer[keyIdx];
					float newTimer = repeatTimer[keyIdx] + Time.deltaTime;;
					float deltaTime = newTimer - oldTimer;
					if ( oldTimer < repeatDuration && newTimer >= repeatDuration ){
						repeatMask[keyIdx] = true;
						// modさせる.
						repeatTimer[keyIdx] = Mathf.Repeat(newTimer,repeatDuration);
					}
					else{
						repeatTimer[keyIdx] = newTimer;
						repeatMask[keyIdx] = false;
					}
				}
				else{
					repeatStartTimer[keyIdx] = newStartTimer;
					repeatMask[keyIdx] = false;
				}
			}
		}
	}
}
}