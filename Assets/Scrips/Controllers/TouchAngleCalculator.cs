using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchAngleCalculator : MonoBehaviour
{
    [SerializeField] private ColliderChecker arrowChecker;
    private Vector3 startPosition;
    public float calculatedAngle=0;

    private void Update()
    {
        if (arrowChecker.arrowTouched)
        {

            if (Input.GetMouseButtonDown(0))
            {
                startPosition = Input.mousePosition;
            }

            if (!Input.GetMouseButtonUp(0)) return;
            
            Vector3 mouseDelta = Input.mousePosition - startPosition;

            if (mouseDelta.sqrMagnitude < 0.1f)
            {
                return; // don't do tiny rotations.
            }

            calculatedAngle = Mathf.Atan2(mouseDelta.y, mouseDelta.x) * Mathf.Rad2Deg;
            if (calculatedAngle < 0) calculatedAngle += 360;

            /*transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,
                                                          transform.localEulerAngles.y,
                                                          calculatedAngle);*/
        }
    }
}
