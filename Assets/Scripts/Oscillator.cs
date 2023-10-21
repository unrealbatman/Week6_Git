using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    // this script is used for oscillating objects in the scene
   [SerializeField] float period = 0f;

    [SerializeField] Vector3 movementVector;
   [Range(0,1)] [SerializeField] float movementFactor; //0 for not moved , 1 for fully moved
    Vector3 startingPos;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (period <= Mathf.Epsilon)
        {
            return;
        }

        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2f;
        float RawSineWave = Mathf.Sin(tau * cycles);

         movementFactor = RawSineWave / 2f + 0.5f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}
