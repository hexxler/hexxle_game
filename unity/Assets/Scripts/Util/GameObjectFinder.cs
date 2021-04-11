using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Util
{
    public class GameObjectFinder
    {
        // Canvas
        public static GameObject UICanvas => GameObject.FindGameObjectWithTag("UI");
        public static GameObject PauseCanvas => GameObject.FindGameObjectWithTag("Pause");

        // Panels
        public static GameObject UIPanel => UICanvas.transform.GetChild(0).gameObject;
        public static GameObject PausePanel => PauseCanvas.transform.GetChild(0).gameObject;
        public static GameObject PauseModal => PausePanel.transform.GetChild(2).gameObject;
        public static GameObject InfoPanel => PauseModal.transform.GetChild(1).gameObject;

        // Others
        public static GameObject Stack => GameObject.FindGameObjectWithTag("Stack");
        public static GameObject Points => GameObject.FindGameObjectWithTag("Points");
    }
}