using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class DestroyedPlatforms : MonoBehaviour
    {

        public Text Text;
        public Platform Platform;

        private void Update()
        {
            Text.text = Platform.DestroyedPlatform.ToString();
        }
    }
}