using System;
using System.Collections.Generic;

namespace avioane_final
{
    public enum cStareCelula { Goala, Avion, Umbra }
    public enum cOrientare { Sus, Jos, Stanga, Dreapta }
    internal class cCelula
    {
        public int mX { get; }
        public int mY { get; }
        public cStareCelula mStare { get; set; }

        public cCelula(int pX, int pY)
        {
            mX = pX;
            mY = pY;
            mStare = cStareCelula.Goala;
        }
    }
}
