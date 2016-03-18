using UnityEngine;
using System.Collections;

public class ColliderReaction : MonoBehaviour
{
    [SerializeField]
    private HeadSegment head;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "TPowerUp")
        {
            head.CreateLastSegment();
            Destroy(other.gameObject);
            GameController.instance.IncreaseScore();
        }

        if (other.tag == "TObstacle" || other.tag == "TBody")
        {
            GameController.instance.GameOver();
        }
    }
}
