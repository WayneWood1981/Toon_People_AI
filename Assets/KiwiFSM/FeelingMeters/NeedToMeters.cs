using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeedToMeters : MonoBehaviour
{
    public float currentMeterLevel;
    public float maxMeterLevel;
    public float depreciationAmount;
    public float changeStatePoint;

    public GameObject HealthBar;
    private Slider slider;
    private AIAgent agent;

    private void Start()
    {

        agent = GetComponent<AIAgent>();
        slider = HealthBar.GetComponent<Slider>();

        if (slider)
        {
            slider.value = maxMeterLevel;
        }
    }

    private void Update()
    {
        currentMeterLevel = slider.value;

        

        if (slider.value <= 0)
        {
            slider.value = 0;
        }

        if(currentMeterLevel <= changeStatePoint)
        {
            
            agent.stateMachine.ChangeState(AIStateId.GETPHONE);
        }

        if(agent.stateMachine.currentState == AIStateId.ONPHONE)
        {
            slider.value += depreciationAmount * 2 * Time.deltaTime;

            if(slider.value >= maxMeterLevel)
            {
                slider.value = maxMeterLevel;
            }
            
        }
        else
        {
            slider.value -= depreciationAmount * Time.deltaTime;
        }


        Debug.Log(currentMeterLevel);
    }

}
