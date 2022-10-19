using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressionBarExample : MonoBehaviour
{
    //Variables
    [Header ("Progression related variables")]
    [SerializeField] RectTransform backgroundBar;
    [SerializeField] RectTransform currentProgression;

    [SerializeField][Range(0, 1)] float progressValue;
    
    [SerializeField] float progressionOffset;

    private float startD;
    private float middleX;
    private float middleY;

    [Header ("Checkpoint related variables")]
    [SerializeField] Transform player;
    [SerializeField] Transform endPosition;
    [SerializeField] Transform startPosition;


    void Start()
    {
        startD = Mathf.Sqrt(Mathf.Pow(endPosition.position.x - player.position.x, 2) + Mathf.Pow(endPosition.position.y - player.position.y, 2));
        middleX = Mathf.Abs((startPosition.position.x + endPosition.position.x) / 200);
        middleY = Mathf.Abs((startPosition.position.y + endPosition.position.y) / 200);   //will be used when we've calculated y position progression

        Debug.Log($"The whole distance from start: {startD}");
        Debug.Log($"Half of startd: {startD / 2} \n  Half according to the variable: {middleX}");
    }

    void Update()
    {
        //Whole distance value
        float distance = Mathf.Sqrt(Mathf.Pow(endPosition.position.x - player.position.x, 2) + Mathf.Pow(endPosition.position.y - player.position.y, 2));
        float position = (backgroundBar.rect.width - currentProgression.rect.width) * progressValue * progressionOffset;
        progressValue = 1 - (distance / startD);


        //middle distance value

        if (player.position.x == middleX || player.position.y == middleY)
        {
            Debug.Log("yes, halfway there");
        }


        // Denna metoden förflyttar currentProgression (den röda kuben) position är förflyttningen längs progression-baren.
        currentProgression.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, position, currentProgression.rect.width);
    }
}