using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHandler : MonoBehaviour
{
    private static int _puzzlesCompleted = 0;
    private static int _lastPuzzleCompleted = 0;
    private static bool _updateNextFrame = false;
    private Light _sunLight;
    [SerializeField] private GameObject treeBase;
    private Renderer _treeBaseRenderer;
    private Material[] _treeBaseMats;
    [SerializeField] private Material elementOnMat;
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
        _sunLight = GameObject.FindWithTag("Sunlight").GetComponent<Light>();
        _sunLight.intensity = 0.5f;
        _treeBaseRenderer = treeBase.GetComponent<Renderer>();
        _treeBaseMats = _treeBaseRenderer.materials;
    }

    // Update is called once per frame
    void Update()
    {
        if (_updateNextFrame && _puzzlesCompleted <= puzzleCompleteTexts.Length)
        {
            StartCoroutine(brightenTheSun());
            _treeBaseMats[_lastPuzzleCompleted] = elementOnMat;
            _treeBaseRenderer.materials = _treeBaseMats;
            textWriter.WriteText(puzzleCompleteTexts[_lastPuzzleCompleted - 1]);
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

    public static void IncrementCounter(int puzzleCompleted)
    {
        _puzzlesCompleted += 1;
        _lastPuzzleCompleted = puzzleCompleted;
        //Debug.Log("Puzzles completed: " + _puzzlesCompleted);
        _updateNextFrame = true;
    }

    private IEnumerator brightenTheSun()
    {
        float increase = 0;
        while (increase < 0.1f)
        {
            increase += 0.001f;
            _sunLight.intensity += 0.001f;
            yield return null;
        }
    }
}
