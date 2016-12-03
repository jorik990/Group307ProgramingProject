using UnityEngine;
using System.Collections;

public class keepTrack : MonoBehaviour
{

    public bool greenPlayerWins;
    public bool redPlayerWins;
    public bool bluePlayerWins;
    public bool yellowPlayerWins;

    double[,] greenHome = { { -2.89, 3.63 }, { -2.09, 2.83 }, { -2.86, 2.06 }, { -3.7, 2.83 }, };
    double[,] redHome = { { 2.02, 2.83 }, { 2.79, 3.63 }, { 3.59, 2.86 }, { 2.79, 2.06 }, };
    double[,] blueHome = { { 2.79, -2.09 }, { 3.59, -2.93 }, { 2.82, -3.63 }, { 2.02, -2.86 }, };
    double[,] yellowHome = { { -2.9, -3.63 }, { -3.64, -2.83 }, { -2.87, -2.09 }, { -2.13, -2.89 }, };

    double[,] greenPath = { { -3.13, -0.01 }, { -2.43, -0.01 }, { -1.7, -0.01 }, { -0.96, -0.01 },/*!*/ { -0.05, 0.02 }, };
    double[,] redPath = { { -0.05, 3.1 }, { -0.05, 2.36 }, { -0.05, 1.62 }, { -0.05, 0.92 },/*!*/ { -0.05, 0.02 }, };
    double[,] bluePath = { { 3.06, 0.01 }, { 2.32, 0.01 }, { 1.58, 0.01 }, { 0.88, 0.01 },/*!*/ { -0.05, 0.02 }, };
    double[,] yellowPath = { { -0.02, -3.12 }, { -0.02, -2.35 }, { -0.02, -1.68 }, { -0.02, -0.91 },/*!*/ { -0.05, 0.02 }, };

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
    void Start()
    {


        greenPlayersPawns[0].transform.position = (new Vector3((float)greenHome[0, 0], (float)greenHome[0, 1], 0));
        greenPlayersPawns[1].transform.position = (new Vector3((float)greenHome[1, 0], (float)greenHome[1, 1], 0));
        greenPlayersPawns[2].transform.position = (new Vector3((float)greenHome[2, 0], (float)greenHome[2, 1], 0));
        greenPlayersPawns[3].transform.position = (new Vector3((float)greenHome[3, 0], (float)greenHome[3, 1], 0));

        redPlayersPawns[0].transform.position = (new Vector3((float)redHome[0, 0], (float)redHome[0, 1], 0));
        redPlayersPawns[1].transform.position = (new Vector3((float)redHome[1, 0], (float)redHome[1, 1], 0));
        redPlayersPawns[2].transform.position = (new Vector3((float)redHome[2, 0], (float)redHome[2, 1], 0));
        redPlayersPawns[3].transform.position = (new Vector3((float)redHome[3, 0], (float)redHome[3, 1], 0));

        bluePlayersPawns[0].transform.position = (new Vector3((float)blueHome[0, 0], (float)blueHome[0, 1], 0));
        bluePlayersPawns[1].transform.position = (new Vector3((float)blueHome[1, 0], (float)blueHome[1, 1], 0));
        bluePlayersPawns[2].transform.position = (new Vector3((float)blueHome[2, 0], (float)blueHome[2, 1], 0));
        bluePlayersPawns[3].transform.position = (new Vector3((float)blueHome[3, 0], (float)blueHome[3, 1], 0));

        yellowPlayersPawns[0].transform.position = (new Vector3((float)yellowHome[0, 0], (float)yellowHome[0, 1], 0));
        yellowPlayersPawns[1].transform.position = (new Vector3((float)yellowHome[1, 0], (float)yellowHome[1, 1], 0));
        yellowPlayersPawns[2].transform.position = (new Vector3((float)yellowHome[2, 0], (float)yellowHome[2, 1], 0));
        yellowPlayersPawns[3].transform.position = (new Vector3((float)yellowHome[3, 0], (float)yellowHome[3, 1], 0));
    }

    void Update()
    {
        // playerWins();
    }

