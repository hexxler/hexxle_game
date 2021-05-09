using Hexxle.Unity.Audio;
using Hexxle.Unity.Input;
using UnityEngine;

namespace Hexxle.Unity.Util
{
    public class GameObjectFinder
    {
        // Canvas
        public static GameObject UICanvas => GameObject.FindGameObjectWithTag("UI");
        public static GameObject PauseCanvas => GameObject.FindGameObjectWithTag("Pause");

        // Panels
        public static GameObject UIPanel => UICanvas.transform.GetChild(0).gameObject;
        public static GameObject PausePanel => PauseCanvas.transform.GetChild(0).gameObject;
        public static GameObject InfoPanel => PausePanel.transform.GetChild(3).gameObject;
        public static GameObject GameOverPanel => PauseCanvas.transform.GetChild(1).gameObject;

        // Others
        public static GameObject Stack => GameObject.FindGameObjectWithTag("Stack");
        public static GameObject Points => GameObject.FindGameObjectWithTag("Points");

        public static UnityMap UnityMap => GameObject.FindGameObjectWithTag("Map").GetComponent<UnityMap>();
        public static UnityHand UnityHand => GameObject.FindGameObjectWithTag("Hand").GetComponent<UnityHand>();
        public static UnityPoints UnityPoints => GameObject.FindGameObjectWithTag("Points").GetComponent<UnityPoints>();
        public static UnityPossiblePoints UnityPossiblePoints => GameObject.FindGameObjectWithTag("Points").GetComponent<UnityPossiblePoints>();
        public static MouseEventsHandler MouseEventLogic => GameObject.Find("Game").GetComponent<MouseEventsHandler>();
        public static TileTurnEventHandler TileTurnEventLogic => GameObject.Find("Game").GetComponent<TileTurnEventHandler>();
        public static AudioManager AudioManager => Object.FindObjectOfType<AudioManager>();
    }
}