using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFaceHighlighter : MonoBehaviour {
    [SerializeField]
   GameObject FaceBall;
    [SerializeField]
    GameObject CubeToSpawn;
    [SerializeField]
    Transform daddy;
    Vector3 Offset = Vector3.zero;
    Camera camera;

    [SerializeField]
    bool DebbugingOnEditor;
	// Use this for initialization
	void Start () {
        camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
     
        //ray to check the surface of the cube
            RaycastHit hit;
             Ray ray;
        //we check the mose if we're on the editor, camera otherwise.
        if (DebbugingOnEditor)
             ray = camera.ScreenPointToRay(Input.mousePosition);
        else
             ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        
            if (Physics.Raycast(ray, out hit))
            {
            //get the buildablecubecomponent.
                BuildableCube MyB = hit.transform.GetComponent<BuildableCube>();
                if (MyB)
                {
              
                //        Debug.DrawLine(hit.point, hit.transform.position, Color.red);
                    FaceBall.transform.position = CompareVectors(hit.point,hit.transform, MyB);
                    if (CreateC)
                    {
                    CreateCube(hit.point, hit.transform, daddy, MyB);
                    CreateC = false;
                  

                    }
                    else if (EraseC && MyB.Destructible)
                    {
                    Destroy(hit.transform.gameObject);
                    EraseC = false;
                    }

                CreateC = EraseC = false;
            }
            }
            else
            {
            FaceBall.transform.position = new Vector3(9999999, 9999999, 99999);
            CreateC = EraseC = false;
            }

        
    }

    Vector3 CompareVectors(Vector3 item, Transform Position,BuildableCube toCompare)
    {
        Vector3 deltaPos = item - Position.position;
        float res = -90;
        Vector3 closest = Vector3.zero;
        int index = 0;
        for (int i = 0; i < toCompare.Faces.Length; i++)
        {
            
            float value = Vector3.Dot(deltaPos.normalized, toCompare.Faces[i].normalized);
            if (value >= res)
            {
                res = value;
                closest = toCompare.Faces[i];
                index = i;
            }
        }
       // for (int i = 0; i < 3; i++)
       // {
       //     closest[i] *= Position.localScale[i];
       // }
            Offset = closest;
            return Position.position + (closest / 2);          
    }

    void CreateCube(Vector3 item, Transform Position, Transform _daddy, BuildableCube toCompare){
        Vector3 deltaPos = item - Position.position;
        float res = -90;
        Vector3 closest = Vector3.zero;
        int index = 0;
        for (int i = 0; i < toCompare.Faces.Length; i++)
        {

            float value = Vector3.Dot(deltaPos.normalized, toCompare.Faces[i].normalized);
            if (value >= res)
            {
                res = value;
                closest = toCompare.Faces[i];
                index = i;
            }
        }
      
        Offset = closest;

        FaceBall.transform.position = Position.position + (closest / 2);
        GameObject temp = Instantiate(CubeToSpawn, (Position.position + Offset),CubeToSpawn.transform.rotation,_daddy);
        //temp.transform.position = Position.position + Offset;
        
    }
    bool CreateC = false;
    public void Create()
    {
        CreateC = true;
    }
    bool EraseC = false;
    public void Erase()
    {
        EraseC = true;
    }
   
}
