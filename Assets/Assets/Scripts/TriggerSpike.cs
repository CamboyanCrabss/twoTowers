using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpike : MonoBehaviour
{

        public GameObject spikes; // Asigna el objeto de los picos en el inspector

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                // Verifica si el objeto spikes tiene el componente spikesFunctions
                SpikesFunctions spikesFunctions = spikes.GetComponent<SpikesFunctions>();

                if (spikesFunctions != null)
                {
                    // Llama a la función spikesOut del componente spikesFunctions
                    spikesFunctions.SpikesOut();
                }
            }
        }

        private void OnTriggerExit(Collider collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                // Verifica si el objeto spikes tiene el componente spikesFunctions
                SpikesFunctions spikesFunctions = spikes.GetComponent<SpikesFunctions>();

                if (spikesFunctions != null)
                {
                    // Llama a la función spikesIn del componente spikesFunctions
                    spikesFunctions.SpikesIn();
                }
            }
        }
}
