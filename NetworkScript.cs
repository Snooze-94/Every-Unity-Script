using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class NetworkScript : MonoBehaviour {

  SocketIOComponent socket;
  public GameObject player;
  public Transform playerTransform;
  public GameObject username;
  public GameObject networkPlayerPrefab;
  private Dictionary<string, GameObject> players = new Dictionary<string, GameObject>();

  string playerId;

  float tick = Config.SERVERTICKRATE;
  float passed;

	// Use this for initialization
	void Start () {
    Application.runInBackground = true;
    socket = GetComponent<SocketIOComponent>();

    socket.On("register", Register);
    socket.On("move", OtherMove);
    socket.On("spawn", OtherSpawn);
    socket.On("disconnected", Delet);
    socket.On("shot", Shot);
  }

  private void FixedUpdate()
  {
    passed += Time.fixedDeltaTime;
    if(passed >= 1 / tick)
    {
      passed = 0;
      SendPosition();
    }
  }

  public void Register(SocketIOEvent e)
  {
    JSONObject data = e.data;
    playerId = data["id"].str;
    username.GetComponent<TextMesh>().text = playerId;
    float posX = float.Parse(e.data["x"].str);
    float posY = float.Parse(e.data["y"].str);
    float posZ = float.Parse(e.data["z"].str);
    float rotY = float.Parse(e.data["rotation"].str);
    player.transform.position = new Vector3(posX, posY, posZ);
    playerTransform.eulerAngles = new Vector3(0, rotY, 0);
  }

  public void OtherMove(SocketIOEvent e)
  {
    
    string otherUsename = e.data["id"].str;
    float posX = float.Parse(e.data["x"].str);
    float posY = float.Parse(e.data["y"].str);
    float posZ = float.Parse(e.data["z"].str);
    float rotY = float.Parse(e.data["rotation"].str);
    bool pointing = bool.Parse(e.data["pointing"].str);
    players[otherUsename].GetComponent<NetworkPlayer>().Move(posX, posY, posZ, rotY);
    players[otherUsename].GetComponent<NetworkPlayer>().pointing = pointing;
  }

  public void OtherSpawn(SocketIOEvent e)
  {
    //print("otherspawn" + e);
    string otherUsename = e.data["id"].str;
    float posX = float.Parse(e.data["x"].str);
    float posY = float.Parse(e.data["y"].str);
    float posZ = float.Parse(e.data["z"].str);
    //float rotY = float.Parse(e.data["rotation"].str);
    GameObject otherPlayer = Instantiate(networkPlayerPrefab, new Vector3(posX, posY, posZ), networkPlayerPrefab.transform.rotation) as GameObject;
    otherPlayer.GetComponent<NetworkPlayer>().username = otherUsename;
    players[otherUsename] = otherPlayer;
  }

  public void Shot(SocketIOEvent e)
  {
    string otherUsename = e.data["id"].str;
    float oX = float.Parse(e.data["ox"].str);
    float oY = float.Parse(e.data["oy"].str);
    float oZ = float.Parse(e.data["oz"].str);
    float dX = float.Parse(e.data["dx"].str);
    float dY = float.Parse(e.data["dy"].str);
    float dZ = float.Parse(e.data["dz"].str);
    players[otherUsename].GetComponent<NetworkPlayer>().Shot(new Vector3(oX,oY,oZ), new Vector3(dX,dY,dZ));
  }

  public void SendPosition()
  {
    Dictionary<string, string> data = new Dictionary<string, string>();
    data["id"] = playerId;
    data["x"] = playerTransform.position.x.ToString();
    data["y"] = playerTransform.position.y.ToString();
    data["z"] = playerTransform.position.z.ToString();
    data["rotation"] = playerTransform.eulerAngles.y.ToString();
    data["pointing"] = player.GetComponentInChildren<Player>().isPointing.ToString();
    socket.Emit("user:move", new JSONObject(data));
  }

  public void SendShot(Vector3 shotOrigin, Vector3 shotDest)
  {
    Dictionary<string, string> data = new Dictionary<string, string>();
    data["ox"] = shotOrigin.x.ToString();
    data["oy"] = shotOrigin.y.ToString();
    data["oz"] = shotOrigin.z.ToString();
    data["dx"] = shotDest.x.ToString();
    data["dy"] = shotDest.y.ToString();
    data["dz"] = shotDest.z.ToString();
    socket.Emit("user:shot", new JSONObject(data));
  }

  public void Delet(SocketIOEvent e)
  {
    string otherUsename = e.data["id"].str;
    Destroy(players[otherUsename]);
    players.Remove(otherUsename);
  }
}
