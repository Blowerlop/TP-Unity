using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class IKBehaviour : MonoBehaviour
{
    [SerializeField] private Transform[] _bones;
    [SerializeField] private float _nbBonesLimit;

    [SerializeField] public Transform _target;
    [SerializeField] private float _blending;

    private void LateUpdate()
    {
        doCCD(_target.position, _blending);
    }

    private void doCCD(Vector3 targetPos, float blending)
    {
        for (int i = 1; i < _bones.Length && i <= _nbBonesLimit; i++)
        {
            Vector3 directionActuelle = (_bones[0].position - _bones[i].position).normalized;
            Vector3 directionDesiree = (targetPos - _bones[i].position).normalized;
            Quaternion rotation = Quaternion.FromToRotation(directionActuelle, directionDesiree.normalized);
            _bones[i].rotation = Quaternion.Lerp(_bones[i].rotation, (rotation) * _bones[i].rotation, blending);
        }
    }
}