    public bool IsThereAnActivePawn()
    {
        bool result = false;
        if (UnityClient.currentPlayer == 1)
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
        if (UnityClient.currentPlayer == 1)
        {
            for (int i = 0; i < greenPlayersPawns.Length; i++)
            {
                if (greenPlayersPawns[i].GetComponent<pawn>().isPawnActive == false && !greenPlayersPawns[i].GetComponent<pawn>().isHome)
                {
                    greenPlayersPawns[i].GetComponent<pawn>().setRealPos(0);
                    greenPlayersPawns[i].transform.position = (new Vector3((float)BoardCoordinants[0, 0], (float)BoardCoordinants[0, 1], 0));
                    greenPlayersPawns[i].GetComponent<pawn>().isPawnActive = true;
                    MovePawn(greenPlayersPawns[i], 0);
                    break;
                }

            }
        }
        else if (UnityClient.currentPlayer == 2)
        {
            for (int i = 0; i < redPlayersPawns.Length; i++)
            {
                if (redPlayersPawns[i].GetComponent<pawn>().isPawnActive == false && !redPlayersPawns[i].GetComponent<pawn>().isHome)
                {
                    redPlayersPawns[i].GetComponent<pawn>().setRealPos(0);
                    redPlayersPawns[i].transform.position = (new Vector3((float)BoardCoordinants[10, 0], (float)BoardCoordinants[10, 1], 0));
                    redPlayersPawns[i].GetComponent<pawn>().isPawnActive = true;
                    MovePawn(redPlayersPawns[i], 0);
                    break;
                }

            }
        }
        else if (UnityClient.currentPlayer == 3)
        {
            for (int i = 0; i < bluePlayersPawns.Length; i++)
            {
                if (bluePlayersPawns[i].GetComponent<pawn>().isPawnActive == false && !bluePlayersPawns[i].GetComponent<pawn>().isHome)
                {
                    bluePlayersPawns[i].GetComponent<pawn>().setRealPos(0);
                    bluePlayersPawns[i].transform.position = (new Vector3((float)BoardCoordinants[20, 0], (float)BoardCoordinants[20, 1], 0));
                    bluePlayersPawns[i].GetComponent<pawn>().isPawnActive = true;
                    MovePawn(bluePlayersPawns[i], 0);
                    break;
                }

            }
        }
        else if (UnityClient.currentPlayer == 4)
        {
            for (int i = 0; i < yellowPlayersPawns.Length; i++)
            {
                if (yellowPlayersPawns[i].GetComponent<pawn>().isPawnActive == false && !yellowPlayersPawns[i].GetComponent<pawn>().isHome)
                {
                    yellowPlayersPawns[i].GetComponent<pawn>().setRealPos(0);
                    yellowPlayersPawns[i].transform.position = (new Vector3((float)BoardCoordinants[30, 0], (float)BoardCoordinants[30, 1], 0));
                    yellowPlayersPawns[i].GetComponent<pawn>().isPawnActive = true;
                    MovePawn(yellowPlayersPawns[i], 0);
                    break;
                }

            }
        }


    }

