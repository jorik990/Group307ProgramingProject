using UnityEngine;
using System.Collections;

public class keepTrack : MonoBehaviour {

    double[,] green = { { -2.89, 3.63 }, { -2.09, 2.83 }, { -2.86, 2.06 }, { -3.7, 2.83 }, { -3.13, -0.01 }, { -2.43, -0.01 }, { -1.7, -0.01 }, { -0.96, -0.01 }, { -0.05, 0.02 }, };
    double[,] red = { { 2.02, 2.83 }, { 2.79, 3.63 }, { 3.59, 2.86 }, { 2.79, 2.06 }, { -0.05, 3.1 }, { -0.05, 2.36 }, { -0.05, 1.62 }, { -0.05, 0.92 }, { -0.05, 0.02 }, };
    double[,] blue = { { 2.79, -2.09 }, { 3.59, -2.93 }, { 2.82, -3.63 }, { 2.02, -2.86 }, { 3.06, 0.01 }, { 2.32, 0.01 }, { 1.58, 0.01 }, { 0.88, 0.01 }, { -0.05, 0.02 }, };
    double[,] yellow = { { -2.9, -3.63 }, { -3.64, -2.83 }, { -2.87, -2.09 }, { -2.13, -2.89 }, { -0.02, -3.12 }, { -0.02, -2.35 }, { -0.02, -1.68 }, { -0.02, -0.91 }, { -0.05, 0.02 }, };

    double[,] BoardCoordinants = { 
        {-4.05,0.8},
        {-3.24,0.8},
        {-2.44,0.8},
        {-1.66,0.8},
        {-0.85,0.8},
        {-0.85,1.63},
        {-0.85,2.43},
        {-0.85,3.23},
        {-0.85,3.9},
        {-0.02,4},
        {0.75,4.03},
        {0.75,3.19},
        {0.75,2.42},{0.75,1.58},{0.75,0.81},{1.58,0.81},{2.38,0.81},{3.18,0.81},{3.95,0.81},{3.98,-0.02},
            {3.98,-0.79},{3.14,-0.82},{2.37,-0.85},{1.57,-0.85},{0.73,-0.85},{0.75,-1.62},{0.75,-2.42},{0.75,-3.22},{0.75,-4.02},{-0.01,-4.02},
            {-0.85,-4.02},{-0.85,-3.22},{-0.85,-2.38},{-0.85,-1.58},{-0.85,-0.78},{-1.62,-0.81},{-2.46,-0.81},{-3.26,-0.81},{-4.06,-0.81},{-4.06,-0.01},};

    

    public GameObject[] redPlayersPawns;
    public GameObject[] greenPlayersPawns;
    public GameObject[] yellowPlayersPawns;
    public GameObject[] bluePlayersPawns;

    // Use this for initialization
    void Start () {
        

        greenPlayersPawns[0].transform.position = (new Vector3((float)green[0, 0], (float)green[0, 1], 0));
        greenPlayersPawns[1].transform.position = (new Vector3((float)green[1, 0], (float)green[1, 1], 0));
        greenPlayersPawns[2].transform.position = (new Vector3((float)green[2, 0], (float)green[2, 1], 0));
        greenPlayersPawns[3].transform.position = (new Vector3((float)green[3, 0], (float)green[3, 1], 0));

        redPlayersPawns[0].transform.position =(new Vector3((float)red[0, 0], (float)red[0, 1], 0));
        redPlayersPawns[1].transform.position = (new Vector3((float)red[1, 0], (float)red[1, 1], 0));
        redPlayersPawns[2].transform.position = (new Vector3((float)red[2, 0], (float)red[2, 1], 0));
        redPlayersPawns[3].transform.position = (new Vector3((float)red[3, 0], (float)red[3, 1], 0));

        bluePlayersPawns[0].transform.position = (new Vector3((float)blue[0, 0], (float)blue[0, 1], 0));
        bluePlayersPawns[1].transform.position = (new Vector3((float)blue[1, 0], (float)blue[1, 1], 0));
        bluePlayersPawns[2].transform.position = (new Vector3((float)blue[2, 0], (float)blue[2, 1], 0));
        bluePlayersPawns[3].transform.position = (new Vector3((float)blue[3, 0], (float)blue[3, 1], 0));

        yellowPlayersPawns[0].transform.position = (new Vector3((float)yellow[0, 0], (float)yellow[0, 1], 0));
        yellowPlayersPawns[1].transform.position = (new Vector3((float)yellow[1, 0], (float)yellow[1, 1], 0));
        yellowPlayersPawns[2].transform.position = (new Vector3((float)yellow[2, 0], (float)yellow[2, 1], 0));
        yellowPlayersPawns[3].transform.position = (new Vector3((float)yellow[3, 0], (float)yellow[3, 1], 0));
    }
	
