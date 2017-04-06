using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_ToggleCursor : MonoBehaviour
{
    private GM_Master gameManagerMaster;
    private bool cursorLock = true;
    
	void OnEnable()
    {
        SetInitReferences();

        gameManagerMaster.MenuToggleEvent += ToggleCursorVis;
        gameManagerMaster.UIEvent += ToggleCursorVis;
    }//end OnEnable() 

    void OnDisable()
    {
        gameManagerMaster.MenuToggleEvent -= ToggleCursorVis;
        gameManagerMaster.UIEvent -= ToggleCursorVis;
    }//end OnEnable() 

    private void SetInitReferences()
    {
        gameManagerMaster = GetComponent<GM_Master>();
    }//end SetInitReferences()

    void ToggleCursorVis()
    {
        cursorLock = !cursorLock;
    }//end ToggleCursorVis

    void ChkCursorLock()
    {
        if(cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }//end if
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }//end CheckCursorLock

    // Update is called once per frame
    void Update()
    {
        ChkCursorLock();
	}//end Update()
}//end GM_ToggleCursor
