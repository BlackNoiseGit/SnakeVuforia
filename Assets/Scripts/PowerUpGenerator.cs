using UnityEngine;
using System.Collections;

public class PowerUpGenerator : MonoBehaviour {
    [SerializeField]
    private GameObject PowerUpPref;
    [SerializeField]
    private float PowerUpRate = 12f;
    [SerializeField]
    private int PowerUpStartValue = 4;
    
    [Header("Random ranges")]
    [SerializeField]
    private Vector2 SmallRandomRange;
    [SerializeField]
    private Vector2 MiddleRandomRange;
    [SerializeField]
    private Vector2 LargeRandomRange;

    private Vector2 RandomRange;


    public void Init(int size)
    {
        switch(size)
        {
            case 0 :
                RandomRange = SmallRandomRange;
                break;
            case 1:
                RandomRange = MiddleRandomRange;
                break;
            case 2:
                RandomRange = LargeRandomRange;
                break;
        }
          
        GenerateStartPowerUps(PowerUpStartValue);
        StartCoroutine("CreatePowerUpRoutine");
    }


    void GenerateStartPowerUps(int value)
    {
        for(int i = 0; i <= value; i++)
        {
            CreatePowerUp();
        }
    }

    void CreatePowerUp()
    {
        Vector3 pos = new Vector3(Random.Range(RandomRange.x, RandomRange.y),
                                      0,
                                     Random.Range(RandomRange.x, RandomRange.y));
        GameObject go = Instantiate(PowerUpPref, pos, Quaternion.identity) as GameObject;
    }

    IEnumerator CreatePowerUpRoutine()
    {
        while(true)
        {
             yield return new WaitForSeconds(PowerUpRate);
             CreatePowerUp();
        }
    }

    public void StopGenerating()
    {
        StopCoroutine("CreatePowerUpRoutine");
    }

}
