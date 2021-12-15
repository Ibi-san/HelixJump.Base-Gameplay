using UnityEngine;

namespace Assets.Scripts
{
    public class Platform : MonoBehaviour
    {
        public GameObject Destruction;

        public int DestroyedPlatform
        {
            get => PlayerPrefs.GetInt("DestroyedPlatform", 0);
            private set
            {
                PlayerPrefs.SetInt("DestroyedPlatform", value);
                PlayerPrefs.Save();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                player.CurrentPlatform = this;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var meshRenderers = gameObject.GetComponentsInChildren<MeshRenderer>();
            foreach (var meshRenderer in meshRenderers)
                    meshRenderer.enabled = false;

            if (Destruction)
            {
                GameObject destruction = (GameObject)Instantiate(Destruction, transform.position, Destruction.transform.rotation);
                Destroy(destruction, destruction.GetComponent<ParticleSystem>().main.startLifetimeMultiplier);
            }

            AudioSource _audio = GetComponent<AudioSource>();
            _audio.Play();

            DestroyedPlatform++;
        }
    }
}