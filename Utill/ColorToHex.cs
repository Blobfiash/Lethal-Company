using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SpectralWave.Utill
{
    public static class SpectralWaveUtil
    {
        public static string ColorToHex(Color color)
        {
            int r = Mathf.RoundToInt(color.r * 255); 
            int g = Mathf.RoundToInt(color.g * 255);
            int b = Mathf.RoundToInt(color.b * 255);
            return r.ToString("X2") + g.ToString("X2") + b.ToString("X2");
        }
    }
}
