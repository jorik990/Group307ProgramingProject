using UnityEngine;
using System.Collections;

public class pawn : MonoBehaviour {

    public int number;

    public bool isPawnActive = false;
    int position = 70;
    public int Position
    {
        get {
            if (player == 1)
                return position;
            else if (player == 2)
                return position + 10;
            else if (player == 3)
                return position + 20;
            else if (player == 4)
                return position + 30;
            else
                return 0;

        }
        
    }
    public int player;
    
    public void addToPos(int increment)
    {
        position += increment;
    }

    public int getRealPos()
    {
        return position;
    }
    public void setRealPos(int newpos)
    {
        position = newpos;
    }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
