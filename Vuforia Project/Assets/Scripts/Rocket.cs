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

    SystemsDetached SD;
    public Countdown CountText;
    public bool FlyAnim;
    public CPC_CameraPath CameraPath;
    public Animator DeployButtonCover;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        cp = GetComponent<BoxCollider>();
        ps = transform.GetChild(1).GetComponent<ParticleSystem>();
        SD = GetComponent<SystemsDetached>();
        AS = GetComponent<AudioSource>();
        initialP = transform.position;
        ps.Stop();
        
    }

    float increment = 1;
	// Update is called once per frame
	void FixedUpdate () {
        if (  FlyAnim && cp.enabled)
        {
            if (increment <= 2)
                increment += Time.deltaTime;
            // rb.useGravity = true;
            // rb.AddForce(transform.parent.up.normalized * 10, ForceMode.Force);

            // transform.position += new Vector3(0, Time.deltaTime*5*increment, 0);
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
       // rb.velocity = Vector3.zero;
            transform.position = initialP;
        stopfly();
        
    }
    bool isdone;
    public void AnimateFlight()
    {
        if (isdone)
            return;
        if (cp.enabled)
        {
            StartCoroutine(lol());
            isdone = true;
        }
    }

    IEnumerator lol()
    {
        AS.Play();
        yield return new WaitForSeconds(1);
        //start countdown
        CountText.StartCounting(10);
        yield return new WaitForSeconds(4);
        //start engines
        ps.Play();
        yield return new WaitForSeconds(8);
        //fly away
        //FlyAnim = true;
        CameraPath.PlayPath(40);
        
        for (int i = 0; i < 1; i++)
        {
            yield return new WaitForSeconds(17);
            //start coundown again
            DeployButtonCover.Play("shrink away");
            CountText.StartCounting();
            yield return new WaitForSeconds(3);
            //detach piece
            DeployButtonCover.Play("unfold");
            SD.Detach();
            
        }
    }
}
