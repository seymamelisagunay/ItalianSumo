using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public TMP_Text uiScore;
    public TMP_Text HUDPoint = null;
    
    private static int _score = 0;
    private static TMP_Text _uiScore;
    private static TMP_Text _HUDPoint;


    private void Start()
    {
        _uiScore = uiScore;
        _HUDPoint = HUDPoint;
        
    }
    
    public static void GetPoint(int point, GameObject gameObject)
    {
        
        _score += point;
        _uiScore.text = _score.ToString();
        _HUDPoint.text = point.ToString();
        _HUDPoint.gameObject.SetActive(true);
        _HUDPoint.transform.DOScale(Vector3.zero, 2f).SetEase(Ease.OutQuint).OnComplete(() =>
        {
            _HUDPoint.gameObject.SetActive(false);
        });
        _HUDPoint.transform.localScale = new Vector3(1,1,1);
        
        Vector3 targetPleyerScale = gameObject.transform.localScale + (Vector3.one * point * 0.0005f);
        gameObject.transform.DOScale(targetPleyerScale,0.8f);
    }
    
    
}