    public bool IsThereAnActivePawn()
    {
        bool result = false;
        if(UnityClient.currentPlayer == 1)
            for (int i = 0; i < greenPlayersPawns.Length; i++)
            {
                if (greenPlayersPawns[i].GetComponent<pawn>().isPawnActive == true)
                    result = true;
                break;
            }
        else if (UnityClient.currentPlayer == 2)
            for (int i = 0; i < redPlayersPawns.Length; i++)
            {
                if (redPlayersPawns[i].GetComponent<pawn>().isPawnActive == true)
                    result = true;
                break;
            }
        else if (UnityClient.currentPlayer == 3)
            for (int i = 0; i < bluePlayersPawns.Length; i++)
            {
                if (bluePlayersPawns[i].GetComponent<pawn>().isPawnActive == true)
                    result = true;
                break;
            }
        else if (UnityClient.currentPlayer == 4)
            for (int i = 0; i < yellowPlayersPawns.Length; i++)
            {
                if (yellowPlayersPawns[i].GetComponent<pawn>().isPawnActive == true)
                    result = true;
                break;
            }


        return result;

    }



    public void ReleasePawn()
    {
        Debug.Log("Releasing Pawn");
       if( UnityClient.currentPlayer == 1)
        {
            for (int i = 0; i < greenPlayersPawns.Length; i++)
            {
                if (greenPlayersPawns[i].GetComponent<pawn>().isPawnActive == false)
                {
                    greenPlayersPawns[i].GetComponent<pawn>().setRealPos(0);
                    greenPlayersPawns[i].transform.position =( new Vector3((float)BoardCoordinants[0, 0], (float)BoardCoordinants[0, 1], 0));
                    greenPlayersPawns[i].GetComponent<pawn>().isPawnActive = true;
                    break;
                }
                   
            }
        }
        else if (UnityClient.currentPlayer == 2)
        {
            for (int i = 0; i < redPlayersPawns.Length; i++)
            {
                if (redPlayersPawns[i].GetComponent<pawn>().isPawnActive == false)
                {
                    redPlayersPawns[i].GetComponent<pawn>().setRealPos(0);
                    redPlayersPawns[i].transform.position = (new Vector3((float)BoardCoordinants[10, 0], (float)BoardCoordinants[10, 1], 0));
                    redPlayersPawns[i].GetComponent<pawn>().isPawnActive = true;
                    break;
                }

            }
        }
        else if (UnityClient.currentPlayer == 3)
        {
            for (int i = 0; i < bluePlayersPawns.Length; i++)
            {
                if (bluePlayersPawns[i].GetComponent<pawn>().isPawnActive == false)
                {
                    bluePlayersPawns[i].GetComponent<pawn>().setRealPos(0);
                    bluePlayersPawns[i].transform.position = (new Vector3((float)BoardCoordinants[20, 0], (float)BoardCoordinants[20, 1], 0));
                    bluePlayersPawns[i].GetComponent<pawn>().isPawnActive = true;
                    break;
                }

            }
        }
        else if (UnityClient.currentPlayer == 4)
        {
            for (int i = 0; i < yellowPlayersPawns.Length; i++)
            {
                if (yellowPlayersPawns[i].GetComponent<pawn>().isPawnActive == false)
                {
                    yellowPlayersPawns[i].GetComponent<pawn>().setRealPos(0);
                    yellowPlayersPawns[i].transform.position = (new Vector3((float)BoardCoordinants[30, 0], (float)BoardCoordinants[30, 1], 0));
                    yellowPlayersPawns[i].GetComponent<pawn>().isPawnActive = true;
                    
                    break;
                }

            }
        }


    }

