using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_References : MonoBehaviour
{
    public string playerTag;
    public static string _playerTag;

    public string enemyTag;
    public static string _enemyTag;

    public static GameObject _player;

    private void OnEnable()
    {
        if(playerTag == "")
        {
            Debug.Log("Please Enter playerTag in Inspector");
        }//end if
        if (enemyTag == "")
        {
            Debug.Log("Please Enter enemyTag in Inspector");
        }//end if

        _playerTag = playerTag;
        _enemyTag = enemyTag;

        _player = GameObject.FindGameObjectWithTag(_playerTag);
    }//end OnEnable()

    private void OnDisable()
    {

    }//end On Disable
}//end class GM_References
