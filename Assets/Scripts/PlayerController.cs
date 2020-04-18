using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float buttonSensivity = 0.2f;
    private float rollDuration = 0.25f;
    private bool canStartRolling = true;

    public Transform pivotObject;

    void Start()
    {

    }


    void Update()
    {
        if (canStartRolling)
        {
            if (Input.GetAxis("Horizontal") > buttonSensivity)
            {
                StartCoroutine(Roll(Vector3.right));
                return;
            }

            if (Input.GetAxis("Horizontal") < -buttonSensivity)
            {
                StartCoroutine(Roll(Vector3.left));
                return;
            }

            if (Input.GetAxis("Vertical") > buttonSensivity)
            {
                StartCoroutine(Roll(Vector3.forward));
            }

            if (Input.GetAxis("Vertical") < -buttonSensivity)
            {
                StartCoroutine(Roll(Vector3.back));
            }

            bool movedInX = Mathf.Abs(Input.GetAxis("Horizontal")) > buttonSensivity;
            bool movedInY = Mathf.Abs(Input.GetAxis("Vertical")) > buttonSensivity;

            if (movedInX || movedInY)
            {
                StartCoroutine(WaitThenCanRoll());
            }
        }
    }

    private IEnumerator WaitThenCanRoll()
    {
        canStartRolling = false;
        yield return new WaitForSeconds(rollDuration);
        canStartRolling = true;
    }

    bool isVertical;

    private IEnumerator Roll(Vector3 direction)
    {
        yield return null;

        float halfWidthX = transform.localScale.x / 2;
        float halfWidthZ = transform.localScale.z / 2;

        Vector3 pointAround = transform.position + (Vector3.down * halfWidthZ) + (direction * halfWidthX);

        pivotObject.transform.position = pointAround;

        Debug.Log(pointAround);
    }

    //private IEnumerator Roll(Vector3 direction)
    //{
    //    canStartRolling = false;

    //    float rollDecimal = 0;
    //    float rollAngle = 90;


    //    float halfWidthx = transform.localScale.x / 2;
    //    float halfWidthz = transform.localScale.z / 2;



    //    Vector3 pointAround = transform.position + (Vector3.down * halfWidthz) + (direction * halfWidthx);
    //    //Debug.Log(pointAround);
    //    //Debug.Break();

    //    Vector3 rollAxis = Vector3.Cross(Vector3.up, direction);
    //    Debug.Log("direction " + direction);
    //    Debug.Log("rollAxis " + rollAxis);

    //    Quaternion rotation = transform.rotation;
    //    Quaternion endRotation = rotation * Quaternion.Euler(rollAxis * rollAngle);
    //    Vector3 endPosition = transform.position + direction;

    //    float oldAngle = 0;

    //    while (rollDecimal < rollDuration)
    //    {
    //        yield return new WaitForEndOfFrame();

    //        rollDecimal += Time.deltaTime;
    //        float newAngle = (rollDecimal / rollDuration) * rollAngle;
    //        float rotateThrough = newAngle - oldAngle;
    //        oldAngle = newAngle;



    //        transform.RotateAround(pointAround, rollAxis, rotateThrough);
    //    }

    //    //transform.position = endPosition;
    //    //transform.rotation = endRotation;

    //    canStartRolling = true;
    //}

}