    public int getPawnPos(int player,int number)
    {
        int posOfPawn=0;
        if(player ==1)
        {
          posOfPawn =  greenPlayersPawns[number].GetComponent<pawn>().getRealPos();
        }
        if (player == 2)
        {
            posOfPawn = redPlayersPawns[number].GetComponent<pawn>().getRealPos();
        }
        if (player == 3)
        {
            posOfPawn = bluePlayersPawns[number].GetComponent<pawn>().getRealPos();
        }
        if (player == 4)
        {
            posOfPawn = yellowPlayersPawns[number].GetComponent<pawn>().getRealPos();
        }
        return posOfPawn;
    }


    public void UpdateAllPawns()
    {
        for (int i = 0; i < greenPlayersPawns.Length; i++)
        {
            greenPlayersPawns[i].GetComponent<pawn>().setRealPos(UnityClient.player1PawnPos[i]);
            if(greenPlayersPawns[i].GetComponent<pawn>().getRealPos() == 70)
                greenPlayersPawns[i].transform.position = (new Vector3((float)green[i, 0], (float)green[i, 1], 0));
            else
            greenPlayersPawns[i].transform.position = new Vector3((float)BoardCoordinants[(greenPlayersPawns[i].GetComponent<pawn>().Position) % 40, 0], (float)BoardCoordinants[(greenPlayersPawns[i].GetComponent<pawn>().Position) % 40, 1], 0);
        }
        for (int i = 0; i < bluePlayersPawns.Length; i++)
        {
            bluePlayersPawns[i].GetComponent<pawn>().setRealPos(UnityClient.player3PawnPos[i]);
            if (bluePlayersPawns[i].GetComponent<pawn>().getRealPos() == 70)
                bluePlayersPawns[i].transform.position = (new Vector3((float)blue[i, 0], (float)blue[i, 1], 0));
            else
                bluePlayersPawns[i].transform.position = new Vector3((float)BoardCoordinants[(bluePlayersPawns[i].GetComponent<pawn>().Position) % 40, 0], (float)BoardCoordinants[(bluePlayersPawns[i].GetComponent<pawn>().Position) % 40, 1], 0);
        }
        for (int i = 0; i < redPlayersPawns.Length; i++)
        {
            redPlayersPawns[i].GetComponent<pawn>().setRealPos(UnityClient.player2PawnPos[i]);
            if (redPlayersPawns[i].GetComponent<pawn>().getRealPos() == 70)
                redPlayersPawns[i].transform.position = (new Vector3((float)red[i, 0], (float)red[i, 1], 0));
            else
                redPlayersPawns[i].transform.position = new Vector3((float)BoardCoordinants[(redPlayersPawns[i].GetComponent<pawn>().Position) % 40, 0], (float)BoardCoordinants[(redPlayersPawns[i].GetComponent<pawn>().Position) % 40, 1], 0);
        }
        for (int i = 0; i < yellowPlayersPawns.Length; i++)
        {
            yellowPlayersPawns[i].GetComponent<pawn>().setRealPos(UnityClient.player4PawnPos[i]);
            if (yellowPlayersPawns[i].GetComponent<pawn>().getRealPos() == 70)
                yellowPlayersPawns[i].transform.position = (new Vector3((float)yellow[i, 0], (float)yellow[i, 1], 0));
            else
                yellowPlayersPawns[i].transform.position = new Vector3((float)BoardCoordinants[(yellowPlayersPawns[i].GetComponent<pawn>().Position) % 40, 0], (float)BoardCoordinants[(yellowPlayersPawns[i].GetComponent<pawn>().Position) % 40, 1], 0);
        }

    }


    public void MovePawn(GameObject pawn, int move)
    {

        

        pawn.GetComponent<pawn>().addToPos(move);
        Debug.Log(pawn.GetComponent<pawn>().Position % 40);

        pawn.transform.position = new Vector3((float)BoardCoordinants[(pawn.GetComponent<pawn>().Position)%40, 0], (float)BoardCoordinants[(pawn.GetComponent<pawn>().Position) % 40, 1], 0);
    }
}
