package com.plugin.unity;

import java.util.Random;

import com.unity3d.player.UnityPlayer;

import android.util.Log;

public class PluginClass {
	private static String TAG = "UnityPlugin";
	
	private static PluginClass singleton;
	
	public static PluginClass getSingleton() {
		if(singleton==null) {
			singleton = new PluginClass();
		}
		return singleton;
	}
	
	public void thisIsAMethod() {
		Log.d(TAG, "You called a method");
	}
	
	public static void thisIsAStaticMethod() {
		Log.d(TAG, "You called a static method");
	}
	
	public int thisGetsARandomNumber() {
		Random r = new Random();
		int number = r.nextInt();
		Log.d(TAG, "The random number is: "+number);
		return number;
	}
	
	public void thisCapitalizesText(String text) {
		Log.d(TAG, "Capitalized the text");
		UnityPlayer.UnitySendMessage("PluginBridgePrefab", "getCapitalizedText", text.toUpperCase());
	}
}
