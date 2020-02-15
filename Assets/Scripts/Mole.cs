using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mole : MonoBehaviour
{
   public AudioSource deadSound;
   public AudioSource fleeSound;
   private Animator _animator;
   private AudioSource _audioSource;
   private bool _isDead = false;
   
   public void Start()
   {
      _animator = transform.GetComponent<Animator>();
      _audioSource = transform.GetComponent<AudioSource>();
   }
   public void Dead()
   {
      if (_isDead)
      {
         return;
      }
      _animator.SetBool("isDead", true);
      _audioSource.Play();
      _isDead = true;

      StartCoroutine("Disappear");
   }

   IEnumerator Disappear()
   {
      yield return new WaitForSeconds(.5f);
      transform.gameObject.SetActive(false);
   }

   public bool IsDead => _isDead;
   
}
