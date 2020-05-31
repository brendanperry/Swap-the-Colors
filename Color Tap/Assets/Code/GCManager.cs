using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms.GameCenter;

public class GCManager : MonoBehaviour {

	void Start () {
		Social.localUser.Authenticate(success => {
            if (success)
                Debug.Log("authenticated");
            else
                Debug.Log("Failed to authenticate");
        });
	}

	public void OnClick () {
		if(Social.localUser.authenticated)
			GameCenterPlatform.ShowLeaderboardUI("topScore", UnityEngine.SocialPlatforms.TimeScope.AllTime);
	}
}
