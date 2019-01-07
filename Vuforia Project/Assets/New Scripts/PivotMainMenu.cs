using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotMainMenu : MonoBehaviour {

    [SerializeField]
    bool RandomNumber;
    [SerializeField]
    float RotationSpeed;
    [SerializeField]
    Vector3 RotationVector;

    private void Start()
    {
        if (RandomNumber)
            RotationSpeed = Random.Range(-5f,5f);

        if (GameOverseer.instance)
            GameOverseer.instance.ResetList();
    }
    // Update is called once per frame
    void Update () {
        if (RotationVector == Vector3.zero)
            transform.Rotate(0, 0, Time.deltaTime * RotationSpeed);
        else
            transform.Rotate(RotationVector*Time.deltaTime);

	}
}
