using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelsData : ScriptableObject
{
        public string Name;
        public List<string> DescriptonText;
        public List<Sprite> StarIcon;
        public string SceneName;
}
