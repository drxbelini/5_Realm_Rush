using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]

public class SnapOnGrid : MonoBehaviour
{
    [SerializeField] [Range(1f,20f)] float gridSeize = 10f;

    TextMesh textMesh;
    

    // Update is called once per frame
    void Update()
    {
        Vector3 SnapPos;

        SnapPos.x = Mathf.Round(transform.position.x / gridSeize) * gridSeize;
        SnapPos.z = Mathf.Round(transform.position.z / gridSeize) * gridSeize;

        transform.position = new Vector3(SnapPos.x, 0f, SnapPos.z);

        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = SnapPos.x / gridSeize + "," + SnapPos.z / gridSeize;


    }
}
