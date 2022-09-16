using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ArrowsController : MonoBehaviour
{
    [SerializeField] private Arrow2D[] allArrows;
    [SerializeField] private GameObject arrowSlider;
    [SerializeField] private ColliderChecker arrowChecker;
    [SerializeField] private TouchAngleCalculator angleCalculator;
    [SerializeField] private Animator womanAnimation;
    [SerializeField] private PhotoCreator photoCreation;

    [HideInInspector]
    public ArrowData arrowData;
    [HideInInspector]
    public Arrow2D selectedArrow;
    [HideInInspector]
    public GameObject correctedArrow;

    public int arrowCount;
    private int count=0;
    
    #region Awake & Start & Update
    private void Awake()
    {
        arrowCount = allArrows.Length;

        foreach (var arrow in allArrows)
        {
            count++;
            var createdArrow = Instantiate(arrow, arrowSlider.transform, false);
          
            if (arrowCount == count)
            {
                createdArrow.isLastArrow = true;
            }
            else
            {
                createdArrow.isLastArrow = false;
            }
        }
        
    }
    private void Update()
    {     
        if (arrowChecker.arrowTouched)
        {
            if (arrowData.direction == DIRECTION.RIGHT)
            {
                if ((angleCalculator.calculatedAngle <= arrowData.minAngle || angleCalculator.calculatedAngle >= arrowData.maxAngle ) && angleCalculator.calculatedAngle != 0)
                {
                    CorrectAnswer();
                }

                else
                {
                    if (angleCalculator.calculatedAngle != 0)
                    {
                        WrongAnswer();
                    }
                }
            }
            else
            {
                if (angleCalculator.calculatedAngle >= arrowData.minAngle && angleCalculator.calculatedAngle <= arrowData.maxAngle && angleCalculator.calculatedAngle != 0)
                {
                    CorrectAnswer();
                }
                else
                {
                    if (angleCalculator.calculatedAngle != 0)
                    {
                        WrongAnswer();
                    }
                }

            }
       
        }
    }
    #endregion
    
    #region PRIVATE METHODS

    private void CorrectAnswer()
    {
        //Photo
        photoCreation.CreatePhoto(arrowData);

        //Animation Control
        womanAnimation.SetTrigger(arrowData.animationString);

        //Arrow Corrected
        selectedArrow.ArrowCorrected(correctedArrow);

        //End
        angleCalculator.calculatedAngle = 0;
        arrowChecker.arrowTouched = false;

        //Reset
        arrowData = null;
        selectedArrow = null;

        //Border-Color
        arrowChecker.ChangeBorderColor(Color.green);
             
    }

    private void WrongAnswer()
    {
        arrowChecker.ChangeBorderColor(Color.red);
        angleCalculator.calculatedAngle = 0;
    }
    
    #endregion
    
}


