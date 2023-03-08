using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EndGame : MonoBehaviour
{

    public List<GameObject> endGameObjects;
    public int currentLevel = 1;
    private bool endGame = false;
    private void Awake()
    {
        endGameObjects.ForEach(i => i.SetActive(false));
    }
    private void OnTriggerEnter(Collider other)
    {
        Player p = other.GetComponent<Player>();

        if(!endGame && p != null)
        {
            ShowEndGame();
        }
    }

    private void ShowEndGame()
    {
        endGame = true;
        endGameObjects.ForEach(i => i.SetActive(true));
        foreach(var i in endGameObjects)
        {
            i.transform.DOScale(0, .2f).SetEase(Ease.OutBack).From();
            SaveManager.Instance.SaveLastLevel(currentLevel);
        }
    }
}
