using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoMovement : MonoBehaviour
{
    public Image image;
    public RectTransform targetPosition;
    public LevelEndCheck levelEnd;
    private Vector2 newTarget;
    public bool startMove;

    private void Start()
    {
        levelEnd = LevelEndCheck.instance;

        levelEnd.levelEndAction += MoveToTarget;

        RandomRotation();
    }
    public void ChangeSprite(Sprite value)
    {
        image.sprite = value;
    }

    private void RandomRotation()
    {
        float randomRotation = Random.Range(-15, 15);
        var rotation = image.transform.rotation;
        image.transform.Rotate(rotation.x, rotation.x, randomRotation);
    }

    private void Update()
    {
        if (startMove)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition =
                Vector2.Lerp(gameObject.GetComponent<RectTransform>().anchoredPosition
                    , newTarget, Time.deltaTime * 2);
        }
    }
    private void MoveToTarget()
    {
        var anchoredPosition = targetPosition.anchoredPosition;
        newTarget = new Vector2(anchoredPosition.x,
            anchoredPosition.y);
        startMove = true;
    }
}
