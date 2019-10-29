using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogObject : MonoBehaviour
{
    public bool inspected;
    public List<DialogPage> inspectDialog;
    public List<DialogPage> inspectedDialog;
    void Start()
    {
        inspected = false;
    }
}
