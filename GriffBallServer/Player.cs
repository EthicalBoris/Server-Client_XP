using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GriffBallServer
{
    class Player
    {
        public Player(int id, String name)
        {
            this.id = id;
            this.name = name;
            this.hasBall = false;
        }

        public int id { get; }
        public String name { get; }
        public Boolean hasBall { get; set; }


    }
}
