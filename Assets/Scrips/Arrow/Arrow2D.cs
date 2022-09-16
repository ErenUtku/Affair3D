using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Arrow2D : MonoBehaviour
{
    public ArrowData arrowData;
    public Image arrowImg;

    private bool isCorrected=false;
    public float alphaValue;

    public bool isLastArrow = false;
#region Awake & Start & Update
    private void Awake()
    {
        //Set alpha value
        alphaValue = 1;
    }
    
    private void Start()
    {
        //Set Rotation of Arrow
        if (arrowData.direction == DIRECTION.DOWN)
        {
            arrowImg.gameObject.transform.Rotate(0, 0, 180);
            return;
        }
        if (arrowData.direction == DIRECTION.RIGHT)
        {
            arrowImg.gameObject.transform.Rotate(0, 0, 270);
            return;
        }
        if (arrowData.direction == DIRECTION.UP)
        {
            arrowImg.gameObject.transform.Rotate(0, 0, 0);
            return;
        }
        if (arrowData.direction == DIRECTION.LEFT)
        {
            arrowImg.gameObject.transform.Rotate(0, 0, 90);
            return;
        }
    }
    
    private void Update()
    {
        if (isCorrected)
        {
            transform.Translate(Vector3.up * 100 * Time.deltaTime);

            alphaValue -= Time.deltaTime;

            if (alphaValue >= 0)
            {
                DecreaseImageAlpha(alphaValue);
            }        
        }
    }
    
    #endregion

    #region PUBLIC METHODS
    public void ArrowCorrected(GameObject obj)
    {
        this.gameObject.transform.SetParent(obj.transform);
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        isCorrected = true;
    }

    #endregion

    #region  PRIVATE METHODS

    private void DecreaseImageAlpha(float value)
    {
        arrowImg.color = new Color(arrowImg.color.r, arrowImg.color.g, arrowImg.color.b, value);      
    }

    #endregion
    
   
}
