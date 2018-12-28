using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotMainMenu : MonoBehaviour {

    [SerializeField]
    bool RandomNumber;
    [SerializeField]
    float RotationSpeed;

    private void Start()
    {
        if (RandomNumber)
            RotationSpeed = Random.Range(-5f,5f);
    }
    // Update is called once per frame
    void Update () {
        transform.Rotate(0, 0, Time.deltaTime*RotationSpeed);
	}
}
