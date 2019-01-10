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
        hasBegunFlying = true;

        for (int i = 0; i < 1; i++)
        {
            yield return new WaitForSeconds(19);
            if (Allowdeployment != null)
                Allowdeployment(true);
            canBeDetached = true;
            yield return new WaitForSeconds(10);
            if(!hasdeployed)
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


   
}
