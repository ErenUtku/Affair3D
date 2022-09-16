using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoCreator : MonoBehaviour
{
    [SerializeField] private ArrowsController arrowController;
    [SerializeField] private RectTransform photoObject;
    [SerializeField] private GameObject photoFolder;
    [SerializeField] private GameObject rectFolder;
    [SerializeField] private List<RectTransform> rectTransformList;
    
    private int arrowCount;
    

    private void Start()
    {
        arrowCount = arrowController.arrowCount;
        CreateRectTransforms();
    }

    public void CreatePhoto(ArrowData arrowData)
    {
        var PhotoObject = Instantiate(photoObject, photoFolder.transform, false);
        var photoController = PhotoObject.GetComponent<PhotoMovement>();


        photoController.ChangeSprite(arrowData.photoSprite);
        
        int random = Random.Range(0, rectTransformList.Count);
        photoController.targetPosition = rectTransformList[random];

        
        rectTransformList.RemoveAt(random);
    }

    private void CreateRectTransforms()
    {
        for (int i = 0; i < arrowCount; i++)
        {
            int xPos = Random.Range(-250, 310);
            int yPos = Random.Range(-130, 630);

            var randomObject = Instantiate(photoObject, rectFolder.transform, false);
            randomObject.anchoredPosition = new Vector2(xPos, yPos);

            var image = randomObject.GetComponent<Image>();
            image.color= new Color(image.color.r, image.color.g, image.color.b, 0f);

            rectTransformList.Add(randomObject);

        }
    }
}
