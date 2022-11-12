using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NoiseStatus))]
public class ObjectStealing : MonoBehaviour
{
    private Transform _cameraTransform;
    private NoiseStatus _noiseStatus;
    [SerializeField] private float _grabbingDistance = 2.0f;
    [SerializeField] private LayerMask _grabbingLayerMask;

    [SerializeField] private AudioClip _stealSound;
    
    [SerializeField] private GameObject _UI;

    [SerializeField] private IKBehaviour _ikBehaviour;
    [SerializeField] private GameObject _character;

    private GameObject _target;

    private void Awake()
    {
        _cameraTransform = Camera.main.transform;
        _noiseStatus = GetComponent<NoiseStatus>();
    }

    private void Update()
    {
        if (Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out RaycastHit hit, _grabbingDistance, _grabbingLayerMask))
        {
            UIEnabled(true);
            if (InputManager.instance.isUsing)
            {
                _character.SetActive(true);
                
                StartCoroutine(MakeSound());
                _target = hit.transform.gameObject;
                AudioManager.instance.PlaySound(_stealSound);
                UIEnabled(false);
            }
        }
        else
        {
            _target = null;
            UIEnabled(false);
        }
        
        InputManager.instance.isUsing = false;
    }

    private IEnumerator MakeSound()
    {
        Debug.Log("Start Corountine");
        _noiseStatus.NoiseLevel = 1;
        yield return new WaitForSeconds(0.1f);
        _noiseStatus.NoiseLevel =0;
    }

    private void UIEnabled(bool state)
    {
        _UI.SetActive(state);
    }

    public void Steal(GameObject target)
    {
        Destroy(target);
    }
    
    
}
