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
                    description = "slithering and scraping sounds not common to the ship...";
                    break;
                case 1:
                    description = "noises that might or might not be mechanical.";
                    break;
                case 2:
                    description = "leaking steam pipes whistling and working piston pumps and possibly something else...";
                    break;
                default:
                    description = "the omnipresent hum of the ship generator.";
                    break;
            }return description;
        }
    }
}
