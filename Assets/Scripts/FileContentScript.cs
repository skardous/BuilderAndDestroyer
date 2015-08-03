using UnityEngine;
using System.Collections;
using System;

public class FileContentScript : MonoBehaviour {

	private string fileData = "";

	public void setFileData(string data)
	{
		fileData = data;
	}

	public void parse()
	{
		FileParser parser = GameObject.Find ("FileParser").GetComponent<FileParser> ();
		parser.parseData (fileData);
	}


}
