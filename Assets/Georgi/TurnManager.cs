using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TurnManager : MonoBehaviour {
    public static int thisPlayer=0;

    public GameObject button;
    public Text player;
    public Text action;
    public keepTrack keeptrack;

    public static bool turnInProgress = false;


    UnityClient multiplayerInfo;



    public static GameObject selectedPawn = null;

    bool waitingToSelectPawn = false;

    int diceRolls = 0;

    public  void DiceRolled()
    {

        //Debug.Log("you rolled "+Dice.diceroll);
        diceRolls++;
        
       

        player.text = "Outcome " + Dice.diceroll;
        
            
        
            if (Dice.diceroll != 6)
            {
            if (keeptrack.IsThereAnActivePawn())
            {
                button.SetActive(false);
                action.text = "Choose Pawn to move";
                waitingToSelectPawn = true;
                clickObject.Selectable = true;
                clickObject.excludeInactivePawn = true;

            }
            else if (diceRolls < 3)
                action.text = "Roll Again";
            else
                endTurn();

            }
            else if (keeptrack.IsThereAnActivePawn() == true)
            {
                button.SetActive(false);
                action.text = "move or release a pawn";
            clickObject.Selectable = true;
            waitingToSelectPawn = true;

            }
            else
            {
                action.text = "pawn released";
            releasePawn();
               
            }
                

        

    }

    public void movePawn()
    {
        keeptrack.MovePawn(selectedPawn, (int)Dice.diceroll);
        selectedPawn = null;
        
        waitingToSelectPawn = false;
        clickObject.Selectable = false;
        clickObject.excludeInactivePawn = false;
        button.SetActive(true);

            endTurn();
       


    }

    public void newTurn()
    {
        Debug.Log("new turn dawned");
        turnInProgress = true;
        button.SetActive(true);
        action.text = "Roll Dice";
        keeptrack.UpdateAllPawns();

    }
    public void resetTurn()
    {
        Dice.diceroll = 0;
        


        
        action.text = "player " + UnityClient.currentPlayer + " turn";
        Debug.Log("New players Turn");
        multiplayerInfo.resetTurn();
       
    }

    public void endTurn()
    {
        Dice.diceroll = 0;
        diceRolls = 0;
     
       
        button.SetActive(false);
        action.text = "player " + UnityClient.currentPlayer + " turn";
        Debug.Log("New players Turn");
        multiplayerInfo.nextPlayerAndUpdate();
        turnInProgress = false;
    }

    void releasePawn()
    {
        waitingToSelectPawn = false;
        selectedPawn = null;
        bool temp = keeptrack.IsThereAnActivePawn();
        keeptrack.ReleasePawn();
        

            endTurn();
       

    }

    void doPawnAction()
    {
        if (selectedPawn.GetComponent<pawn>().isPawnActive)
            movePawn();
        else {
            releasePawn();
            clickObject.Selectable = false;
            clickObject.excludeInactivePawn = false;
            button.SetActive(true);
        }
    }

	// Use this for initialization
	void Start () {

        turnInProgress = false;
        Debug.Log("current player"+UnityClient.currentPlayer+" number of players "+UnityClient.numberOfPlayers);
        Debug.Log((UnityClient.currentPlayer+1 % UnityClient.numberOfPlayers));

        multiplayerInfo = (UnityClient)GameObject.FindObjectOfType<UnityClient>();
        button.SetActive(false);
       

    }

    
	
	// Update is called once per frame
	void Update () {

        if (thisPlayer == UnityClient.currentPlayer && !waitingToSelectPawn)
        {


            button.SetActive(true);
            //Debug.Log("made button visible");
        }
        if (thisPlayer != UnityClient.currentPlayer)
        {
            button.SetActive(false);
           // Debug.Log("made button visible");
        }

        if (waitingToSelectPawn && selectedPawn !=null)
        {
            doPawnAction();
        }
      

	}
}
