using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemsDetached : MonoBehaviour {

    Stack<RocketPiece> RocketPieces = new Stack<RocketPiece>();
	// Use this for initialization
	void Start () {

        for (int i = 0; i < 3; i++)
        {
            RocketPieces.Push(transform.GetChild(i).GetComponent<RocketPiece>());
        }

        
	}
	
	

    public void Detach()
    {
        //transform.position += new Vector3(0, Time.deltaTime);
        if ( RocketPieces.Count > 1)
        {
            RocketPiece t = RocketPieces.Peek();
            RocketPieces.Pop();
            //pass te next object's particle system
            t.DetachPiece(RocketPieces.Peek().PS);
        }
    }
   // IEnumerator Detach()
   // {
   //    
   //     RocketPieces.Peek().GetComponent<ParticleSystem>().Stop();
   //     yield return new WaitForSeconds(1);
   //     RocketPieces.Peek().transform.parent = null;
   //     RocketPieces.Pop();
   //     yield return new WaitForSeconds(1);
   //     RocketPieces.Peek().GetComponent<ParticleSystem>().Play();
   // }
   // public void detachPiece()
   // {
   //     StartCoroutine(Detach());
   //
   // }
}