    public int getPawnPos(int player, int number)
    {
        int posOfPawn = 0;
        if (player == 1)
        {
            posOfPawn = greenPlayersPawns[number].GetComponent<pawn>().getRealPos();
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
            if (greenPlayersPawns[i].GetComponent<pawn>().getRealPos() == 70)
                greenPlayersPawns[i].transform.position = (new Vector3((float)greenHome[i, 0], (float)greenHome[i, 1], 0));
            else if (greenPlayersPawns[i].GetComponent<pawn>().getRealPos() >= 40)
                greenPlayersPawns[i].transform.position = new Vector3((float)greenPath[(greenPlayersPawns[i].GetComponent<pawn>().getRealPos() - 40) % 5, 0], (float)greenPath[(greenPlayersPawns[i].GetComponent<pawn>().getRealPos() - 40) % 5, 1], 0);

            else
                greenPlayersPawns[i].transform.position = new Vector3((float)BoardCoordinants[(greenPlayersPawns[i].GetComponent<pawn>().Position) % 40, 0], (float)BoardCoordinants[(greenPlayersPawns[i].GetComponent<pawn>().Position) % 40, 1], 0);
        }
        for (int i = 0; i < bluePlayersPawns.Length; i++)
        {
            bluePlayersPawns[i].GetComponent<pawn>().setRealPos(UnityClient.player3PawnPos[i]);
            if (bluePlayersPawns[i].GetComponent<pawn>().getRealPos() == 70)
                bluePlayersPawns[i].transform.position = (new Vector3((float)blueHome[i, 0], (float)blueHome[i, 1], 0));
            else if (bluePlayersPawns[i].GetComponent<pawn>().getRealPos() >= 40)
                bluePlayersPawns[i].transform.position = new Vector3((float)bluePath[(bluePlayersPawns[i].GetComponent<pawn>().getRealPos() - 40) % 5, 0], (float)bluePath[(bluePlayersPawns[i].GetComponent<pawn>().getRealPos() - 40) % 5, 1], 0);
            else
                bluePlayersPawns[i].transform.position = new Vector3((float)BoardCoordinants[(bluePlayersPawns[i].GetComponent<pawn>().Position) % 40, 0], (float)BoardCoordinants[(bluePlayersPawns[i].GetComponent<pawn>().Position) % 40, 1], 0);
        }
        for (int i = 0; i < redPlayersPawns.Length; i++)
        {
            redPlayersPawns[i].GetComponent<pawn>().setRealPos(UnityClient.player2PawnPos[i]);
            if (redPlayersPawns[i].GetComponent<pawn>().getRealPos() == 70)
                redPlayersPawns[i].transform.position = (new Vector3((float)redHome[i, 0], (float)redHome[i, 1], 0));
            else if (redPlayersPawns[i].GetComponent<pawn>().getRealPos() >= 40)
                redPlayersPawns[i].transform.position = new Vector3((float)redPath[(redPlayersPawns[i].GetComponent<pawn>().getRealPos() - 40) % 5, 0], (float)redPath[(redPlayersPawns[i].GetComponent<pawn>().getRealPos() - 40) % 5, 1], 0);
            else
                redPlayersPawns[i].transform.position = new Vector3((float)BoardCoordinants[(redPlayersPawns[i].GetComponent<pawn>().Position) % 40, 0], (float)BoardCoordinants[(redPlayersPawns[i].GetComponent<pawn>().Position) % 40, 1], 0);
        }
        for (int i = 0; i < yellowPlayersPawns.Length; i++)
        {
            yellowPlayersPawns[i].GetComponent<pawn>().setRealPos(UnityClient.player4PawnPos[i]);
            if (yellowPlayersPawns[i].GetComponent<pawn>().getRealPos() == 70)
                yellowPlayersPawns[i].transform.position = (new Vector3((float)yellowHome[i, 0], (float)yellowHome[i, 1], 0));
            else if (yellowPlayersPawns[i].GetComponent<pawn>().getRealPos() >= 40)
                yellowPlayersPawns[i].transform.position = new Vector3((float)yellowPath[(yellowPlayersPawns[i].GetComponent<pawn>().getRealPos() - 40) % 5, 0], (float)yellowPath[(redPlayersPawns[i].GetComponent<pawn>().getRealPos() - 40) % 5, 1], 0);
            else
                yellowPlayersPawns[i].transform.position = new Vector3((float)BoardCoordinants[(yellowPlayersPawns[i].GetComponent<pawn>().Position) % 40, 0], (float)BoardCoordinants[(yellowPlayersPawns[i].GetComponent<pawn>().Position) % 40, 1], 0);
        }

    }


