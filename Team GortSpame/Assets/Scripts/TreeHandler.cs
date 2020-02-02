using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHandler : MonoBehaviour
{
    private static int _puzzlesCompleted = 0;
    private static bool _updateNextFrame = false;
    [SerializeField] private GameObject stage1Tree;
    [SerializeField] private GameObject stage2Tree;
    [SerializeField] private GameObject stage3Tree;
    [SerializeField] private GameObject stage4Tree;
    [SerializeField] private GameObject stage5Tree;
    [SerializeField] private UITextWriter textWriter;
    [SerializeField] private string[] puzzleCompleteTexts;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_updateNextFrame && _puzzlesCompleted <= puzzleCompleteTexts.Length)
        {
            textWriter.WriteText(puzzleCompleteTexts[_puzzlesCompleted - 1]);
            _updateNextFrame = false;
        }
        switch (_puzzlesCompleted)
        {
            case 0: 
                break;
            case 1:
                stage1Tree.SetActive(true);
                break;
            case 2:
                stage1Tree.SetActive(false);
                stage2Tree.SetActive(true);
                break;
            case 3:
                stage2Tree.SetActive(false);
                stage3Tree.SetActive(true);
                break;
            case 4:
                stage3Tree.SetActive(false);
                stage4Tree.SetActive(true);
                break;
            default:
                stage4Tree.SetActive(false);
                stage5Tree.SetActive(true);
                break;
        }
    }

    public static void IncrementCounter()
    {
        _puzzlesCompleted += 1;
        //Debug.Log("Puzzles completed: " + _puzzlesCompleted);
        _updateNextFrame = true;
    }
}
