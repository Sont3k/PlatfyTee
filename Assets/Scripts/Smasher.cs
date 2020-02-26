using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slammer : MonoBehaviour
{
    public GameObject smashTarget;
    public Vector3 startPosition;
    public float smashSpeed, returnSpeed;

    private bool movingDown;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO

        // Moving down
        if (Vector3.Distance(PlayerController.instance.transform.position, smashTarget.transform.position) <= 2f)
        {
            movingDown = true;
            smashTarget.transform.parent = null;
        }

        if (movingDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, smashTarget.transform.position, smashSpeed * Time.deltaTime);

            if (transform.position == smashTarget.transform.position)
            {
                movingDown = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, returnSpeed * Time.deltaTime);
        }
    }
}
