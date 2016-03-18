using UnityEngine;
using System.Collections;

public class HeadSegment : MonoBehaviour {
    [SerializeField]
    private GameObject segmentPref;

    [SerializeField]
    private float speed = 20f;

    private Vector3 dir = Vector3.right;

    private Transform thisTrans;
    private Rigidbody thisRB;

    private Segment prevSegment;
    private Segment lastSegment;
    private int numOfSegments;

    public bool isActive { get; set; }

	void Start () 
    {
        thisTrans = transform;
        thisRB = GetComponent<Rigidbody>();
        isActive = true;
	
	}
	

	void Update () 
    {
        if (numOfSegments > 0 && prevSegment != null)
            prevSegment.dragSegment(1, numOfSegments, thisTrans.position);
	
	}

    void FixedUpdate()
    {
        if (!isActive)
        {
            thisRB.velocity = Vector3.zero;
            return;
        }
            

        InputCommands();
        MoveToTarget();
    }

    void MoveToTarget()
    {
        Quaternion misRotation;
        Vector3 movementDir = Vector3.zero;

        Vector3 d = thisTrans.position + dir;
        movementDir = d - thisRB.position;

        movementDir = movementDir.normalized;
        misRotation = Quaternion.LookRotation(movementDir);

        thisTrans.rotation = Quaternion.RotateTowards(thisRB.rotation, misRotation, 100);
        thisTrans.rotation = Quaternion.Euler(0, thisRB.rotation.eulerAngles.y, 0);


        thisRB.velocity = thisTrans.forward * speed;
    }

    void InputCommands()
    {
        Vector3 newDir = Vector3.zero;

        if (Input.GetKey(KeyCode.D))
        {
            newDir = Vector3.right;
            if (dir == -newDir)
                return;
            else
                dir = newDir;
         }

        if (Input.GetKey(KeyCode.S))
        {
            newDir = -Vector3.forward;
            if (dir == -newDir)
                return;
            else
                dir = newDir;
        }

        if (Input.GetKey(KeyCode.A))
        {
            newDir = Vector3.left;
            if (dir == -newDir)
                return;
            else
                dir = newDir;
         }

        if (Input.GetKey(KeyCode.W))
        {
            newDir = Vector3.forward;
            if (dir == -newDir)
                return;
            else
                dir = newDir;
        }
     }


    public void CreateLastSegment()
    {
        Vector3 pos = Vector3.zero;
        Quaternion rot = Quaternion.identity;

        GameObject go = Instantiate(segmentPref, pos, rot) as GameObject;
        numOfSegments++;

        if (lastSegment == null)
        {
            go.transform.position = thisTrans.position - dir;
            go.transform.rotation = Quaternion.identity;

            prevSegment = go.GetComponent<Segment>();
            lastSegment = prevSegment;

        }
        else
        {
            go.transform.position = lastSegment.gameObject.transform.position;
            
            go.GetComponent<Segment>().nextSegment = lastSegment;
            lastSegment.prevSegment = go.GetComponent<Segment>();
            lastSegment = go.GetComponent<Segment>();

        }

    }
}
