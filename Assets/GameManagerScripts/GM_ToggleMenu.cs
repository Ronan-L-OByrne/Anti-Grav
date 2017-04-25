using UnityEngine;

public class GM_ToggleMenu : MonoBehaviour
{
    private GM_Master gameManagerMaster;
    public GameObject menu;

    private void Update()
    {
        CheckToggleMenuReq();
    }//end Update()

    private void OnEnable()
    {
        SetInitReferences();
        gameManagerMaster.GameOverEvent += ToggleMenu;
    }//end OnEnable()

    private void OnDisable()
    {
        gameManagerMaster.GameOverEvent -= ToggleMenu;
    }//end OnDisable()

    private void SetInitReferences()
    {
        gameManagerMaster = GetComponent<GM_Master>();
    }//end SetInitReferences()

    void CheckToggleMenuReq()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !gameManagerMaster.GameOver && !gameManagerMaster.InventoryUIOn)
        {
            ToggleMenu();
        }//end if
    }//end CheckToggleMenuReq()

    void ToggleMenu()
    {
        if(menu != null)
        {
            menu.SetActive(!menu.activeSelf);
            gameManagerMaster.MenuOn = !gameManagerMaster.MenuOn;
            gameManagerMaster.CallEventMenuToggle();
            //Debug.Log("MenuToggled" + gameManagerMaster.MenuOn);
        }//end if
    }//end ToggleMenu()
}//end class GM_ToggleMenu
