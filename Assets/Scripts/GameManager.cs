using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   [SerializeField]
   private GameObject[] characters;

   public static GameManager instance;

//For storing the character being selected
   private int _charIndex;
   public int CharIndex{
      get{
         return _charIndex;
      }
      set{
         _charIndex = value;
      }
   }

   /// <summary>
   /// Awake is called when the script instance is being loaded.
   /// </summary>
   void Awake()
   {
       if(instance == null){
         instance = this;
         DontDestroyOnLoad(gameObject);
       }
       else{
         Destroy(gameObject);
       }
   }
   
}
