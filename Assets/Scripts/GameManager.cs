using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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

    private void OnEnable()
   {
      SceneManager.sceneLoaded += OnLevelFinishedLoading;
   }
    private void OnDisable()
   {
      SceneManager.sceneLoaded -= OnLevelFinishedLoading;
      
   }

   void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode){
      if(scene.name == "Gameplay"){
         Instantiate(characters[CharIndex]);
      }
   }
   
}
