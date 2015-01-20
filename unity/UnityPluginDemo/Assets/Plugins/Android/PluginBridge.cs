using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PluginBridge : MonoBehaviour {

	private static AndroidJavaObject pluginObject;

	public Transform buttonCapitalize;
	Text buttonTextCapitalize;

	public Transform buttonRandom;
	Text buttonTextRandom;

	void Awake() {
		DontDestroyOnLoad(this);
	}

	void Start () {
		if (Application.platform != RuntimePlatform.Android) {
			return;
		}
		using (var pluginClass = new AndroidJavaClass( "com.plugin.unity.PluginClass" )) {
			pluginObject = pluginClass.CallStatic<AndroidJavaObject>("getSingleton");
		}

		buttonTextCapitalize = buttonCapitalize.GetComponent<Text> ();
		buttonTextRandom = buttonRandom.GetComponent<Text> ();
	}

	public void callMethod() {
		pluginObject.Call("thisIsAMethod");
	}

	public void callStaticMethod() {
		pluginObject.CallStatic("thisIsAStaticMethod");
	}

	public void callRandom() {
		int number = pluginObject.Call<int>("thisGetsARandomNumber");
		Debug.Log ("random number: "+number);
		buttonTextRandom.text = "" + number;
	}

	public void callCapitalize() {
		pluginObject.Call("thisCapitalizesText", buttonTextCapitalize.text);
	}

	public void getCapitalizedText(string text) {
		Debug.Log ("text got: "+text);
		buttonTextCapitalize.text = text;
	}
}
