using System.Collections.Generic;

namespace avioane_final
{
    class cAvion
    {
        public int mX { get; }
        public int mY { get; }
        public cOrientare mOrientare { get; }

        public cAvion(int pX, int pY, cOrientare pOrientare)
        {
            mX = pX;
            mY = pY;
            mOrientare = pOrientare;
        }

        public static List<(int, int)> ObtineFormaAvion(int pX, int pY, cOrientare pOrientare)
        {
            var forma = new List<(int, int)> { (pX, pY) }; // Capul avionului
            switch (pOrientare)
            {
                case cOrientare.Sus:
                    forma.AddRange(new List<(int, int)>
                    {
                        (pX, pY+1), (pX-1, pY+1), (pX+1, pY+1), // Aripi
                        (pX-2, pY+1), (pX+2, pY+1),
                        (pX, pY+2), // Corp
                        (pX, pY+3), (pX-1, pY+3), (pX+1, pY+3) // Coada
                    });
                    break;
                case cOrientare.Jos:
                    forma.AddRange(new List<(int, int)>
                    {
                        (pX, pY-1), (pX-1, pY-1), (pX+1, pY-1), // Aripi
                        (pX-2, pY-1), (pX+2, pY-1),
                        (pX, pY-2), // Corp
                        (pX, pY-3), (pX-1, pY-3), (pX+1, pY-3) // Coada
                    });
                    break;
                case cOrientare.Stanga:
                    forma.AddRange(new List<(int, int)>
                    {
                        (pX+1, pY), (pX+1, pY-1), (pX+1, pY+1), // Aripi
                        (pX+1, pY-2), (pX+1, pY+2),
                        (pX+2, pY), // Corp
                        (pX+3, pY), (pX+3, pY-1), (pX+3, pY+1) // Coada
                    });
                    break;
                case cOrientare.Dreapta:
                    forma.AddRange(new List<(int, int)>
                    {
                        (pX-1, pY), (pX-1, pY-1), (pX-1, pY+1), // Aripi
                        (pX-1, pY-2), (pX-1, pY+2),
                        (pX-2, pY), // Corp
                        (pX-3, pY), (pX-3, pY-1), (pX-3, pY+1) // Coada
                    });
                    break;
            }
            return forma;
        }
    }
}
