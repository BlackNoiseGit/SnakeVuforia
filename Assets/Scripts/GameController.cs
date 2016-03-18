using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
    public static GameController instance = null;

    private int Score;
    private int BestScore;

    [SerializeField]
    private GameObject headPrefab;
    private HeadSegment head;

    private PowerUpGenerator powerUpGenerator;
    private FieldManager fieldManager;
    private int LevelSizeFactor;

    private UIManager uiManager;

   

    void Awake()
    {

        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        powerUpGenerator = GetComponent<PowerUpGenerator>();
        fieldManager = GetComponent<FieldManager>();
        uiManager = GetComponent<UIManager>();

    }

	void Start () 
    {
       // uiManager.UIScore.text = Score.ToString();
        //uiManager.UIBestScore.text = BestScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void IncreaseScore()
    {
        Score++;
        uiManager.UIScore.text = Score.ToString();
    }

    public void GameOver()
    {
        if (Score > BestScore)
            BestScore = Score;
        Score = 0;

        head.isActive = false;
        powerUpGenerator.StopGenerating();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       
    }

    void OnLevelWasLoaded(int level) 
    {
        if (level == 1)
        {
            GameObject go = Instantiate(headPrefab);
            head = go.GetComponent<HeadSegment>();
            powerUpGenerator.Init(LevelSizeFactor);
            fieldManager.Init(LevelSizeFactor);
            
            uiManager.Init();
            uiManager.UIBestScore.text = BestScore.ToString();
            uiManager.UIScore.text = Score.ToString();
        }
            

    }

    public void StartGameFromMenu(int value)
    {
        LevelSizeFactor = value;
        SceneManager.LoadScene(1);
    }
}
