# iOSScreenCapture
Unity+iOSでカメラ/写真へのアクセスと撮影+カメラロールへの保存機能をまとめたライブラリです。

## 導入方法
iOSScreenCapture.unitypackageをインポートして下さい。

後はQiitaの記事を見てよしなに。
https://qiita.com/Ryopon/items/a2cf618eb570637deffb

## サンプル
UnityiOS.RequestPermissionsでアクセス許可をリクエストしてUnityiOSScreenCapture.Executeで撮影する流れです。
```c#
using UnityEngine;

public class Sample : MonoBehaviour {

	public UnityiOSScreenCapture screenCapture;

	void Start() {
            //RequestPermissionを呼び出すことでカメラ/写真へのアクセス許可リクエストを表示します
		UnityiOS.RequestPermissions();
	}

	private void Update() {
		if(UnityiOS.HasCameraRollPermission() == PHAuthorizationStatus.Authorized) {
			if(Input.GetMouseButton(0)) {
                //UnityiOSScreenCapture.Executeで撮影+カメラロールへの保存を行います
				screenCapture.Execute();
			}
		}
	}
}
```

## 参考にさせて頂いたサイト
Unity + iOSでApplication.CaptureScreenshotを使わずにスクリーンキャプチャーをカメラロールに保存する
http://marunouchi-tech.i-studio.co.jp/2155/

## License
MIT