    public void MovePawn(GameObject pawn, int move)
    {



        pawn.GetComponent<pawn>().addToPos(move);
        //Debug.Log(pawn.GetComponent<pawn>().Position % 40);
        if (pawn.GetComponent<pawn>().getRealPos() >= 40)
        {
            if (TurnManager.thisPlayer == 1)
                pawn.transform.position = new Vector3((float)greenPath[(pawn.GetComponent<pawn>().getRealPos() - 40) % 5, 0], (float)greenPath[(pawn.GetComponent<pawn>().getRealPos() - 40) % 5, 1], 0);
            else if (TurnManager.thisPlayer == 2)
                pawn.transform.position = new Vector3((float)redPath[(pawn.GetComponent<pawn>().getRealPos() - 40) % 5, 0], (float)redPath[(pawn.GetComponent<pawn>().getRealPos() - 40) % 5, 1], 0);
            else if (TurnManager.thisPlayer == 3)
                pawn.transform.position = new Vector3((float)bluePath[(pawn.GetComponent<pawn>().getRealPos() - 40) % 5, 0], (float)bluePath[(pawn.GetComponent<pawn>().getRealPos() - 40) % 5, 1], 0);
            else if (TurnManager.thisPlayer == 4)
                pawn.transform.position = new Vector3((float)yellowPath[(pawn.GetComponent<pawn>().getRealPos() - 40) % 5, 0], (float)yellowPath[(pawn.GetComponent<pawn>().getRealPos() - 40) % 5, 1], 0);

            if ((pawn.GetComponent<pawn>().getRealPos() - 40) % 5 == 4)
            {
                pawn.GetComponent<pawn>().isHome = true;
                pawn.GetComponent<pawn>().isHome = false;

            }
        }
        else {
            for (int i = 0; i < greenPlayersPawns.Length; i++)
            {
                if (pawn.GetComponent<pawn>().Position % 40 == greenPlayersPawns[i].GetComponent<pawn>().Position % 40 && TurnManager.thisPlayer != 1)
                {
                    greenPlayersPawns[i].GetComponent<pawn>().setRealPos(70);
                    greenPlayersPawns[i].GetComponent<pawn>().isPawnActive = false;
                }

            }
            for (int i = 0; i < redPlayersPawns.Length; i++)
            {
                if (pawn.GetComponent<pawn>().Position % 40 == redPlayersPawns[i].GetComponent<pawn>().Position % 40 && TurnManager.thisPlayer != 2)
                {
                    redPlayersPawns[i].GetComponent<pawn>().setRealPos(70);
                    redPlayersPawns[i].GetComponent<pawn>().isPawnActive = false;
                }

            }
            for (int i = 0; i < bluePlayersPawns.Length; i++)
            {
                if (pawn.GetComponent<pawn>().Position % 40 == bluePlayersPawns[i].GetComponent<pawn>().Position % 40 && TurnManager.thisPlayer != 3)
                {
                    bluePlayersPawns[i].GetComponent<pawn>().setRealPos(70);
                    bluePlayersPawns[i].GetComponent<pawn>().isPawnActive = false;
                }

            }
            for (int i = 0; i < yellowPlayersPawns.Length; i++)
            {
                if (pawn.GetComponent<pawn>().Position % 40 == yellowPlayersPawns[i].GetComponent<pawn>().Position % 40 && TurnManager.thisPlayer != 4)
                {
                    yellowPlayersPawns[i].GetComponent<pawn>().setRealPos(70);
                    yellowPlayersPawns[i].GetComponent<pawn>().isPawnActive = false;
                }

            }


            pawn.transform.position = new Vector3((float)BoardCoordinants[(pawn.GetComponent<pawn>().Position) % 40, 0], (float)BoardCoordinants[(pawn.GetComponent<pawn>().Position) % 40, 1], 0);

        }
    }
    public void playerWins()
    {
        if (UnityClient.currentPlayer == 1)
        {
            int temp = 0;
            for (int i = 0; i < greenPlayersPawns.Length; i++)
            {

                if (greenPlayersPawns[i].transform.position == new Vector3((float)greenPath[4, 0], (float)greenPath[4, 1], 0))
                {
                    temp++;

                }

            }

            if (temp == 4)
                greenPlayerWins = true;


            //Debug.Log("Green player have "+temp+"pawns in");

        }

        if (UnityClient.currentPlayer == 2)
        {
            int temp = 0;
            for (int i = 0; i < redPlayersPawns.Length; i++)
            {

                if (redPlayersPawns[i].transform.position == new Vector3((float)redPath[4, 0], (float)redPath[4, 1], 0))
                {
                    temp++;

                }

            }

            if (temp == 4)
                redPlayerWins = true;
        }

        if (UnityClient.currentPlayer == 3)
        {
            int temp = 0;
            for (int i = 0; i < bluePlayersPawns.Length; i++)
            {

                if (bluePlayersPawns[i].transform.position == new Vector3((float)bluePath[4, 0], (float)bluePath[4, 1], 0))
                {
                    temp++;

                }

            }

            if (temp == 4)
                bluePlayerWins = true;
        }

        if (UnityClient.currentPlayer == 4)
        {
            int temp = 0;
            for (int i = 0; i < yellowPlayersPawns.Length; i++)
            {

                if (yellowPlayersPawns[i].transform.position == new Vector3((float)yellowPath[4, 0], (float)yellowPath[4, 1], 0))
                {
                    temp++;

                }

            }

            if (temp == 4)
                yellowPlayerWins = true;
        }
    }

}
