public enum PHAuthorizationStatus {
	/// <summary>
	/// ユーザーはまだ、このアプリに与える権限を選択をしていない
	/// </summary>
	NotDetermined,

	/// <summary>
	/// PhotoLibraryへのアクセスが許可されていない(parental controlなどで制限されている)
	/// </summary>
	Restricted,

	/// <summary>
	/// ユーザーが明示的に、写真のデータへアクセスすることを拒否した
	/// </summary>
	Denied,

	/// <summary>
	/// ユーザーが、写真のデータへアクセスすることを許可している
	/// </summary>
	Authorized
}