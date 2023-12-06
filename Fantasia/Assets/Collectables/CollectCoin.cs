using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
  void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Moneta"))
    {
      RaccogliMoneta(other.gameObject);
        Debug.Log("monetina presa");
    }
  }
    
  void RaccogliMoneta(GameObject moneta)
  {
    // Aggiungi qui la logica di raccolta della moneta
    // Ad esempio, incrementa il punteggio del giocatore, disattiva la moneta, ecc.
    moneta.SetActive(false);
  }
}
