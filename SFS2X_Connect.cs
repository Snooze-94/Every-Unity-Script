using UnityEngine;
using System.Collections;
using Sfs2X;
using Sfs2X.Core;
using Sfs2X.Requests;
using Sfs2X.Entities;

public class SFS2X_Connect : MonoBehaviour {

	public string ConfigFile = "Scripts/Network/sfs-config.xml";
	public bool UseConfigFile = false;

	public string ServerIP = "127.0.0.1";
	public int ServerPort = 9933;
	public string ZoneName = "DevZone";
	public string UserName = "";
	public string RoomName = "001";

	SmartFox sfs;

	void Start () {
	
		sfs = new SmartFox();
		sfs.ThreadSafeMode = true;

		sfs.AddEventListener(SFSEvent.CONNECTION, OnConnection);
		sfs.AddEventListener(SFSEvent.LOGIN, OnLogin);
		sfs.AddEventListener(SFSEvent.LOGIN_ERROR, OnLoginError);
		sfs.AddEventListener(SFSEvent.CONFIG_LOAD_SUCCESS, OnConfigLoad);
		sfs.AddEventListener(SFSEvent.CONFIG_LOAD_FAILURE, OnConfigFail);
		sfs.AddEventListener(SFSEvent.ROOM_JOIN, OnJoinRoom);
		sfs.AddEventListener(SFSEvent.ROOM_JOIN_ERROR, OnJoinRoomError);
		sfs.AddEventListener(SFSEvent.PUBLIC_MESSAGE, OnPublicMessage);
		
		if(UseConfigFile){
			sfs.LoadConfig(Application.dataPath + "/" + ConfigFile);
		} else {
			sfs.Connect(ServerIP, ServerPort);
		}


	}

	void OnConfigLoad(BaseEvent e){
		Debug.Log("Config File Loaded");
		sfs.Connect(sfs.Config.Host, sfs.Config.Port);
	}

	void OnConfigFail(BaseEvent e){
		Debug.Log ("Failed to load Config File");
	}

	void OnLogin(BaseEvent e){
		Debug.Log ("Logged In: " + e.Params["user"]);
		sfs.Send(new JoinRoomRequest(RoomName));
	}

	void OnJoinRoom(BaseEvent e){
		Debug.Log("Joined Room: " + e.Params["room"]);
		sfs.Send(new PublicMessageRequest("Hello World"));
	}

	void OnPublicMessage(BaseEvent e){
		Room room = (Room)e.Params["room"];
		User sender = (User)e.Params["sender"];
		Debug.Log("[" + room.Name + "] " + sender.Name + ": " + e.Params["message"]);
	}


	void OnJoinRoomError(BaseEvent e){
		Debug.Log("JoinRoom Error(" + e.Params["errorCode"] + "):" + e.Params["errorMessage"]);
	}

	void OnLoginError(BaseEvent e){
		Debug.Log("Login error (" + e.Params["errorCode"] + "):" + e.Params["errorMessage"]);
	}


	
	void OnConnection(BaseEvent e){
		if((bool)e.Params["success"]){
			Debug.Log("Successfully Connected");
			if(UseConfigFile) ZoneName = sfs.Config.Zone;
			sfs.Send(new LoginRequest(UserName, "", ZoneName));

		} else{
			Debug.Log("Connection Failed");
		}
	}

	void Update () {
	
		sfs.ProcessEvents();

	}

	void OnApplicationQuit(){
		if (sfs.IsConnected){
			sfs.Disconnect();
		}
	}
}
