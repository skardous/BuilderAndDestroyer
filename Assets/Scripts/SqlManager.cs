using UnityEngine;
using System.Collections;
using System;


public class SqlManager : MonoBehaviour
{
	private string secretKey = "kelsingra"; // Edit this value and make sure it's the same as the one stored on the server
	private string addScoreURL = "http://builder-and-destroyer.tk/addbuilding.php?"; //be sure to add a ? to your url
	private string highscoreURL = "http://builder-and-destroyer.tk/getbuildings.php?";
	private string updateScoreURL = "http://builder-and-destroyer.tk/updatebuilding.php?";
	

	
	/*void Start()
	{
		StartCoroutine(GetScores());
	}*/

	public string Md5Sum(string strToEncrypt)
	{
		System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
		byte[] bytes = ue.GetBytes(strToEncrypt);
		
		// encrypt bytes
		System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
		byte[] hashBytes = md5.ComputeHash(bytes);
		
		// Convert the encrypted bytes back to a string (base 16)
		string hashString = "";
		
		for (int i = 0; i < hashBytes.Length; i++)
		{
			hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
		}
		
		return hashString.PadLeft(32, '0');
	}
	
	// remember to use StartCoroutine when calling this function!
	public IEnumerator PostBuilding(string name, string buildingData)
	{
		print ("posting building1");
		//This connects to a server side php script that will add the name and score to a MySQL DB.
		// Supply it with a string representing the players name and the players score.
		string hash = Md5Sum(name + buildingData + secretKey);
		
		string post_url = addScoreURL + "name=" + WWW.EscapeURL(name) + "&buildingData=" + buildingData + "&hash=" + hash;
		
		// Post the URL to the site and create a download object to get the result.
		WWW hs_post = new WWW(post_url);

		print ("posting building2");
		
		yield return hs_post; // Wait until the download is done
		
		if (hs_post.error != null)
		{
			print("There was an error posting the high score: " + hs_post.error);
		}
	}
	
	// Get the scores from the MySQL DB to display in a GUIText.
	// remember to use StartCoroutine when calling this function!
	public IEnumerator GetBuildings(string returnString, int page, Action<string> function, string searchtext)
	{
		//gameObject.guiText.text = "Loading Scores";

		string get_url = highscoreURL + "page=" + 0 + "&searchtext=" + searchtext;
		
		WWW hs_get = new WWW(get_url);
		yield return hs_get;
		
		if (hs_get.error != null)
		{
			print("There was an error getting the high score: " + hs_get.error);
		}
		else
		{
			print ("return text = " + hs_get.text);
			returnString = hs_get.text;
			function(returnString);
			//gameObject.GetComponent<GUIText>().text = hs_get.text; // this is a GUIText that will display the scores in game.
		}
	}

	public IEnumerator UpdateBuildingScore(string id, string score, string newChallenger)
	{
		print ("updating building with id = " + id + " and set score = " + score + " and set newChallenger = " + newChallenger);
		//This connects to a server side php script that will add the name and score to a MySQL DB.
		// Supply it with a string representing the players name and the players score.

		//string hash = Md5Sum(name + buildingData + secretKey);
		
		string update_url = updateScoreURL + "best_score=" + score + "&id=" + id + "&challenger=" + newChallenger;
		
		// Post the URL to the site and create a download object to get the result.
		WWW hs_update = new WWW(update_url);
		
		print ("posting building2");
		
		yield return hs_update; // Wait until the download is done
		
		if (hs_update.error != null)
		{
			print("There was an error posting the high score: " + hs_update.error);
		}
	}
	
}