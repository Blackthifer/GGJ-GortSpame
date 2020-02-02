using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextWriter : MonoBehaviour
{
    [SerializeField] private GameObject textPanel;
    [SerializeField] private Text textField;
    [SerializeField] private GameObject closeTextPrompt;
    private bool _active;

    // Start is called before the first frame update
    void Start()
    {
        _active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_active)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                closeTextPrompt.SetActive(false);
                StopAllCoroutines();
                textField.text = "";
                textPanel.SetActive(false);
                _active = false;
            }
        }
    }

    public void WriteText(string toWrite)
    {
        textPanel.SetActive(true);
        StartCoroutine(typeText(toWrite));
        _active = true;
    }

    private IEnumerator typeText(string toType)
    {
        string fieldText = "";
        for (int i = 0; i < toType.Length; i += 2)
        {
            fieldText += toType[i];
            if (i + 1 == toType.Length)
            {
                textField.text = fieldText;
                break;
            }

            fieldText += toType[i + 1];
            textField.text = fieldText;
            yield return null;
        }
        closeTextPrompt.SetActive(true);
    }
}
