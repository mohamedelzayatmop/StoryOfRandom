using System.Collections.Generic;
using StoryOfRandom.Core;
using UnityEngine;
using NaughtyAttributes;

namespace StoryOfRandom.Behaviours
{
    public class CubeGeneratorBehaviour : MonoBehaviour
    {
        [SerializeField]
        [Dropdown("GetRandomAlgorithmsList")]
        private ScriptableObject RandomAlgorithm;
        
        [ReorderableList]
        [SerializeField]
        private List<ScriptableObject> RandomScriptableObjects;
        
        private IRandom PreviouslyChosenAlgorithm { get; set; }
        
        private DropdownList<ScriptableObject> GetRandomAlgorithmsList() //This is for picking algorithm from editor
        {
            return new DropdownList<ScriptableObject>()
            {
                { "Boring", RandomScriptableObjects[0] },
                { "With rule", RandomScriptableObjects[1] },
                { "LFSR", RandomScriptableObjects[2] },
                { "Random colors", RandomScriptableObjects[3] },
                { "Shuffle bag", RandomScriptableObjects[4] },
                { "Noise random", RandomScriptableObjects[5] },
                { "Markov chain", RandomScriptableObjects[6] },
            };
        }

        private void Start()
        {
            PreviouslyChosenAlgorithm = (IRandom)RandomAlgorithm;
        }


        [Button("Generate")]
        private void Generate()
        {
            PreviouslyChosenAlgorithm.Clear();
            
            var ChosenAlgorithm = (IRandom)RandomAlgorithm;
            ChosenAlgorithm.Generate();

            PreviouslyChosenAlgorithm = ChosenAlgorithm;
        }
    }
}
