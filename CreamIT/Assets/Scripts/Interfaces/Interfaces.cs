using UnityEngine;
using System.Collections;
public interface IMoveDot
{
    float speed { set; }//The speed of each dot
    IEnumerator Move();//Called on Start() //Move will control a NavMeshAgent and move it down screen

    void Stop();//Scribbed to Action StopGame when the game ends // Stops the Move Coroutine; 
    void Start(); //Calls SetColor //Changes speed based static speed and Random.Range()

    void SetAsHit(Color _color);//Tests if  Collider _dot color is = to this.color //Changes Color.alpha to full 
    //StartCoroutine(DeactivateTrigger());

    //Detects collision with a dot color draged on from user
    void OnTriggerEnter(Collider _dot);//Get color of the _dot's Dot Class run SetAsHit(Pass _dot color)

    IEnumerator DeactivateTrigger();//Will turn of Collider after a short period of time
    void OnMouseEnter(); //Activates the Collider for a shortTime 

}

public interface ISetColor
{
    //Add a Color dotColor field
    void OnChangeColor(); //listens for powerUp Action
    void OnSetColor();//Sets the Color at Start() based on an Enum of colors
    //Parses the Enum to a color type //  Enum.Parse(typeof(Colors), colorName)) (Never Used and will test)
    //listens for powerUp Action to change the color;
}

public interface ISelectDot
{
    void OnMouseUp(); //Activacts Collider;
    //I don't know how to move a dot yet
}
