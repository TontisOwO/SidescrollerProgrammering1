using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BlockScript : MonoBehaviour
{

    public Vector2 Dimensions = new Vector2(16.0f, 16.0f);
    public Vector2 LowerLeftCorner = new Vector2();
    void Update()
    {
        LowerLeftCorner = new Vector2(transform.position.x - (Dimensions.x * 0.5f),
            transform.position.y - (Dimensions.y * 0.5f));
    }
    public static bool CheckCollision(BlockScript aObject1, BlockScript aObject2)
    {
        if (aObject1.LowerLeftCorner.x < aObject2.LowerLeftCorner.x + aObject2.Dimensions.x &&
            aObject1.LowerLeftCorner.x + aObject1.Dimensions.x > aObject2.LowerLeftCorner.x &&
            aObject1.LowerLeftCorner.y < aObject2.LowerLeftCorner.y + aObject2.Dimensions.y &&
            aObject1.LowerLeftCorner.y + aObject2.Dimensions.y < aObject2.LowerLeftCorner.y)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}