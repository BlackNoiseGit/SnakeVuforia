using UnityEngine;
using System.Collections;

public class FieldManager : MonoBehaviour {
    [SerializeField]
    private GameObject SmallFieldPref;
    [SerializeField]
    private GameObject MiddleFieldPref;
    [SerializeField]
    private GameObject LargeFieldPref;

    public void Init(int size)
    {
        switch (size)
        {
            case 0:
                Instantiate(SmallFieldPref);
                break;
            case 1:
                Instantiate(MiddleFieldPref);
                break;
            case 2:
                Instantiate(LargeFieldPref);
                break;
        }
          
    }
}
