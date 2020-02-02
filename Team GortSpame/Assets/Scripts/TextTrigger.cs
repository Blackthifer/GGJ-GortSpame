using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    [SerializeField] private string text;
    [SerializeField] private UITextWriter textWriter;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateWriter()
    {
        textWriter.WriteText(text);
        Destroy(gameObject);
    }
}
