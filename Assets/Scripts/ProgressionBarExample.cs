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

    [SerializeField][Range(0, 100)] float progressionValue;

    //Checkpoint related variables
    [SerializeField] Transform player;
    [SerializeField] Transform endPosition;

    private float startD;
    private float distanceTraveled;

    void Start()
    {
        startD = Mathf.Sqrt(Mathf.Pow(endPosition.transform.position.x - player.position.x, 2) + Mathf.Pow(endPosition.transform.position.y - player.position.y, 2));
    }

    void Update()
    {
        float distance = Mathf.Sqrt(Mathf.Pow(endPosition.transform.position.x - player.position.x, 2) + Mathf.Pow(endPosition.transform.position.y - player.position.y, 2));
        float progressUpdate = 1 - (distance / startD);
        float position = (backgroundBar.rect.width - currentProgression.rect.width) * progressUpdate;

        //Whole distance
        progressionValue = progressUpdate;

        //middle distance



        // Denna metoden förflyttar currentProgression (den röda kuben) position är förflyttningen längs progression-baren.
        currentProgression.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, position, currentProgression.rect.width);
    }
}