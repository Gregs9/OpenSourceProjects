using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectChallenge102.Klasses
{

    // Interface
    // Author: Lien Peeters
    // Date: 08/04/2015
    interface IGameLogic
    {
        void move();  //geen public etc in interface
        void wallCheck(int i);
        void draw(int i);

    }


}
