using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UberRocket : MonoBehaviour {

 

    ParticleSystem BottomPartucleSystem;
    AudioSource AS;
    bool hasBegunFlying;


    public delegate void ChangeColor();
    public static event ChangeColor fadeOut;

    public delegate void Deployment(bool _allow);
    public static event Deployment Allowdeployment;

    SystemsDetached SD;
    public Countdown CountText;
    public CPC_CameraPath CameraPath;


    bool canBeDetached;
    bool launchSequenceHasBegun;

    private void OnEnable()
    {
        CameraTouchInput.ClickedItem += DeployRocket;
        GameOverseer.instance.ARTargetFoundStatus += handlePause;
        
    }

    private void OnDisable()
    {
        CameraTouchInput.ClickedItem -= DeployRocket;
        GameOverseer.instance.ARTargetFoundStatus -= handlePause;
      
    }
    // Use this for initialization
    void Start()
    {


        BottomPartucleSystem = transform.GetChild(1).GetComponent<ParticleSystem>();
        SD = GetComponent<SystemsDetached>();
        AS = GetComponent<AudioSource>();
        BottomPartucleSystem.Stop();

        

    }

    void handlePause(bool _resume)
    {
        if (!launchSequenceHasBegun)
            return;

        if (launchSequenceHasBegun)
        {
            if (_resume)
                AS.UnPause();
            else
                AS.Pause();
        }


        if (!hasBegunFlying)
            return;
        
        if ( _resume)
            CameraPath.ResumePath();
        else if(!_resume)
            CameraPath.PausePath();
    }
    public void StartLaunchSequence()
    {           
            StartCoroutine(LaunchSequence());      
    }

    IEnumerator LaunchSequence()
    {
        launchSequenceHasBegun = true;

        AS.Play();

        yield return new WaitUntil(() => getAudioPercentage() >= 1);
        //start countdown
        CountText.StartCounting(10);
        yield return new WaitUntil(() => getAudioPercentage() >= 5);
        //start engines
        BottomPartucleSystem.Play();
        yield return new WaitUntil(() => getAudioPercentage() >= 15);
        //fly away
        if (fadeOut != null)
            fadeOut();
        CameraPath.PlayPath(40);
        hasBegunFlying = true;

        for (int i = 0; i < 1; i++)
        {
            //yield return new WaitForSeconds(19);
            yield return new WaitUntil(() => getAudioPercentage() >= 37);
            if (Allowdeployment != null)
                Allowdeployment(true);
            canBeDetached = true;
            // yield return new WaitForSeconds(10);
            yield return new WaitUntil(() => getAudioPercentage() >= 50);
            if (!hasdeployed)
                 DeployRocket();

        }
    }

    bool hasdeployed;
    void DeployRocket()
    {
        if (!canBeDetached)
            return;

        hasdeployed = true;
        if (Allowdeployment != null)
            Allowdeployment(false);
        canBeDetached = false;
        hasdeployed = true;
        CountText.StartCounting();
        SD.Detach();
    }

    //returns the percentage of the progress of the audio playing, used on the coroutine to trigger some rocket events, mostly on pause
    int getAudioPercentage()
    {
        return (int)((AS.time / AS.clip.length) * 100);
    }
   
}
