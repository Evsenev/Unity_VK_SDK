package com.xdevs.vk.sdk;

import com.unity3d.player.*;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import com.vk.sdk.*;

public class UnityVKActivity extends UnityPlayerActivity {

	
	@Override 
	protected void onResume() { 
		super.onResume(); 
		VKUIHelper.onResume(this); 
		Log.i("VK_ACTIVITY", "onResume");
	} 

	@Override 
	protected void onDestroy() { 
		super.onDestroy(); 
		VKUIHelper.onDestroy(this);
		Log.i("VK_ACTIVITY", "onDestroy");
	} 

	@Override 
	protected void onActivityResult(int requestCode, int resultCode, Intent data) { 
		super.onActivityResult(requestCode, resultCode, data); 
		VKUIHelper.onActivityResult(this, requestCode, resultCode, data); 
		Log.i("VK_ACTIVITY", "onActivityResult");
	}
	
	 protected void onCreate(Bundle savedInstanceState) {

	    // call UnityPlayerActivity.onCreate()
	    super.onCreate(savedInstanceState);

	    // print debug message to logcat
	    Log.d("OverrideActivity", "onCreate called!");
	    VKUIHelper.onCreate(this);
	 }

	 public void onBackPressed()
	 {
	    // instead of calling UnityPlayerActivity.onBackPressed() we just ignore the back button event
	    // super.onBackPressed();
	 }
	
}
