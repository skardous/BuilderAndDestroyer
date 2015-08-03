using UnityEngine;
using System.Collections;
//using UnityEngine.UI;
//using Amazon.S3;
//using Amazon.S3.Model;
//using Amazon.Runtime;
//using System.IO;
//using System;
//using Amazon.S3.Util;
//using System.Collections.Generic;
//using Amazon.CognitoIdentity;
//using Amazon;

public class SaveOnAWSBuilding : MonoBehaviour {

//	public Text ResultText = null;
//    public string IdentityPoolId = "";
//	
//
//	private IAmazonS3 _s3Client;
//	private AWSCredentials _credentials;
//	
//	private AWSCredentials Credentials
//	{
//		get
//		{
//			if (_credentials == null)
//				_credentials = new CognitoAWSCredentials(IdentityPoolId, RegionEndpoint.EUWest1);
//			return _credentials;
//		}
//	}
//	
//	private IAmazonS3 Client
//	{
//		get
//		{
//			if (_s3Client == null)
//			{
//				_s3Client = new AmazonS3Client(Credentials,RegionEndpoint.EUWest1);
//			}
//			//test comment
//			return _s3Client;
//		}
//	}
//	
//	public void PostObject(string fileName)
//	{
//		ResultText.text = "Retrieving the file";
//		
//		//string fileName = GetFileHelper();
//		
//		var stream = new FileStream(Application.temporaryCachePath + Path.DirectorySeparatorChar + fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
//		print ( "File found at ==== " + Application.temporaryCachePath + Path.DirectorySeparatorChar + fileName);
//		
//		ResultText.text += "\nCreating request object";
//		var request = new PostObjectRequest()
//		{
//			Bucket = "builderanddestroyer",
//			Key = fileName,
//			InputStream = stream,
//			CannedACL = S3CannedACL.Private
//		};
//		
//		ResultText.text += "\nMaking HTTP post call";
//		
//		Client.PostObjectAsync(request, (responseObj) =>
//		                       {
//			if (responseObj.Exception == null)
//			{
//				ResultText.text += string.Format("\nobject {0} posted to bucket {1}", responseObj.Request.Key, responseObj.Request.Bucket);
//			}
//			else
//			{
//				ResultText.text += "\nException while posting the result object";
//				ResultText.text += string.Format("\n receieved error {0}", responseObj.Response.HttpStatusCode.ToString());
//			}
//		});
//	}
//
//
//
//	public void SaveMyScene()
//	{
//
//		GameControl gameManager = GameObject.Find ("GameControl").GetComponent<GameControl> ();
//		print ( "TEMP ==== " + Application.temporaryCachePath);
//
//		System.Guid uid = System.Guid.NewGuid();
//
//		System.IO.File.WriteAllText(Application.temporaryCachePath + Path.DirectorySeparatorChar + uid.ToString() + "." + "txt", gameManager.getSceneString());
//		print ( "File saved at ==== " + Application.temporaryCachePath + Path.DirectorySeparatorChar + uid.ToString() + "." + "txt");
//		
//		print ( "STRING ==== " + gameManager.getSceneString());
//
//		PostObject (uid.ToString () + "." + "txt");
//
//	}

}
