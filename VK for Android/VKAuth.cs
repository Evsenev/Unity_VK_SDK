using UnityEngine;
using System.Collections;

public class VKAuth : MonoBehaviour {

	private void LoginVK(tk2dUIItem item)
	{
		VKSdk.authorize(new string[] { Scope.NOTIFICATIONS, Scope.FRIENDS, Scope.PHOTOS, Scope.WALL, Scope.GROUPS, Scope.OFFLINE }, true, false);
		Debug.Log ("LOGIN BUTTON CLICKED");
	}

	private void Start()
	{
		VKSdk.initialize( new VKListener(), "4749692");
	}
	
	private void OnGUI()
	{

		if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 150, 60), "LOG IN?"))
		{
			VKSdk.authorize(new string[] { Scope.NOTIFICATIONS, Scope.FRIENDS, Scope.PHOTOS, Scope.WALL, Scope.GROUPS, Scope.OFFLINE }, true, false);
			Debug.Log ("LOGIN BUTTON CLICKED");
		}

		if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 -220, 150, 60), "isLOGGED IN?"))
		{
			Debug.Log("isLoggedIn = " + VKSdk.isLoggedIn());
		}
		
		if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 -140, 150, 60), "LOG OUT"))
		{
			VKSdk.logout();
		}
		
		
	}
}
