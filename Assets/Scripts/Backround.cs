using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backround : MonoBehaviour
{
    public MeshRenderer mr;
    public bool Follow;
    public Vector2 Mutliplier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Follow == false)
        {
            Material mat = mr.material;
            Vector2 offset = mat.mainTextureOffset;
            offset.x += Time.deltaTime;
            mat.mainTextureOffset = offset;
        }
        else
        {
            Material mat = mr.material;
            Vector2 offset = mat.mainTextureOffset;
            offset.x = transform.position.x * Mutliplier.x;
            offset.y = transform.position.y * Mutliplier.y;
            mat.mainTextureOffset = offset;
        }
        
    }
}
