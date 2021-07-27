using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    [SerializeField]
    private float timeDelay = 0.1f;
    
    private void Update()
    {
        StartCoroutine("Flicker");
    }

    IEnumerator Flicker()
    {
        gameObject.GetComponent<Light>().enabled = false;
        yield return new WaitForSeconds(timeDelay);
        gameObject.GetComponent<Light>().enabled = true;
        yield return new WaitForSeconds(timeDelay);
    }
}
