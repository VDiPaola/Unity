using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controls : MonoBehaviour
{
    //local components
    Rigidbody playerRB;
    Transform playerT;

    // fuel and thruster components
    public Text fuelText;


    float maxfuel = 200;
    public static float fuel = 200;
    public static int points = 0;
    public Transform headThrustCenter;
    public Transform bottomThruster;
    public Transform backThruster;

    //thruster particle systems
    public ParticleSystem rightHeadThruster;
    public ParticleSystem leftHeadThruster;
    public ParticleSystem leftSpinThruster;
    public ParticleSystem rightSpinThruster;
    public ParticleSystem topSpinThruster;
    public ParticleSystem bottomSpinThruster;
    public ParticleSystem backThruster2;

    //movement variables for thrusting
    float amountForMovement = (float)-0.1;
    float amountForBoost = (float)-1;
    ForceMode movementMode = ForceMode.Acceleration;

    //light object
    public Light light;
    //torch on and off objects
    public GameObject lightOn;
    public GameObject lightOff;

    bool charging = false;

    public GameObject rocket;
    


    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerT = GetComponent<Transform>();

    }

    //called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown("c"))
        {
            //shoot rocket
            GameObject rocketClone = Instantiate(rocket, rocket.transform.position,rocket.transform.rotation);

            rocketClone.GetComponent<Rigidbody>().velocity = (rocketClone.GetComponent<Transform>().up) * 30;

            rocketClone.SetActive(true);
        }

        if (Input.GetKey("f") && fuel <= maxfuel)
        {
            //charges fuel
            updateFuel((float)0.5);
            charging = true;
        }
        else
        {
            charging = false;
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if (fuel >= 1 && !charging)
        {
            if (Input.GetKey("w"))
            {
                updateFuel(amountForMovement);
                playerRB.AddForceAtPosition(headThrustCenter.forward, headThrustCenter.position - (headThrustCenter.forward * -1), movementMode);
                topSpinThruster.Play();
            }
            else
            {
                topSpinThruster.Stop();
            }
            if (Input.GetKey("s"))
            {
                updateFuel(amountForMovement);
                playerRB.AddForceAtPosition(headThrustCenter.forward * -1, headThrustCenter.position + (headThrustCenter.forward), movementMode);
                bottomSpinThruster.Play();
            }
            else
            {
                bottomSpinThruster.Stop();
            }
            if (Input.GetKey("d"))
            {
                updateFuel(amountForMovement);
                playerRB.AddForceAtPosition(headThrustCenter.forward * -1, headThrustCenter.position + (headThrustCenter.right), movementMode);
                leftSpinThruster.Play();
            }
            else
            {
                leftSpinThruster.Stop();
            }
            if (Input.GetKey("a"))
            {
                updateFuel(amountForMovement);
                playerRB.AddForceAtPosition(headThrustCenter.forward * -1, headThrustCenter.position - (headThrustCenter.right), movementMode);
                rightSpinThruster.Play();
            }
            else
            {
                rightSpinThruster.Stop();
            }
            if ( Input.GetKey("q") )
            {
                updateFuel(amountForMovement);
                playerRB.AddForceAtPosition(headThrustCenter.right * -1, headThrustCenter.position + (headThrustCenter.right), movementMode);
                rightHeadThruster.Play();
            }
            else
            {
                rightHeadThruster.Stop();
            }
            if (Input.GetKey("e"))
            {
                updateFuel(amountForMovement);
                playerRB.AddForceAtPosition(headThrustCenter.right, headThrustCenter.position - (headThrustCenter.right), movementMode);
                leftHeadThruster.Play();
            }
            else
            {
                leftHeadThruster.Stop();
            }
            if (Input.GetKey("space"))
            {
                updateFuel(amountForBoost);
                playerRB.AddForceAtPosition(backThruster.forward, backThruster.position, movementMode);
                backThruster2.Play();
            }
            else
            {
                backThruster2.Stop();
            }

        }
        else
        {
            //no fuel
            backThruster2.Stop();
            leftHeadThruster.Stop();
            rightHeadThruster.Stop();
            leftSpinThruster.Stop();
            rightSpinThruster.Stop();
            topSpinThruster.Stop();
            bottomSpinThruster.Stop();

        }

    }

    private void Update()
    {
        if (Input.GetKeyDown("r"))
        {

            light.enabled = !light.enabled;
            lightOff.SetActive(!lightOff.active);
            lightOn.SetActive(!lightOn.active);

        }
    }


    void updateFuel(float amount)
    {
            fuel += amount;
            fuel = Mathf.Floor(fuel * 10);
            fuel /= 10;
            if (fuel < 1 && amount <= 0) { fuel = 0; }
            fuelText.text = "" + fuel;
    }
}


