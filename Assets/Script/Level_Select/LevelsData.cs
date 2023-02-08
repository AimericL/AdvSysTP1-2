using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelsData : ScriptableObject
{
  [System.Serializable]
  
  public struct Level
    {
        public string Name;
        public string Descripton;
        public Sprite StarIcon;
        public string SceneName;
    }
    public List<Level> Levels = new List<Level>();
}
