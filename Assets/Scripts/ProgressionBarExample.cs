using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressionBarExample : MonoBehaviour
{
    //Variables
    //Progression bar related variables
    [SerializeField] RectTransform backgroundBar;
    [SerializeField] RectTransform currentProgression;

    [SerializeField][Range(0, 1)] float progressValue;

    private float startD;
    private float middleX;
    private float middleY;

    //Checkpoint related variables
    [SerializeField] Transform player;
    [SerializeField] Transform endPosition;


    void Start()
    {
        startD = Mathf.Sqrt(Mathf.Pow(endPosition.position.x - player.position.x, 2) + Mathf.Pow(endPosition.position.y - player.position.y, 2));
        middleX = ((player.position.x + endPosition.position.x) / 2);
        middleY = ((player.position.y + endPosition.position.y) / 2);   //will be used when we've calculated y position progression
    }

    void Update()
    {
        //Whole distance value
        float distance = Mathf.Sqrt(Mathf.Pow(endPosition.position.x - player.position.x, 2) + Mathf.Pow(endPosition.position.y - player.position.y, 2));
        float position = (backgroundBar.rect.width - currentProgression.rect.width) * progressValue;
        progressValue = 1 - (distance / startD);


        //middle distance value

        if (startD == progressValue/2 || player.position.y == middleY)
        {
            Debug.Log("yes, halfway there gandalfs mamma");
        }


        // Denna metoden förflyttar currentProgression (den röda kuben) position är förflyttningen längs progression-baren.
        currentProgression.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, position, currentProgression.rect.width);
    }
}