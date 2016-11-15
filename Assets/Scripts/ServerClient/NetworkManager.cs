using UnityEngine;
using System.Collections;
using System;

public class NetworkManager : MonoBehaviour
{
    //public string IP = "127.30.0.19";
    public int port = 25001;

    public GameObject cubeChange;

    public bool hideFlag = false;

    public float connectTimer = 0.0f;
    public int attempts = 0;

    bool serverStarted;

    CallViz viz;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        serverStarted = false;
    }

    // Use this for initialization
    public void Connect()
    {
        connectTimer = 2.0f;
        attempts = 0;
        //IP = "172.30.0.19";
        //port = 51202;
        hideFlag = false;
        if(PlayerPrefs.GetString("isServer") == "true")
            Network.InitializeServer(32, port, !Network.HavePublicAddress());
        else
            Network.Connect(PlayerPrefs.GetString("IP"), port);

    }

    // Update is called once per frame
    void Update()
    {
        if(serverStarted)
        {
            if(connectTimer > 0)
                connectTimer -= Time.deltaTime;
            else
            {
                if(Network.peerType == NetworkPeerType.Disconnected)
                {
                    if(PlayerPrefs.GetString("isServer") == "true")
                        Network.InitializeServer(32, port, !Network.HavePublicAddress());
                    else
                        Network.Connect(PlayerPrefs.GetString("IP"), port);
                }
                connectTimer = 2.0f;
                attempts++;
            }

            if(Input.GetKey(KeyCode.A))
            {
                GetComponent<NetworkView>().RPC("PlayNote", RPCMode.Server, "note");
            }
            //
            //if(Input.GetKey(KeyCode.B))
            //{
            //    GetComponent<NetworkView>().RPC("AskSound", RPCMode.Server);
            //}
            //
            //if(Input.GetKey(KeyCode.C))
            //{
            //    GetComponent<NetworkView>().RPC("PlaySound", RPCMode.Server, "test");
            //}
        }


    }

    void OnServerInitialized()
    {
        Debug.Log("Server Initialized");
        serverStarted = true;
    }

    public void SyncBeat()
    {
        if(Network.isServer)
        {
            var beatCounter = GameObject.Find("BeatCounter").GetComponent<BeatCounter>();
            GetComponent<NetworkView>().RPC("SyncBeatClient", RPCMode.All, beatCounter.BeatCount, beatCounter.BeatsPerBar, beatCounter.BeatsPerMinute, (float)beatCounter.BeatProgress);
        }
    }

    [RPC]
    private void SyncBeatClient(int beatCount, int beatsPerBar, int beatsPerMinute, float beatProgress)
    {
        if(Network.isClient)
        {
            var beatCounter = GameObject.Find("BeatCounter").GetComponent<BeatCounter>();
            beatCounter.BeatCount = beatCount;
            beatCounter.BeatsPerBar = beatsPerBar;
            beatCounter.BeatsPerMinute = beatsPerMinute;
            beatCounter.LastBeatTime = Time.time - beatProgress * TimeSpan.FromMinutes(1.0 / beatCounter.BeatsPerMinute).TotalSeconds;
            beatCounter.NextBeatTime = beatCounter.LastBeatTime + TimeSpan.FromMinutes(1.0 / beatCounter.BeatsPerMinute).TotalSeconds;
        }
    }

    [RPC]
    public void Test()
    {
        Debug.Log("hey");
    }

    public void PlayNote(Message message)
    {
        GetComponent<NetworkView>().RPC("PlayNoteServer", RPCMode.All, message.ToString());
    }

    [RPC]
    private void PlayNoteServer(string message)
    {
        if(Network.isServer)
        {
            Band band = GameObject.Find("Band").GetComponent<Band>();
            CallViz viz = GameObject.Find("viz").GetComponent<CallViz>();
            if(band != null)
            {
                viz.AddNote(Message.FromString(message));
                band.AddMessage(message);
            }
        }
    }





    //[RPC]
    //void AskColor()
    //{
    //    if(Network.isServer)
    //    {
    //        GetComponent<NetworkView>().RPC("ChangeColor", RPCMode.All);
    //    }
    //}
    //
    //[RPC]
    //void ChangeColor()
    //{
    //    cubeChange.GetComponent<Renderer>().material.color = Color.green;
    //}
    //
    //[RPC]
    //void AskSound()
    //{
    //    if(Network.isServer)
    //    {
    //        GetComponent<AudioSource>().Play();
    //    }
    //}
    //[RPC]
    //void PlaySound(string info)
    //{
    //    if(Network.isServer)
    //    {
    //        //var m = Message.FromString (info);	
    //        // drum|100|109
    //        if(info == "test")
    //        {
    //            //GetComponent<AudioSource> ().Play ();
    //
    //        }
    //    }
    //}
}
