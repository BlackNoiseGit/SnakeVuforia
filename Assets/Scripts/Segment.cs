using UnityEngine;
using System.Collections;

public class Segment : MonoBehaviour {
    private Transform thisTrans;

    public Segment prevSegment { get; set; }
    public Segment nextSegment { get; set; }
	// Use this for initialization
	void Start ()
    {
        thisTrans = transform;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void dragSegment(float segDist, int counter, Vector3 nextPos)
    {
        float xin = nextPos.x;
        float yin = nextPos.z;
        float x = thisTrans.position.x;
        float y = thisTrans.position.z;
        float dx = xin - x;
        float dy = yin - y;
        float angle = Mathf.Atan2(dy, dx);

        float newX = xin - Mathf.Cos(angle) * segDist;
        float newY = yin - Mathf.Sin(angle) * segDist;

        thisTrans.position = new Vector3(newX, 0, newY);

        thisTrans.rotation = Quaternion.LookRotation(nextPos - thisTrans.position);
        thisTrans.rotation = Quaternion.Euler(0, thisTrans.root.eulerAngles.y, 0);

        counter--;
        if (counter == 0)
            return;

        prevSegment.dragSegment(segDist, counter, thisTrans.position);
    }
}
