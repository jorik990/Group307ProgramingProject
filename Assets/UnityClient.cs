using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Net;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class UnityClient : MonoBehaviour {
    Server server;
    Client client;
    string[] shardData = new string[18];
    public string sharedDataString;
    public static int numberOfPlayers;
    public static int currentPlayer;
    public static int[] player1PawnPos = new int[4];
    public static int[] player2PawnPos = new int[4];
    public static int[] player3PawnPos = new int[4];
    public static int[] player4PawnPos = new int[4];
    public static string gameStarted;

    float timepassed = 0;


    TurnManager turnManager = null;




    public Text textGui;
    public static bool isHost = false;

    public Scene Lobby;

    string ip= "localHost";


    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void Host()
    {
        isHost = true;
        SceneManager.LoadScene("Lobby");
        server = new Server();

        Debug.Log("starting server");
       
        server.StartServer("1,1," + "0,0,0,0," + "0,0,0,0," + "0,0,0,0," + "0,0,0,0"+",0");

        
    }

   

   public void join()
    {
        ip = textGui.text;
        client = new Client(ip);
        Debug.Log("starting client");
        client.StartClient();
        Debug.Log("client started");

       
    }

	// Use this for initialization
	void Start () {
        Debug.Log(ip);
    }


	
	// Update is called once per frame
	void Update () {
     

        timepassed += Time.deltaTime;
        if(timepassed >= 1)
        {
            Debug.Log("i am player "+TurnManager.thisPlayer);
            

            if ( turnManager != null)
            {
                UpdateSharedInfo();
                Debug.Log("updating");
                if (turnManager != null && currentPlayer == TurnManager.thisPlayer && TurnManager.turnInProgress == false)
                    turnManager.newTurn();

            }
            timepassed = 0;
        }


        if(SceneManager.GetActiveScene().name == "gameScene" && turnManager == null)
            turnManager = (TurnManager)GameObject.FindObjectOfType<TurnManager>();

        if (client != null && client.dataGottenFromServer != "" &&  SceneManager.GetActiveScene().name == "HostJoin")
            SceneManager.LoadScene("Lobby");

        if (client != null && gameStarted == "1" && SceneManager.GetActiveScene().name == "Lobby")
         SceneManager.LoadScene("Working Game Scene");


        /*
        if (currentPlayer == TurnManager.thisPlayer && client != null && client.writeToserver == false)
        {
            Debug.Log("you are now writing to server");

            client.writeToserver = true;

        }

        
        if (client != null && currentPlayer != TurnManager.thisPlayer && client.writeToserver == true)
        {
            Debug.Log("you are now reading from server");
            client.writeToserver = false;

        }
        
        if (server != null && currentPlayer == TurnManager.thisPlayer && server.writeToclients == false)
        {
            Debug.Log("you are now writeing to the clients");
            server.writeToclients = true;
        }

        if (server != null && currentPlayer != TurnManager.thisPlayer && server.writeToclients == true)
        {
            Debug.Log("you are now reading from the clients");
            server.writeToclients = false;
        }
        */



    }



    public void UpdateSharedInfo()
    {
        getDataFromServerOrClient();

        Debug.Log(sharedDataString);

        shardData = sharedDataString.Split(","[0]);
    

        numberOfPlayers = int.Parse(shardData[0]);
        
        currentPlayer = int.Parse(shardData[1]);
        player1PawnPos[0] = int.Parse(shardData[2]);
        player1PawnPos[1] = int.Parse(shardData[3]);
        player1PawnPos[2] = int.Parse(shardData[4]);
        player1PawnPos[3] = int.Parse(shardData[5]);
        player2PawnPos[0] = int.Parse(shardData[6]);
        player2PawnPos[1] = int.Parse(shardData[7]);
        player2PawnPos[2] = int.Parse(shardData[8]);
        player2PawnPos[3] = int.Parse(shardData[9]);
        player3PawnPos[0] = int.Parse(shardData[10]);
        player3PawnPos[1] = int.Parse(shardData[11]);
        player3PawnPos[2] = int.Parse(shardData[12]);
        player3PawnPos[3] = int.Parse(shardData[13]);
        player4PawnPos[0] = int.Parse(shardData[14]);
        player4PawnPos[1] = int.Parse(shardData[15]);
        player4PawnPos[2] = int.Parse(shardData[16]);
        player4PawnPos[3] = int.Parse(shardData[17]);

        gameStarted = shardData[18];


    }

    public void getDataFromServerOrClient()
    {
        if (isHost)
        {
           sharedDataString = server.storedData;
        }
        else 
        {
            sharedDataString = client.dataGottenFromServer;
        }

    }

    public void StartGame()
    {
        shardData[18] = "1";
        sharedDataString = "";
        for (int i = 0; i < shardData.Length; i++)
        {
            if (i == shardData.Length - 1)
                sharedDataString += shardData[i];
            else
                sharedDataString += shardData[i] + ",";
        }

        server.updateData(sharedDataString);
    }

    public void nextPlayerAndUpdate()
    {
        UpdateSharedInfo();
        int temp = currentPlayer;
        temp++;
      
        if (temp > numberOfPlayers)
            temp = 1;
        Debug.Log("there is " + numberOfPlayers + " in the game so the turn is set to" + temp);

        shardData[1] = temp + "";

        sharedDataString = "";
        for (int i = 0; i < shardData.Length; i++)
        {
            if (i == shardData.Length - 1)
                sharedDataString += shardData[i];
            else
                sharedDataString += shardData[i] + ",";
        }

        if (isHost)
        {
            server.updateData(sharedDataString);
        }
        else
        {
            client.updateData(sharedDataString);
        }
        
        
        
    }
    

}
