using AVClub.Bases;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using AVClub.UI;
using AVClub.Managers;

namespace AVClub
{
    public class LorePoint : BaseInteractable
    {
        public TMP_Text loreText;
        [HideInInspector] public TMP_Text loreTextObject;
        [HideInInspector] public GameObject loreTextParent;

        private void Start()
        {
            loreTextObject = GameManager.instance._gUi.loreText;
            loreTextParent = GameManager.instance._gUi.ltParent.gameObject;

            loreText.gameObject.SetActive(false);
        }

        public override void OnEnter(Collider other)
        {
            base.OnEnter(other);

            loreTextParent.SetActive(true);
            loreTextObject.text = loreText.text;
        }

        public override void OnExit()
        {
            base.OnExit();

            loreTextParent.SetActive(false);
        }
    }
}
