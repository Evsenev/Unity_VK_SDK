using System;
using System.Runtime.Serialization;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VKListener : AndroidJavaProxy {
	public VKListener()
		: base("com.xdevs.vk.sdk.IListener") {}

	public void onCaptchaError(AndroidJavaObject captchaError)
	{
		VKError error = new VKError(captchaError);
		Debug.Log("Captcha error - error code: " + error.errorCode);
	}

	public void onTokenExpired(AndroidJavaObject expiredToken)
	{
		VKAccessToken accessToken = new VKAccessToken(expiredToken);
		Debug.Log("Token expired - expires in: "+accessToken.expiresIn);
	}

	public void onAccessDenied(AndroidJavaObject authorizationError)
	{
		VKError error = new VKError(authorizationError);
		Debug.Log("Access Denied - error code: "+error.errorCode);
	}

	public void onReceiveNewToken(AndroidJavaObject newToken)
	{
		VKAccessToken accessToken = new VKAccessToken(newToken);
		Debug.Log("New token recieved - access token: " + accessToken.accessToken);
	}

	public void onAcceptUserToken(AndroidJavaObject token)
	{
		VKAccessToken accessToken = new VKAccessToken(token);
		Debug.Log("Token accepted - access token: " + accessToken.accessToken);
	}

	public void onRenewAccessToken(AndroidJavaObject token)
	{
		VKAccessToken accessToken = new VKAccessToken(token);
		Debug.Log("Renew access token - access token: " + accessToken.accessToken);
	}
}

public class VKError
{
	public int errorCode;
	public string errorReason;
	public string captchaImg;
	public string captchaSid;

	public VKError(AndroidJavaObject vkErrorAJO)
	{
		errorCode = vkErrorAJO.Get<int>("errorCode");
		errorReason = vkErrorAJO.Get<string>("errorReason");
		captchaImg = vkErrorAJO.Get<string>("captchaImg");
		captchaSid = vkErrorAJO.Get<string>("captchaSid");
	}
}

public class VKAccessToken 
{
	public string accessToken;
	public long created;
	public int expiresIn;
	public string secret;
	public string SUCCESS;
	public string userId;

	public VKAccessToken(AndroidJavaObject vkAccessTokenAJO)
	{
		accessToken = vkAccessTokenAJO.Get<string>("accessToken");
		created = vkAccessTokenAJO.Get<long>("created");
		expiresIn = vkAccessTokenAJO.Get<int>("expiresIn");
		secret = vkAccessTokenAJO.Get<string>("secret");
		userId = vkAccessTokenAJO.Get<string>("userId");
	}
}

public class VKSdk
{
	private static AndroidJavaClass sdk;

	public static void authorize(string scope)
	{
		sdk.CallStatic("authorize", scope);
	}

	public static void authorize(string[] scope, bool revoke, bool forceOAuth)
	{
		sdk.CallStatic("authorize", scope, revoke, forceOAuth);
	}

	public static VKAccessToken getAccessToken()
	{
		VKAccessToken result;
		result = new VKAccessToken(sdk.GetStatic<AndroidJavaObject>("getAccessToken"));
		return result;
	}

	public static void initialize(VKListener listener, string appID)
	{
		sdk = new AndroidJavaClass("com.vk.sdk.VKSdk");
		AndroidJavaClass pluginClass = new AndroidJavaClass("com.xdevs.vk.sdk.SDKWrapper");
		pluginClass.CallStatic("initialize", listener, appID);
	}

	public static bool isLoggedIn()
	{
		bool isLoggedIn = sdk.CallStatic<bool>("isLoggedIn");
		return isLoggedIn;
	}

	public static void logout()
	{
		sdk.CallStatic("logout");
	}
}

public class Scope{
	public const string NOTIFY = "notify";
	public const string FRIENDS = "friends";
	public const string PHOTOS = "photos";
	public const string AUDIO = "audio";
	public const string VIDEO = "video";
	public const string DOCS = "docs";
	public const string NOTES = "notes";
	public const string PAGES = "pages";
	public const string STATUS = "status";
	public const string WALL = "wall";
	public const string GROUPS = "groups";
	public const string MESSAGES = "messages";
	public const string NOTIFICATIONS = "notifications";
	public const string STATS = "stats";
	public const string ADS = "ads";
	public const string OFFLINE = "offline";
	public const string NOHTTPS = "nohttps";
	public const string DIRECT = "direct";
}
