using UnityEditor;
using UnityEngine;

namespace EZRP
{
    [CreateAssetMenu(fileName = "NewRichPresenceItem", menuName = "Discord Rich Presence/Rich Presence Item")]
    public class RichPresenceItem : ScriptableObject
    {
        public string Details;
        public string State;
        public string LargeImageKey;
        public string LargeImageText;
        public string SmallImageKey;
        public string SmallImageText;
    }
}