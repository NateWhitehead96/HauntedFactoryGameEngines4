using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light ReactorLight;
    public bool turnedOff;

    private bool switchLight = true;

    private Color startColor = Color.red;
    private Color offColor = Color.black;
    // Start is called before the first frame update
    void Start()
    {
        turnedOff = false;
        ReactorLight.color = startColor;
    }

    // Update is called once per frame
    void Update()
    {
        if(switchLight)
        {
            ReactorLight.color = Color.Lerp(startColor, offColor, Time.deltaTime);
        }
        else if(ReactorLight.color == offColor)
        {
            ReactorLight.color = Color.Lerp(offColor, startColor, Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Projectile"))
        {
            turnedOff = true;
            startColor = Color.green;
            ReactorLight.color = Color.green;
        }
    }
}
