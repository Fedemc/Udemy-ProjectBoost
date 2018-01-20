using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour {

    [SerializeField] Vector3 movementVector= new Vector3 (10f,10f,10f);
    [SerializeField] float period=2f;


    //Remover luego del Editor
    [Range(0,1)] [SerializeField] float movementFactor;   //0 no moverse, 1 moverse completo

    Vector3 startingPos;

	// Use this for initialization
	void Start ()
    {
        startingPos = gameObject.transform.position;
	}

    // Update is called once per frame
    void Update()
    {
        //Set movement factor
        //Period no puede valer 0, sino error!
        if(period < Mathf.Epsilon)
        {
            period = 0.1f;
        }
        float cycles = Time.time / period;

        const float TAU = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * TAU);

        movementFactor = rawSinWave / 2f + 0.5f;    //Se divide y se suma 0.5f para que el valor quede entre 0 y 1, y no entre 1 y -1

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
	}
}
