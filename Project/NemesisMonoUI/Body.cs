using BoardGraph;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLib;
using System.Collections.Generic;

namespace NemesisMonoUI
{
    public class Body 
    {
        public BodyPart head;
        public BodyPart torso;
        public BodyPart rArm;
        public BodyPart lArm;
        public BodyPart rLeg;
        public BodyPart lLeg;
        public BodyPart extras;
        public List<BodyPart> bodyparts;

        public Body()
        {
            head = new Helmet(0,-10);
            //torso = new BodyPart();
            //rArm = new BodyPart();
            //lArm = new BodyPart();
            //rLeg = new BodyPart();
            //lLeg = new BodyPart();
            //extras = new BodyPart();
            bodyparts = new List<BodyPart>();
            bodyparts.Add(head, torso, rArm, lArm, rLeg, lLeg, extras);
        }

        
    }
}