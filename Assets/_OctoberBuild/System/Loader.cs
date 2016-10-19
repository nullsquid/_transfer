using UnityEngine;
using System.Collections;

namespace TransferManager
{
    public class Loader : MonoBehaviour
    {

        public GameManager gameManager;

        // Use this for initialization
        void Awake()
        {
            if (GameManager.instance == null)
            {
                Instantiate(gameManager);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
