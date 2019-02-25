using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NemesisLibrary
{
    public static class NoiseDescriptions
    {
        public static string RoomNoiseDescription(this int noiselevel)
        {
            string description;
            switch (noiselevel)
            {
                case 0:
                    description = "max noise";
                    break;
                case 1:
                    description = "high noise";
                    break;
                case 2:
                    description = "medium noise";
                    break;
                default:
                    description = "low noise";
                    break;
            }
            return description;
        }

        public static string MaxNoise()
        {
            return "slithering and scraping sounds not common to the ship...";
        }

        public static string HighNoise()
        {
            return "noises that might or might not be mechanical.";
        }

        public static string MediumNoise()
        {
            return "leaking steam pipes whistling and working piston pumps and possibly something else...";
        }

        public static string LowNoise()
        {
            return "the omnipresent hum of the ship generator.";
        }
    }
}
