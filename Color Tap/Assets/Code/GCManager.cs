using UnityEngine;
using System.Collections;
using Prime31;

public class GCManager : MonoBehaviour {

	void Start () {
		GameCenterBinding.authenticateLocalPlayer ();
	}

	public void OnClick () {
		GameCenterBinding.showLeaderboardWithTimeScope (GameCenterLeaderboardTimeScope.AllTime);
	}
}
