
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class ControleOrbital : MonoBehaviour
{

    private float vertical;
    private float horizontal;

    Vector2?[] oldTouchPositions = {
        null,
        null
    };

    private float speed = 4.0f;


    void Update()
    {
        // only go on if the touchets are within the allowed range


        // we need that small work around to
        Touch[] myTouches = Input.touches;
        List<Touch> myTouchesFiltered = new List<Touch>();
        for (int i = 0; i < myTouches.Length; i++)
        {
            if(myTouches[i].position.x < Screen.width - Screen.width / 4)
            {
                myTouchesFiltered.Add(myTouches[i]);
            }
        }

        Touch[] touches = myTouchesFiltered.ToArray();

        if (touches.Length == 0)
        {
            oldTouchPositions[0] = null;
            oldTouchPositions[1] = null;
        }
        else if (touches.Length == 1)
        {
            if (oldTouchPositions[0] == null || oldTouchPositions[1] != null)
            {
                oldTouchPositions[0] = touches[0].position;
                oldTouchPositions[1] = null;
            }
            else
            {
                Debug.Log("Dragging Detected");
                Vector2 newTouchPosition = touches[0].position;

            
                //float dis = (Vector2.Distance((Vector2)oldTouchPositions[0], newTouchPosition)) / 4;

                Vector2 oldTouchPosition = (Vector2)(oldTouchPositions[0]);
                float dis = (newTouchPosition.x - oldTouchPosition.x)/10;


                if (((Vector2)oldTouchPositions[0])[0] < newTouchPosition[0])
                {
                    //Debug.Log("Left"); dunno if correct
                    vertical = (vertical - speed * dis) % 360;
                    transform.localRotation = Quaternion.AngleAxis(vertical, Vector3.down);
                    oldTouchPositions[0] = newTouchPosition;
                }
                else
                {
                    //Debug.Log("Right");
                    vertical = (vertical - speed * dis) % 360;
                    transform.localRotation = Quaternion.AngleAxis(-1*(vertical), Vector3.up);
                    oldTouchPositions[0] = newTouchPosition;
                }
            }
        }


    }
}
