using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
    private Transform thisTrans;

    [SerializeField]
    private float angle;

	void Start () {
        thisTrans = transform;
	
	}
	
	void Update () 
    {
        thisTrans.Rotate(Vector3.up, angle * Time.deltaTime);
	
	}
}
