package com.xdevs.vk.sdk;

import android.util.Log;

import com.vk.sdk.VKAccessToken;
import com.vk.sdk.VKSdkListener;
import com.vk.sdk.api.VKError;

public class Listener extends VKSdkListener {
	
	private IListener m_listener;
	
	public Listener (IListener listener) {
		m_listener = listener;
		Log.i("VK_LISTENER", "LISTENER CRATED from JAVA");
	}

	@Override
	public void onCaptchaError(VKError captchaError) {
		Log.i("VK_LISTENER", "error = "+captchaError.errorMessage);
		m_listener.onCaptchaError(captchaError);	
	}

	@Override
	public void onTokenExpired(VKAccessToken expiredToken) {
		m_listener.onTokenExpired(expiredToken);
		Log.i("VK_LISTENER", "Expired Token = "+ expiredToken.accessToken);
	}

	@Override
	public void onAccessDenied(VKError authorizationError) {
		Log.i("VK_LISTENER", "Auth error = "+ authorizationError.errorMessage);
		m_listener.onAccessDenied(authorizationError);
	}
	
	@Override
	public void onReceiveNewToken(VKAccessToken newToken){
		Log.i("VK_LISTENER", "OnRecive new Token = "+ newToken.accessToken);
		m_listener.onReceiveNewToken(newToken);
	}

	@Override
	public void onAcceptUserToken(VKAccessToken token){
		m_listener.onAcceptUserToken(token);
		Log.i("VK_LISTENER", "OnAccept User Token = "+ token.accessToken);
	}

	@Override
	public void onRenewAccessToken(VKAccessToken token){
		m_listener.onRenewAccessToken(token);
		Log.i("VK_LISTENER", "OnRenew Token = "+ token.accessToken);
	}

}
