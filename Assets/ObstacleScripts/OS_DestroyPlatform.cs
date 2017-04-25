using UnityEngine;

public class OS_DestroyPlatform : MonoBehaviour
{
    private GameObject cameraChk;

    // Use this for initialization
    void Start ()
	{
        cameraChk = GameObject.Find("Main Camera");
    }//end Start()
	
	// Update is called once per frame
	void Update ()
	{
        if (this.transform.position.x < cameraChk.transform.position.x - 11 - (this.transform.localScale.x / 2))
        {
            if (this.gameObject.name.Contains("InitPlatform"))
            {
                if (this.gameObject.name.Contains("Clone"))
                {
                    Destroy(this.gameObject);
                }//end if
            }//end if
            else
            {
                Destroy(this.gameObject);
            }//end else
        }//end if
	}//end Update()
}//end class OS_DestroyPlatform
