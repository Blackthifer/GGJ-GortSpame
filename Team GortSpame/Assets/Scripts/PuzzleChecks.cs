using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleChecks : MonoBehaviour
{
    private bool stoneDone           = false;
    private bool woodDone            = false;
    private bool waterDone           = false;
    private bool metalDone           = false;
    private bool fireDone            = false;
    private bool stoneNotCompleteYet = true;

    public bool audioPlayer1         = false;
    public bool audioPlayer2         = false;
    public bool audioPlayer3         = false;
    public bool audioPlayer4         = false;
    public bool audioPlayer5         = false;
    public bool gameDone             = false;

    public GameObject stone1;
    public GameObject stone2;
    public GameObject stone3;
    public GameObject stone4;
    public GameObject stoneHere1;
    public GameObject stoneHere2;
    public GameObject stoneHere3;
    public GameObject stoneHere4;
    public GameObject wood1;
    public GameObject woodHere1;
    public GameObject water1;
    public GameObject waterHere1;
    public GameObject metal1;
    public GameObject metalHere1;
    public GameObject fire1;
    public GameObject fireHere1;

    // Update is called once per frame
    void Update()
    {
        stonePuzzleCheck();
        woodPuzzleCheck();
        waterPuzzleCheck();
        metalPuzzleCheck();
        firePuzzleCheck();

        //audioMessageCheck();
        gameFinishedCheck();
    }

    private void stonePuzzleCheck()
    {
        Vector3 stoneDiff1 = stone1.transform.position - stoneHere1.transform.position;

        float stoneDiff1Q = Mathf.Sqrt((stoneDiff1.x * stoneDiff1.x) + (stoneDiff1.y * stoneDiff1.y));
        float stoneDiff1R = Mathf.Sqrt((stoneDiff1.z * stoneDiff1.z) + (stoneDiff1Q * stoneDiff1Q));

        Vector3 stoneDiff2 = stone2.transform.position - stoneHere2.transform.position;

        float stoneDiff2Q = Mathf.Sqrt((stoneDiff2.x * stoneDiff2.x) + (stoneDiff2.y * stoneDiff2.y));
        float stoneDiff2R = Mathf.Sqrt((stoneDiff2.z * stoneDiff2.z) + (stoneDiff2Q * stoneDiff2Q));

        Vector3 stoneDiff3 = stone3.transform.position - stoneHere3.transform.position;

        float stoneDiff3Q = Mathf.Sqrt((stoneDiff3.x * stoneDiff3.x) + (stoneDiff3.y * stoneDiff3.y));
        float stoneDiff3R = Mathf.Sqrt((stoneDiff3.z * stoneDiff3.z) + (stoneDiff3Q * stoneDiff3Q));

        Vector3 stoneDiff4 = stone4.transform.position - stoneHere4.transform.position;

        float stoneDiff4Q = Mathf.Sqrt((stoneDiff4.x * stoneDiff4.x) + (stoneDiff4.y * stoneDiff4.y));
        float stoneDiff4R = Mathf.Sqrt((stoneDiff4.z * stoneDiff4.z) + (stoneDiff4Q * stoneDiff4Q));

        if(stoneDiff1R <= 0.3f && stoneDiff2R <= 0.3f && stoneDiff3R <= 0.3f && stoneDiff1R <= 0.3f && !stoneDone)
        {
            stoneDone = true;
            audioPlayer1 = true;
        }

    }
    private void woodPuzzleCheck()
    {
        Vector3 woodDiff1 = wood1.transform.position - woodHere1.transform.position;

        float woodDiff1Q = Mathf.Sqrt((woodDiff1.x * woodDiff1.x) + (woodDiff1.y * woodDiff1.y));
        float woodDiff1R = Mathf.Sqrt((woodDiff1.z * woodDiff1.z) + (woodDiff1Q * woodDiff1Q));

        if(woodDiff1R < 0.3f && !woodDone)
        {
            woodDone = true;
            audioPlayer2 = true;
        }
    }
    private void waterPuzzleCheck()
    {
        Vector3 waterDiff1 = water1.transform.position - waterHere1.transform.position;

        float waterDiff1Q = Mathf.Sqrt((waterDiff1.x * waterDiff1.x) + (waterDiff1.y * waterDiff1.y));
        float waterDiff1R = Mathf.Sqrt((waterDiff1.z * waterDiff1.z) + (waterDiff1Q * waterDiff1Q));

        if (waterDiff1R < 0.3f && !waterDone)
        {
            waterDone = true;
            audioPlayer3 = true;
        }
    }
    private void metalPuzzleCheck()
    {
        Vector3 metalDiff1 = metal1.transform.position - metalHere1.transform.position;

        float metalDiff1Q = Mathf.Sqrt((metalDiff1.x * metalDiff1.x) + (metalDiff1.y * metalDiff1.y));
        float metalDiff1R = Mathf.Sqrt((metalDiff1.z * metalDiff1.z) + (metalDiff1Q * metalDiff1Q));

        if (metalDiff1R < 0.3f && !metalDone)
        {
            metalDone = true;
            audioPlayer4 = true;
        }
    }
    private void firePuzzleCheck()
    {
        Vector3 fireDiff1 = fire1.transform.position - fireHere1.transform.position;

        float fireDiff1Q = Mathf.Sqrt((fireDiff1.x * fireDiff1.x) + (fireDiff1.y * fireDiff1.y));
        float fireDiff1R = Mathf.Sqrt((fireDiff1.z * fireDiff1.z) + (fireDiff1Q * fireDiff1Q));

        if (fireDiff1R < 0.3f && !fireDone)
        {
            fireDone = true;
            audioPlayer5 = true;
        }
    }

    private void gameFinishedCheck()
    {
        if(stoneDone && waterDone && fireDone && woodDone && metalDone)
        {
            gameDone = true;
        }
    }
}
