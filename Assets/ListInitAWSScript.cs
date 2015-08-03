using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using Amazon.S3;
//using Amazon.S3.Model;
//using Amazon.Runtime;
//using System.IO;
//using System;
//using Amazon.S3.Util;
//using System.Collections.Generic;
//using Amazon.CognitoIdentity;
//using Amazon;

public class ListInitAWSScript : MonoBehaviour {

//	public Text ResultText = null;
//	public string S3BucketName = null;	
//	public string IdentityPoolId = "";
//	public GameObject itemPrefab;
//
//	List<string> fileNames = new List<String> ();
//
//	private bool finishedReq = false;
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
//	public List<string> GetObjects()
//	{
//		ResultText.text = "Fetching all the Objects from " + S3BucketName;
//		
//		var request = new ListObjectsRequest()
//		{
//			BucketName = S3BucketName
//		};
//		
//		Client.ListObjectsAsync(request, (responseObject) =>
//		                        {
//			ResultText.text += "\n";
//			if (responseObject.Exception == null)
//			{
//				ResultText.text += "Got Response \nPrinting now \n";
//				responseObject.Response.S3Objects.ForEach((o) =>
//				                                          {
//					ResultText.text += o.Key;
//					fileNames.Add(o.Key);
//
//					/*listItem = Instantiate(itemPrefab) as GameObject;
//					listItem.transform.parent = buildingsList.transform;
//					listItem.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
//					
//					listItem.GetComponentInChildren<Text>().text = o.Key;*/
//				});
//			}
//			else
//			{
//				ResultText.text += "Got Exception \n";
//			}
//			UpdateList();
//		});
//
//		return fileNames;
//	}
//
//	private string GetObject(string SampleFileName)
//	{
//		//ResultText.text = string.Format("fetching {0} from bucket {1}", SampleFileName, S3BucketName);
//		string res = "";
//		Client.GetObjectAsync(S3BucketName, SampleFileName, (responseObj) =>
//		                      {
//			string data = null;
//			var response = responseObj.Response;
//			if (response.ResponseStream != null)
//			{
//				using (StreamReader reader = new StreamReader(response.ResponseStream))
//				{
//					data = reader.ReadToEnd();
//				}
//				
//				//ResultText.text += "\n";
//				//ResultText.text += data;
//				res += data;
//			}
//		});
//
//		return res;
//	}
//
//	private void UpdateList()
//	{
//		GameObject buildingsList = GameObject.Find ("BuildingsList");
//		GameObject listItem;
//		foreach (string f in fileNames) {
//			listItem = Instantiate(itemPrefab) as GameObject;
//			listItem.transform.parent = buildingsList.transform;
//			listItem.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
//
//			listItem.GetComponentInChildren<Text>().text = f;
//		}
//	}
//	
//	// Use this for initialization
//	void Start () {
//
//
//
//
//		GetObjects ();
//		do {
//			print ("___________________________________"+fileNames.Count);
//			if (finishedReq == true)
//			{
//				print ("ITS OVEEEERRR");
//			}
//		} while (finishedReq = false);
//
//		print ("___________________________________"+fileNames.Count);
//
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}
}
