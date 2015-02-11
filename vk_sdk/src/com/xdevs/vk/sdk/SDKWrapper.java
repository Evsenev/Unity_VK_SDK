package com.xdevs.vk.sdk;

import com.vk.sdk.VKSdk;

public class SDKWrapper {
	
	 public static void initialize(IListener listener, String appId) {
		 VKSdk.initialize(new Listener(listener), appId);
	 }

}
