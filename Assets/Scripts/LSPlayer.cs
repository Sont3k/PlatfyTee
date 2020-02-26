using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSPlayer : MonoBehaviour
{
    public MapPoint currentPoint;

    public float moveSpeed;

    private bool levelLoading;

    public LSManager theManger;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.transform.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentPoint.transform.position) < .1f && !levelLoading)
        {
            if (Input.GetAxisRaw("Horizontal") > .5f)
            {
                if (currentPoint.right != null)
                {
                    SetNextPoint(currentPoint.right);

                    AudioManager.instance.PlaySFX(5);
                }
            }

            if (Input.GetAxisRaw("Horizontal") < -.5f)
            {
                if (currentPoint.left != null)
                {
                    SetNextPoint(currentPoint.left);

                    AudioManager.instance.PlaySFX(5);
                }
            }

            if (Input.GetAxisRaw("Vertical") > .5f)
            {
                if (currentPoint.up != null)
                {
                    SetNextPoint(currentPoint.up);

                    AudioManager.instance.PlaySFX(5);
                }
            }

            if (Input.GetAxisRaw("Vertical") < -.5f)
            {
                if (currentPoint.down != null)
                {
                    SetNextPoint(currentPoint.down);

                    AudioManager.instance.PlaySFX(5);
                }
            }

            if(currentPoint.isLevel && currentPoint.levelToLoad != "" && !currentPoint.isLocked)
            {
                LSUIController.instance.ShowInfo(currentPoint);

                if(Input.GetButtonDown("Jump"))
                {
                    levelLoading = true;

                    theManger.LoadLevel();

                    AudioManager.instance.PlaySFX(4);
                }
            }
        }
    }

    public void SetNextPoint(MapPoint nextPoint)
    {
        currentPoint = nextPoint;
        LSUIController.instance.HideInfo();
    }
}
