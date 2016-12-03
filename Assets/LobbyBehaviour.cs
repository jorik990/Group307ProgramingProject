using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyBehaviour : MonoBehaviour {
    public Text player1, player2, player3, player4;
    bool ishost;
    float passedTime = 0;
    public GameObject button;

    public static bool turnInProgress = false;

    UnityClient multiplayerInfo;

	// Use this for initialization
	void Start () {
       

        multiplayerInfo = (UnityClient) GameObject.FindObjectOfType<UnityClient>();


        ishost = UnityClient.isHost;
        if (ishost) 
            TurnManager.thisPlayer = 1;
        else
        {
            button.SetActive(false);
            multiplayerInfo.UpdateSharedInfo();
            TurnManager.thisPlayer = UnityClient.numberOfPlayers;
        }

        Debug.Log(ishost);
	}
	
	// Update is called once per frame
	void Update () {

        passedTime += Time.deltaTime;




        passedTime += Time.deltaTime;

        if (passedTime > 1)
        {

            updatePlayers();
            passedTime = 0;
        } 

	}

   public void startThegame()
    {
        multiplayerInfo.StartGame();
        //SceneManager.LoadScene("gameScene");
       
    }

    void updatePlayers()
    {

        Debug.Log("updating players");
        int numberOfPlayers = 0;
        multiplayerInfo.UpdateSharedInfo();
        numberOfPlayers = UnityClient.numberOfPlayers;


        if (UnityClient.gameStarted == "1" && SceneManager.GetActiveScene().name == "Lobby")
        {
            
            SceneManager.LoadScene("gameScene");

        }

        if (numberOfPlayers > 0)
            player1.text = "Green Player";
        else
            player1.text = "";
        if (numberOfPlayers > 1)
            player2.text = "Red Player";
        else
            player2.text = "";
        if (numberOfPlayers > 2)
            player3.text = "Blue Player";
        else
            player3.text = "";
        if (numberOfPlayers > 3)
            player4.text = "Yellow Player";
        else
            player4.text = "";
    }
}
