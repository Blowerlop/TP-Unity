using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HardwareStatistics : MonoBehaviour
{
    #region Variables
    
    [SerializeField] private TMP_Text _fpsText;
    [SerializeField] private TMP_Text _cpuTemperatureText;
    [SerializeField] private TMP_Text _vramText;

    [SerializeField] private float _timerUpdate;
    private float _timer = 0;
    
    StringBuilder stringBuider = new StringBuilder();

    #endregion

    
    #region  Updates

    private void Update()
    {
        if (_timer < 0)
        {
            stringBuider.Clear();
            stringBuider.Append("Fps : ");
            
            int fps = Mathf.RoundToInt((1.0f / Time.deltaTime));
            
            stringBuider.Append(fps);

            
            _fpsText.text = stringBuider.ToString();
            _timer = _timerUpdate;
        }
        else
        {
            _timer -= Time.deltaTime;
        }

    }
    
    #endregion
}
