using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurvedText : MonoBehaviour
{
    public float curveIntensity = 0.1f;  // Adjust the intensity of the curve
    public float curveSpeed = 1f;        // Adjust the speed of the curve

    private TextMeshProUGUI textMeshPro;

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        BendText();
    }

    void BendText()
    {
        float curve = Mathf.Sin(Time.time * curveSpeed) * curveIntensity;

        Matrix4x4 matrix = textMeshPro.transform.localToWorldMatrix;
        Vector3[] vertices = textMeshPro.textInfo.meshInfo[0].vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 relativePos = matrix.MultiplyPoint3x4(vertices[i]);
            relativePos.y += curve * Mathf.Sin(relativePos.x);
            vertices[i] = matrix.inverse.MultiplyPoint3x4(relativePos);
        }

        textMeshPro.UpdateVertexData();
    }
}
