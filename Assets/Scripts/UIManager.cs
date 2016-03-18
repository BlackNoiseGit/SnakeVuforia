using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {


    private Text _UIScore;
    private Text _UIBestScore;



    public Text UIScore
    {
        set { _UIScore = value; }
        get { return _UIScore; }
    }

    public Text UIBestScore
    {
        set { _UIBestScore = value; }
        get { return _UIBestScore; }
    }
    

	
	// Update is called once per frame
	void Update () {
	
	}

    public void Init()
    {
        UIScore = GameObject.Find("ScoreValue").GetComponent<Text>();
        UIBestScore = GameObject.Find("BestScoreValue").GetComponent<Text>();
    }
}
