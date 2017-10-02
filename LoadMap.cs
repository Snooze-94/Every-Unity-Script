using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class parseJSON{
	public int height;
	public int width;
	public List<int> mapList = new List<int> ();
}

public class LoadMap : MonoBehaviour {

	public TextAsset map;
	public GameObject[] tiles = new GameObject[2];
	private string json;

	void Start () {
		json = map.text;
		json = json.Replace (System.Environment.NewLine, "");
		print (json);

		Processjson(json);

	}

	private void Processjson(string jsonString)
	{
		JsonData jsonvale = JsonMapper.ToObject(jsonString);
		parseJSON parsejson;
		parsejson = new parseJSON();


		parsejson.width = (int) jsonvale["layers"][0]["width"];
		parsejson.height = (int) jsonvale["layers"][0]["height"];



		for(int i = 0; i<jsonvale["layers"][0]["data"].Count; i++)
		{
			parsejson.mapList.Add((int)jsonvale ["layers"] [0] ["data"] [i] - 1);
		}    
			
		DrawMap (parsejson.mapList, parsejson.width, parsejson.height);

	}

	private void DrawMap(List<int> map, int width, int height){
		transform.position = new Vector3 (-Mathf.Round (width / 2), Mathf.Round (height / 2), transform.position.z);

		for (int y = 0; y <= height; y++) {
			for (int x = 0; x < width; x++) {
				GameObject tile = Instantiate (tiles [map [x + (y * width)]], transform.position + new Vector3 (x, -y, 0), transform.rotation);
				tile.transform.parent = transform;
			}
		}

	}
}
