using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UberRocket : MonoBehaviour {

 

    ParticleSystem BottomPartucleSystem;
    AudioSource AS;
    bool fl;


    public delegate void ChangeColor();
    public static event ChangeColor fadeOut;

    SystemsDetached SD;
    public Countdown CountText;
    public CPC_CameraPath CameraPath;


    // Use this for initialization
    void Start()
    {


        BottomPartucleSystem = transform.GetChild(1).GetComponent<ParticleSystem>();
        SD = GetComponent<SystemsDetached>();
        AS = GetComponent<AudioSource>();
        BottomPartucleSystem.Stop();

        

    }

    public void StartLaunchSequence()
    {           
            StartCoroutine(LaunchSequence());      
    }

    IEnumerator LaunchSequence()
    {
        AS.Play();
        yield return new WaitForSeconds(1);
        //start countdown
        CountText.StartCounting(10);
        yield return new WaitForSeconds(4);
        //start engines
        BottomPartucleSystem.Play();
        yield return new WaitForSeconds(8);
        //fly away
        if (fadeOut != null)
            fadeOut();
        CameraPath.PlayPath(40);

        for (int i = 0; i < 1; i++)
        {
            yield return new WaitForSeconds(17);
            CountText.StartCounting();
            yield return new WaitForSeconds(3);
            //detach piece
            SD.Detach();

        }
    }
}
