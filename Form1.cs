using System;
using System.Drawing;
using System.Windows.Forms;

namespace avioane_final
{
    public partial class Form1 : Form
    {
        private const int mDimensiuneCelula = 40;
        private cTabla mTablaJucator;
        private cTabla mTablaInamic;
        private Button[,] mButoaneJucator;
        private Button[,] mButoaneInamic;
        private ComboBox mOrientareSelect;
        private Label mMesajEroare;
        private Random random = new Random();
        private bool turaJucator = true;

        public Form1()
        {
            this.Text = "Fleet Battle - Avioane";
            this.Size = new Size(900, 550);

            mTablaJucator = new cTabla();
            mTablaInamic = new cTabla();
            mTablaInamic.GenereazaAvioaneAleatoriu();

            mButoaneJucator = new Button[10, 10];
            mButoaneInamic = new Button[10, 10];

            // Creare matrice de butoane pentru jucător
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button btn = new Button
                    {
                        Size = new Size(mDimensiuneCelula, mDimensiuneCelula),
                        Location = new Point(i * mDimensiuneCelula + 20, j * mDimensiuneCelula + 20),
                        Tag = (i, j)
                    };
                    btn.Click += ButonJucator_Click;
                    mButoaneJucator[i, j] = btn;
                    this.Controls.Add(btn);
                }
            }

            // Creare matrice de butoane pentru inamic
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button btn = new Button
                    {
                        Size = new Size(mDimensiuneCelula, mDimensiuneCelula),
                        Location = new Point(i * mDimensiuneCelula + 450, j * mDimensiuneCelula + 20),
                        Tag = (i, j)
                    };
                    btn.Click += ButonInamic_Click;
                    mButoaneInamic[i, j] = btn;
                    this.Controls.Add(btn);
                }
            }

            // ComboBox pentru orientare
            mOrientareSelect = new ComboBox
            {
                Location = new Point(20, 450),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            mOrientareSelect.Items.AddRange(new string[] { "Sus", "Jos", "Stanga", "Dreapta" });
            mOrientareSelect.SelectedIndex = 0;
            this.Controls.Add(mOrientareSelect);

            // Label pentru mesajele de eroare
            mMesajEroare = new Label
            {
                Location = new Point(150, 450),
                Size = new Size(300, 30),
                ForeColor = Color.Red
            };
            this.Controls.Add(mMesajEroare);
        }

        private void ButonJucator_Click(object sender, EventArgs e)
        {
            Button buton = sender as Button;
            var (x, y) = ((int, int))buton.Tag;
            cOrientare orientare = (cOrientare)mOrientareSelect.SelectedIndex;

            if (mTablaJucator.PlaseazaAvion(x, y, orientare))
            {
                mMesajEroare.Text = "";
                PlaseazaAvionJucator(x, y, orientare);
            }
            else
            {
                mMesajEroare.Text = "Nu se poate plasa avionul aici!";
            }
        }

        private void PlaseazaAvionJucator(int pX, int pY, cOrientare pOrientare)
        {
            var forma = cAvion.ObtineFormaAvion(pX, pY, pOrientare);
            foreach (var (mX, mY) in forma)
            {
                mButoaneJucator[mX, mY].BackColor = Color.DarkGreen;
            }
        }

        private void ButonInamic_Click(object sender, EventArgs e)
        {
            if (!turaJucator) return;
            Button buton = sender as Button;
            var (x, y) = ((int, int))buton.Tag;

            if (mTablaInamic.mCelule[x, y].mStare == cStareCelula.Avion)
            {
                buton.BackColor = Color.Red;
                buton.Text = "X";
            }
            else
            {
                buton.BackColor = Color.Blue;
            }
            buton.Enabled = false; // Previne apăsarea repetată a acelui buton
            turaJucator = false;
            InamicGhiceste();
        }
        private void InamicGhiceste()
        {
            int x, y;
            do
            {
                x = random.Next(10);
                y = random.Next(10);
            } while (!mButoaneJucator[x, y].Enabled);

            if (mTablaJucator.mCelule[x, y].mStare == cStareCelula.Avion)
            {
                mButoaneJucator[x, y].BackColor = Color.Red;
                mButoaneJucator[x, y].Text = "X";
            }
            else
            {
                mButoaneJucator[x, y].BackColor = Color.Blue;
            }
            mButoaneJucator[x, y].Enabled = false;

            turaJucator = true;
        }
    }
}
