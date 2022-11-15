using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class IG1EnemyController : AgentController
{
    private EnemyStateManager _stateManager;

    private void Awake()
    {
        _stateManager = GetComponent<EnemyStateManager>();
    }

    void Start()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        GetComponent<AISenseSight>().AddSenseHandler(new AISense<SightStimulus>.SenseEventHandler(HandleSight));
        GetComponent<AISenseSight>().AddObjectToTrack(player);
        GetComponent<AISenseHearing>().AddSenseHandler(new AISense<HearingStimulus>.SenseEventHandler(HandleHearing));
        GetComponent<AISenseHearing>().AddObjectToTrack(player);
    }

    void HandleSight(SightStimulus sti, AISense<SightStimulus>.Status evt)
    {
        if (evt == AISense<SightStimulus>.Status.Enter)
        {
            Debug.Log("Objet " + evt + " vue en " + sti.position);
            _stateManager.SwitchState(_stateManager.pursuitState);
            //_fSMTester.FSMInfos.CanSeeTarget = true;
        }
        else if (evt == AISense<SightStimulus>.Status.Leave)
        {
            _stateManager.SwitchState(_stateManager.patrolState); ///// A modifier
        }
        
        _stateManager.pursuitState.targetPostion = sti.position;


        //FindPathTo(sti.position);


        
    }

    void HandleHearing(HearingStimulus sti, AISense<HearingStimulus>.Status evt)
    {
        if (evt == AISense<HearingStimulus>.Status.Enter)
        {
            Debug.Log("Objet " + evt + " ouï en " + sti.position);
            _stateManager.SwitchState(_stateManager.pursuitState);
        }
        else if(evt == AISense<HearingStimulus>.Status.Leave)
        {

        }
        
            
        _stateManager.pursuitState.targetPostion = sti.position;

        //FindPathTo(sti.position);
    }
}