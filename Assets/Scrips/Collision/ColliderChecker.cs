using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColliderChecker : MonoBehaviour
{
    [SerializeField] private Image borderImage;
    [SerializeField] private ArrowsController arrowControllerData;
    [SerializeField] private HorizontalLayoutGroup layout;
    
    private Color defaultColor;
    public bool arrowTouched;

    #region Awake & Start & Update
    private void Awake()
    {
        defaultColor = borderImage.color;
    }
    
    #endregion
    
    #region COLLISIONS
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (layout.enabled == true)
        {
            layout.enabled = false;
        }

        var arrow = collision.GetComponent<Arrow2D>();
        arrowControllerData.selectedArrow = arrow;
        arrowControllerData.arrowData = arrow.arrowData;

        arrowTouched = true;      
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        arrowControllerData.arrowData = null;
        arrowTouched = false;

        if (other.GetComponent<Arrow2D>().isLastArrow)
        {
            Invoke(nameof(TriggerLevelEnd), 2f);
        }
    }
    #endregion

    #region PUBLIC METHODS
    public void ChangeBorderColor(Color value)
    {       
        StartCoroutine(ChangeColorDelay(value));
    }
    #endregion
    #region PRIVATE METHODS

    private IEnumerator ChangeColorDelay(Color value)
    {
        borderImage.color = value;
        yield return new WaitForSeconds(0.5f);
        borderImage.color = defaultColor;
    }

    private void TriggerLevelEnd()
    {
        LevelEndCheck.instance.levelEndAction();
    }
    #endregion
}
