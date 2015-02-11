package com.xdevs.vk.sdk;

import com.vk.sdk.VKAccessToken;
import com.vk.sdk.api.VKError;

public interface IListener {

	public void onCaptchaError(VKError captchaError);
	
	public void onTokenExpired(VKAccessToken expiredToken);
	
	public  void onAccessDenied(VKError authorizationError);

	public void onReceiveNewToken(VKAccessToken newToken);

	public void onAcceptUserToken(VKAccessToken token);

	public void onRenewAccessToken(VKAccessToken token);
	
	
}
