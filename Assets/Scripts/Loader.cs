using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

    [SerializeField]
    private GameObject GameController;

    void Awake()
    {
        Instantiate(GameController);
    }
}
