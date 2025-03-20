using System;
using System.Collections.Generic;

namespace avioane_final
{
    internal class cTabla
    {
        private const int mDimensiune = 10;
        private const int mLimitaAvioane = 2;
        private int mNumarAvioane = 0;
        public cCelula[,] mCelule { get; }
        private Random random = new Random();

        public cTabla()
        {
            mCelule = new cCelula[mDimensiune, mDimensiune];
            for (int mX = 0; mX < mDimensiune; mX++)
                for (int mY = 0; mY < mDimensiune; mY++)
                    mCelule[mX, mY] = new cCelula(mX, mY);
        }

        public bool PoatePlasaAvion(int pX, int pY, cOrientare pOrientare)
        {
            if (mNumarAvioane >= mLimitaAvioane)
                return false;

            List<(int, int)> forma = cAvion.ObtineFormaAvion(pX, pY, pOrientare);
            foreach (var (mCx, mCy) in forma)
            {
                if (mCx < 0 || mCx >= mDimensiune || mCy < 0 || mCy >= mDimensiune || mCelule[mCx, mCy].mStare == cStareCelula.Avion)
                    return false;
            }
            return true;
        }

        public bool PlaseazaAvion(int pX, int pY, cOrientare pOrientare)
        {
            if (!PoatePlasaAvion(pX, pY, pOrientare))
                return false;

            List<(int, int)> forma = cAvion.ObtineFormaAvion(pX, pY, pOrientare);
            foreach (var (mCx, mCy) in forma)
            {
                mCelule[mCx, mCy].mStare = cStareCelula.Avion;
            }

            mNumarAvioane++;
            return true;
        }

        public void GenereazaAvioaneAleatoriu()
        {
            int avioaneGenerate = 0;
            while (avioaneGenerate < mLimitaAvioane)
            {
                int x = random.Next(mDimensiune);
                int y = random.Next(mDimensiune);
                cOrientare orientare = (cOrientare)random.Next(4);

                if (PlaseazaAvion(x, y, orientare))
                {
                    avioaneGenerate++;
                }
            }
        }
    }
}
