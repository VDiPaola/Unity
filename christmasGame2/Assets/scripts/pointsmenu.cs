using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointsmenu : MonoBehaviour
{
    Button btn;
    public Text points;
    public Text fuel;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(buttonClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void buttonClick()
    {
        if (controls.points >= 20)
        {

            //take away points
            controls.points -= 20;
            //add fuel
            controls.fuel += 100;

            //update UI
            points.text = "" + controls.points;
            fuel.text = "" + controls.fuel;
        }
    }

}
