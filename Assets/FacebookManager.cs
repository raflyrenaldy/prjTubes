using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;
using System.Collections.Generic;

public class FacebookManager : MonoBehaviour {

	public Text userIdText;

	// Use this for initialization
	private void Awake()
	{
		if (!FB.IsInitialized) {
			FB.Init ();
		} else {
			FB.ActivateApp ();
		}
	}

	public void Login(){
		FB.LogInWithReadPermissions (callback:OnLogin);
	}
	private void OnLogin(ILoginResult result){
		if (FB.IsLoggedIn) {
			AccessToken token = AccessToken.CurrentAccessToken;
			userIdText.text = token.UserId;
		}
		else {
			Debug.Log ("Canceled Login");
		}
	}

	public void Share(){
		FB.ShareLink(contentTitle:"Pilot Page Message",
			contentURL:new System.Uri("http:L//n3k.ca"),
			contentDescription:"Heres a link to my website",
			callback:onShare);
	}

	private void onShare(IShareResult result)
	{
		if (result.Cancelled || !string.IsNullOrEmpty (result.Error)) {
			Debug.Log ("ShareLink error: " + result.Error);
		} else if (!string.IsNullOrEmpty (result.PostId)) {
			Debug.Log (result.PostId);
		} else {
			Debug.Log ("Share Succeed");
		}
	}
}
