using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SocialPlatforms.Impl;

public class GrapplerManager : MonoBehaviour
{
    public static GrapplerManager instance;

    [SerializeField] TMP_Text grapplerPiecesText;
    [SerializeField] Grappler grappler;
    GameObject piece;
    public static int takedGrapplerPieces = 0;

    private void Awake()
    {
        instance = this;
    }

    public void TakePiece()
    {
        takedGrapplerPieces++;
        grapplerPiecesText.text = "" + takedGrapplerPieces;
        if(takedGrapplerPieces >= 2) { 
            grappler.SetGrapplerAvailable(); }
        
    }
    private void Update()
    {
        piece = GameObject.Find("piece");
        if (takedGrapplerPieces >= 2)
        {
            Destroy( piece );
        }
    }

    public void ResetTakedPieces()
    {
        takedGrapplerPieces = 0;
    }
}
