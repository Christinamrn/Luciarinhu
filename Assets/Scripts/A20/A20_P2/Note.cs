using UnityEngine;

public class Note : MonoBehaviour
{
    public int midiNoteNumber = 60; // Corresponds to C4 (middle C)
    public float duration = 1.0f; // Duration of the note in seconds
    private float sampleRate = 44100.0f; // Audio sample rate
    public float gain = 0.5f; // Volume of the note

void OnMouseDown()
    {
        // Generate a sine wave at the frequency corresponding to the MIDI note number
        float frequency = 440.0f * Mathf.Pow(2.0f, (midiNoteNumber - 69) / 12.0f);
        int numSamples = Mathf.RoundToInt(duration * sampleRate);
        float[] samples = new float[numSamples];

        // Apply an amplitude envelope to the generated samples
        for (int i = 0; i < numSamples; i++)
        {
            float t = (float)i / sampleRate;
            float envelope = Mathf.Lerp(1.0f, 0.0f, t / duration); // Linear fade-in envelope
            samples[i] = gain * envelope * Mathf.Sin(2.0f * Mathf.PI * frequency * t);
        }

        // Create an AudioClip from the generated samples
        AudioClip clip = AudioClip.Create("Note", numSamples, 1, Mathf.RoundToInt(sampleRate), false);
        clip.SetData(samples, 0);

        // Play the AudioClip
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
}
