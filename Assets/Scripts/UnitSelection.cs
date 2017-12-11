﻿// Author: André Schoul

using UnityEngine;

public class UnitSelection : MonoBehaviour
{
    public static bool setEnemySelection = false;
    public static bool setHeroSelection = false;
    public static GameObject detectedEnemy;
    public static GameObject detectedHero;
    public static GameObject enemySelector;
    public static GameObject heroSelector;

    void OnMouseEnter() {
        //DetectTarget();
    }

    void OnMouseDown() {
        DetectTarget();
    }

    void OnMouseExit() {
        //DetectTarget(false);
    }

    public static void DetectTarget() {
        if(JNRCharacterController.isInFight) { 
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, GameObject.Find("Main Camera").transform.position.z * -1)), Vector2.zero);
            if (hit.collider != null) {
                if (hit.collider.gameObject.tag == "Enemy") {
                    if (detectedEnemy == null) {
                        detectedEnemy = hit.collider.gameObject;
                        enemySelector = detectedEnemy.transform.Find("Selector").gameObject;
                        enemySelector.SetActive(true);
                        setEnemySelection = true;
                    } else {
                        if (detectedEnemy == hit.collider.gameObject) {
                            enemySelector = detectedEnemy.transform.Find("Selector").gameObject;
                            if (!setEnemySelection) {
                                enemySelector.SetActive(true);
                                setEnemySelection = true;
                            } else {
                                enemySelector.SetActive(false);
                                setEnemySelection = false;
                            }
                        } else {
                            enemySelector = detectedEnemy.transform.Find("Selector").gameObject;
                            enemySelector.SetActive(false);
                            detectedEnemy = hit.collider.gameObject;
                            enemySelector = detectedEnemy.transform.Find("Selector").gameObject;
                            enemySelector.SetActive(true);
                            setEnemySelection = true;
                        }
                    }
                }/*
                if (hit.collider.gameObject.tag == "Hero") {
                    if (detectedHero == null) {
                        detectedHero = hit.collider.gameObject;
                        heroSelector = detectedHero.transform.Find("Selector").gameObject;
                        heroSelector.SetActive(true);
                        setHeroSelection = true;
                    } else {
                        if (detectedHero == hit.collider.gameObject) {
                            heroSelector = detectedHero.transform.Find("Selector").gameObject;
                            if (!setHeroSelection) {
                                heroSelector.SetActive(true);
                                setHeroSelection = true;
                            } else {
                                heroSelector.SetActive(false);
                                setHeroSelection = false;
                            }
                        } else {
                            heroSelector = detectedHero.transform.Find("Selector").gameObject;
                            heroSelector.SetActive(false);
                            detectedHero = hit.collider.gameObject;
                            heroSelector = detectedHero.transform.Find("Selector").gameObject;
                            heroSelector.SetActive(true);
                            setHeroSelection = true;
                        }
                    }
                }*/
            }
        }
    }
}