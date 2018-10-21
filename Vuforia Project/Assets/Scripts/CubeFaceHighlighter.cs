using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFaceHighlighter : MonoBehaviour {
    [SerializeField]
   GameObject FaceBall;

    Vector3 Offset = Vector3.zero;
    Camera camera;
	// Use this for initialization
	void Start () {
        camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
       // if (Input.GetKeyDown(KeyCode.Mouse0))
       // {
            RaycastHit hit;
           // Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            if (Physics.Raycast(ray, out hit))
            {
                BuildableCube MyB = hit.transform.GetComponent<BuildableCube>();
                if (MyB)
                {
                    GameObject temp;
                        Debug.DrawLine(hit.point, hit.transform.position, Color.red);
                        FaceBall.transform.position = CompareVectors(hit.point,hit.transform.position, MyB);

                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        temp = Instantiate(hit.transform.gameObject,null);
                        temp.transform.position = hit.transform.position + Offset;
                    }
                    else if (Input.GetKeyDown(KeyCode.Mouse1))
                    {
                    Destroy(hit.transform.gameObject);
                    }
                }
            }
            else
            {
            FaceBall.transform.position = new Vector3(9999999, 9999999, 99999);
                print("I see no face");
            }

        
       // }
    }

    Vector3 CompareVectors(Vector3 item, Vector3 Position,BuildableCube toCompare)
    {
        Vector3 deltaPos = item - Position;
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
            return Position + (closest / 2);          
    }



   
}
