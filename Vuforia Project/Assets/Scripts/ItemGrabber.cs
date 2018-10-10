using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemGrabber : MonoBehaviour {

    [SerializeField]
    Text t;
    Camera camera;
    Player player;
    private void Start()
    {
        camera = GetComponent<Camera>();
        player = GetComponent<Player>();
    }


    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
             RaycastHit hit;
             Ray ray = camera.ScreenPointToRay(Input.mousePosition);
             if (Physics.Raycast(ray, out hit))
             {
                if (hit.transform.GetComponent<CardItem>() != null)
                {
                    print("Oh, this is a... "+hit.transform.gameObject.name);
                    if (!hit.transform.GetComponent<CardItem>().visited)
                    {
                        player.AddItemToBackPack(hit.transform.gameObject);
                        hit.transform.GetComponent<CardItem>().visited = true;
                    }
                    else
                        print("Oof, you already have this item...");

                }

             }
            else
            {
                print("I can't feel anything...");
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            player.PrintBackPackElements(t);
        }

        
    }
}
