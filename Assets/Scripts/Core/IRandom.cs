using System;
using System.Collections.Generic;
using UnityEngine;

namespace StoryOfRandom.Core
{
    public interface IRandom
    {
        Vector2 RandomRange { get; set; }
        
        //This is for live demo purposes so I could press generate multiple times 
        //and have a method to clear the old generated objects for me :)
        List<GameObject> TrackedObjects { get; set; } 
        
        void Generate();
        void Clear();
    }
}