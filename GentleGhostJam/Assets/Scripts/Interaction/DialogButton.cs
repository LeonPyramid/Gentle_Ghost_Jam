using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogButton : MonoBehaviour , IPointerDownHandler
{
    public DialogManager dialog;
    public void OnPointerDown(PointerEventData eventData){
        dialog.Next();
    }
}
