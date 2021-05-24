using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexxle.Unity
{
    public class UnityDialogPages : MonoBehaviour
    {
        public GameObject contentPanel;

        public GameObject previousButtonComponents;
        public GameObject nextButtonComponents;

        private int currentPageIndex;
        private int childCount;

        private void Start()
        {
            currentPageIndex = 0;
            childCount = contentPanel.transform.childCount;

            foreach (Transform child in contentPanel.transform)
            {
                child.gameObject.SetActive(false);
            }
            contentPanel.transform.GetChild(0).gameObject.SetActive(true);

            if (childCount < 2)
            {
                previousButtonComponents.SetActive(false);
                nextButtonComponents.SetActive(false);
            }

        }

        public void PreviousPage()
        {
            contentPanel.transform.GetChild(currentPageIndex).gameObject.SetActive(false);
            currentPageIndex = (currentPageIndex - 1 < 0) ? childCount - 1 : currentPageIndex - 1;
            contentPanel.transform.GetChild(currentPageIndex).gameObject.SetActive(true);
        }

        public void NextPage()
        {
            contentPanel.transform.GetChild(currentPageIndex).gameObject.SetActive(false);
            currentPageIndex = (currentPageIndex + 1 >= childCount) ? 0 : currentPageIndex + 1;
            contentPanel.transform.GetChild(currentPageIndex).gameObject.SetActive(true);
        }
    }
}