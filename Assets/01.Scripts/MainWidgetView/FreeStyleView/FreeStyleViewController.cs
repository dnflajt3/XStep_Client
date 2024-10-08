﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeStyleViewController : MonoBehaviour
{
    [SerializeField]
    private SongItem[] songItems;

    [SerializeField]
    private Transform sortPivotObject;

    private void Start(){

    }

    private void Update(){
        if(GameManager.instance.touchManager.IsSwipe){
            if(GameManager.instance.touchManager.SwipeDirection.y > 0.8f){
                if(songItems[songItems.Length - 1].gameObject.transform.position.y < sortPivotObject.position.y){
                    MoveObjects(Vector2.up);
                }
            }
            else if(GameManager.instance.touchManager.SwipeDirection.y < -0.8f){
                if(songItems[0].gameObject.transform.position.y > sortPivotObject.position.y){
                    MoveObjects(Vector2.down);
                }
            }
        }
    }

    private void MoveObjects(Vector2 direction){
        foreach (SongItem item in songItems)
        {
            item.transform.Translate(direction * 0.5f);
        }
    }
}
