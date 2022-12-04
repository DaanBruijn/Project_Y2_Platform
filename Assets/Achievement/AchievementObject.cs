using UnityEngine;

namespace Achievement
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AchievementObjectScriptableObject", order = 1)]
    public class AchievementObject : ScriptableObject
    {
        public string achievementName;
        public string playerPrefName;
    }
}