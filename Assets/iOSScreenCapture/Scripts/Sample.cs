using UnityEngine;

public class Sample : MonoBehaviour {

	public UnityiOSScreenCapture screenCapture;

	void Start() {
		UnityiOS.RequestPermissions();
	}

	private void Update() {
		if(UnityiOS.HasCameraRollPermission() == PHAuthorizationStatus.Authorized) {
			if(Input.GetMouseButton(0)) {
				screenCapture.Execute();
			}
		}
	}
}
