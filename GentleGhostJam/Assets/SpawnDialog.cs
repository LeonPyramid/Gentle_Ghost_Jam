using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDialog : MonoBehaviour
{
    public List<DialogPage> dialogSpawn;
    private DialogManager dialogManager;
    // Start is called before the first frame update
    void Start()
    {
        dialogManager = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventaire>().dialogManager;
        dialogManager.SetDialog(dialogSpawn);
        GameObject.Destroy(this);
    }

}
