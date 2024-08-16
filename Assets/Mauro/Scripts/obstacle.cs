using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obtacle : MonoBehaviour
{
    public List<Vector3> movePostions;
    public float moveSpeed;
    public int startIndex;

    private Vector3 moveStartPos, moveEndPos;
    private int moveStartIndex, moveEndIndex, totalMove;
    private Vector3 moveDiraction;
    private float moveDistance, currentMoveDistance, magnitude;
   

    public void Start()
    {
        magnitude = 1;
        currentMoveDistance = 0;
        totalMove = movePostions.Count;

        moveStartIndex = startIndex;
        moveEndIndex = (moveStartIndex + 1) % totalMove;  

        moveStartPos = movePostions[moveStartIndex];
        moveEndPos = movePostions[moveEndIndex];

        moveDiraction = (moveEndPos - moveStartPos).normalized;
        moveDistance = Vector3.Distance(moveEndPos, moveStartPos);

        transform.position = moveStartPos + currentMoveDistance * moveDiraction;

    }

    public void FixedUpdate()
    {
        if (currentMoveDistance > moveDistance)
        {
            currentMoveDistance = 0;
            moveStartIndex = (moveStartIndex + 1) % totalMove;
            moveEndIndex = (moveStartIndex + 1) % totalMove;

            moveStartPos = movePostions[moveStartIndex];
            moveEndPos = movePostions[moveEndIndex];

            moveDiraction = (moveEndPos - moveStartPos).normalized;
            moveDistance = Vector3.Distance(moveEndPos, moveStartPos);

        }

        else if (currentMoveDistance < 0f) 
        {
            currentMoveDistance = 0;
            moveStartIndex = (moveStartIndex - 1 +totalMove) % totalMove;
            moveEndIndex = (moveStartIndex + 1) % totalMove;

            moveStartPos = movePostions[moveStartIndex];
            moveEndPos = movePostions[moveEndIndex];

            moveDiraction = (moveEndPos - moveStartPos).normalized;
            moveDistance = Vector3.Distance(moveEndPos, moveStartPos);
            currentMoveDistance = moveDistance;
           

        }

        currentMoveDistance += moveSpeed * magnitude * Time.fixedDeltaTime;
        transform.position = moveStartPos + currentMoveDistance * moveDiraction;

    }


}
