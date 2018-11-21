using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
    Rigidbody rb;
   BoxCollider cp;
    Vector3 initialP;
    ParticleSystem ps;
    AudioSource AS;
    bool fl;
    public bool FlyAnim;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        cp = GetComponent<BoxCollider>();
        ps = GetComponent<ParticleSystem>();
        AS = GetComponent<AudioSource>();
        initialP = transform.position;
        ps.Stop();
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (  FlyAnim && cp.enabled)
        {

            rb.useGravity = true;
            rb.AddForce(transform.parent.up.normalized * 10, ForceMode.Force);
           // AS.Play();
        }
       
	}

    public void fly()
    {
        if (cp.enabled)
        {
            fl = true;
            ps.Play();
          
            //rb.AddForce(Vector3.up * 15, ForceMode.Force);
        }
    }
    public void stopfly()
    {
        if (cp.enabled)
        {
            fl = false;
           // ps.Stop();
        }
    }

    public void ResetRocket()
    {
        rb.velocity = Vector3.zero;
            transform.position = initialP;
        stopfly();
        
    }

    public void AnimateFlight()
    {
        if (cp.enabled)
        {
            StartCoroutine(lol());
        }
    }

    IEnumerator lol()
    {
        AS.Play();
        yield return new WaitForSeconds(5);
        ps.Play();
        yield return new WaitForSeconds(9);
        FlyAnim = true;
    }
}
