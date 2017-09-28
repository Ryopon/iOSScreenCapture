public enum AVAuthorizationStatus {
	/// <summary>
	/// ユーザーはまだ、このアプリに与える権限を選択をしていない
	/// </summary>
	NotDetermined,

	/// <summary>
	/// カメラへのアクセスが許可されていない(parental controlなどで制限されている)
	/// </summary>
	Restricted,

	/// <summary>
	/// ユーザーが明示的に、カメラへアクセスすることを拒否した
	/// </summary>
	Denied,

	/// <summary>
	/// ユーザーが、カメラへアクセスすることを許可している
	/// </summary>
	Authorized
}