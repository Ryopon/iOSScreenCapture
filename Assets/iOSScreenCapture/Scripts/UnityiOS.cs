using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class UnityiOS : MonoBehaviour {

	[DllImport("__Internal")]
	private static extern void _PlaySystemShutterSound();

	[DllImport("__Internal")]
	private static extern void _SendTexture(byte[] textureByte, int length);

	[DllImport("__Internal")]
	private static extern void _RequestCameraPermission();

	[DllImport("__Internal")]
	private static extern void _RequestCameraRollPermission();

	[DllImport("__Internal")]
	private static extern int _HasCameraPermission();

	[DllImport("__Internal")]
	private static extern int _HasCameraRollPermission();

	[DllImport("__Internal")]
	private static extern void _GoToSettings();

	public static void PlaySystemShutterSound() {
		_PlaySystemShutterSound();
	}

	public static void SaveTexture(byte[] textureByte, int length) {
		_SendTexture(textureByte, length);
	}

	public static void RequestPermissions() {
		AVAuthorizationStatus avstatus = HasCameraPermission();
		PHAuthorizationStatus phstatus = HasCameraRollPermission();

		//アクセス許可のリクエストを出していない場合はリクエストを送る
		if (avstatus == AVAuthorizationStatus.NotDetermined) {
			_RequestCameraPermission();
		}

		if(phstatus == PHAuthorizationStatus.NotDetermined) {
			_RequestCameraRollPermission();
		}
	}

	public void RequestPermissions_forUGUI() {
		RequestPermissions();
	}

	public static AVAuthorizationStatus HasCameraPermission() {
#if !UNITY_EDITOR
		return (AVAuthorizationStatus)Enum.ToObject(
   				typeof(AVAuthorizationStatus), _HasCameraPermission());
#endif
		return AVAuthorizationStatus.Authorized;
	}

	public static PHAuthorizationStatus HasCameraRollPermission() {
#if !UNITY_EDITOR
        return (PHAuthorizationStatus)Enum.ToObject(
				typeof(PHAuthorizationStatus), _HasCameraRollPermission());
#endif
		return PHAuthorizationStatus.Authorized;
	}

	public static void GoToSettings() {
#if !UNITY_EDITOR
        _GoToSettings();
#endif
	}

	public void GoToSettings_forUGUI() {
#if !UNITY_EDITOR
        _GoToSettings();
#endif
	}
}