using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SortComparison
{
    public class DrawSelSort
    {
        ArrayList arrayToSort;
        Graphics g;
        Bitmap bmpsave;
        PictureBox pnlSamples;
        public bool savePicture;

        public Dictionary<int, bool> highlightedIndexes = new Dictionary<int, bool>(); // highlight all of these indexes in the frame

        int originalPanelHeight;

        public DrawSelSort(ArrayList list, PictureBox pic)
        {
            arrayToSort = list;
            pnlSamples = pic;

            bmpsave = new Bitmap(pnlSamples.Width, pnlSamples.Height);
            g = Graphics.FromImage(bmpsave);
            originalPanelHeight = pnlSamples.Height;
            pnlSamples.Image = bmpsave;

        }

        public void SwapItems(IList arrayToSort, int index1, int index2)
        {
            object temp = arrayToSort[index1];
            arrayToSort[index1] = arrayToSort[index2];
            arrayToSort[index2] = temp;

            if (!highlightedIndexes.ContainsKey(index1))
                highlightedIndexes.Add(index1, false);
            if (!highlightedIndexes.ContainsKey(index2))
                highlightedIndexes.Add(index2, false);

        }
        public int CompareItems(IList arrayToSort, int index1, int index2)
        {
            if (!highlightedIndexes.ContainsKey(index1))
                highlightedIndexes.Add(index1, false);
            if (!highlightedIndexes.ContainsKey(index2))
                highlightedIndexes.Add(index2, false);

            return ((IComparable)arrayToSort[index1]).CompareTo(arrayToSort[index2]);
        }

        public void RedrawChart()
        {
            DrawSamples();
            RefreshPanel(pnlSamples);
        }

        delegate void SetControlValueCallback(Control pnlSort);
        private void RefreshPanel(Control pnlSort)
        {
            if (pnlSort.InvokeRequired)
            {
                SetControlValueCallback d = new SetControlValueCallback(RefreshPanel);
                pnlSort.Invoke(d, new object[] { pnlSort });
            }
            else
            {
                pnlSort.Refresh();
            }
        }

        public void DrawSamples()
        {
            // might need to grow or shrink if size is different from original (can't change array!)
            double multiplyHeight = 1;

            // check if need to change size
            if (bmpsave.Width != pnlSamples.Width || bmpsave.Height != pnlSamples.Height)
            {
                bmpsave = new Bitmap(pnlSamples.Width, pnlSamples.Height);
                g = Graphics.FromImage(bmpsave);
                pnlSamples.Image = bmpsave;
            }

            if (pnlSamples.Height != originalPanelHeight)
            {
                multiplyHeight = (double)(pnlSamples.Height) / (double)(originalPanelHeight);
            }

            // start with white background
            g.Clear(Color.White);

            // use black sometimes
            Pen pen = new Pen(Color.Black);
            SolidBrush b = new SolidBrush(Color.Black);

            // use red sometimes
            Pen redPen = new Pen(Color.Red);
            SolidBrush redBrush = new SolidBrush(Color.Red);

            // draw a nice width based on number of elements
            int w = (pnlSamples.Width / arrayToSort.Count) - 1;

            for (int i = 0; i < this.arrayToSort.Count; i++)
            {
                int x = (int)(((double)pnlSamples.Width / arrayToSort.Count) * i);

                int itemHeight = (int)Math.Round(Convert.ToDouble(arrayToSort[i]) * multiplyHeight);

                // draw highlighed versions
                if (highlightedIndexes.ContainsKey(i))
                {
                    if (w <= 1)
                    {
                        g.DrawLine(redPen, new Point(x, pnlSamples.Height), new Point(x, (int)(pnlSamples.Height - itemHeight)));
                    }
                    else
                    {
                        g.FillRectangle(redBrush, x, pnlSamples.Height - itemHeight, w, pnlSamples.Height);
                    }
                }
                else // draw normal versions
                {
                    if (w <= 1)
                    {
                        g.DrawLine(pen, new Point(x, pnlSamples.Height), new Point(x, (int)(pnlSamples.Height - itemHeight)));
                    }
                    else
                    {
                        g.FillRectangle(b, x, pnlSamples.Height - itemHeight, w, pnlSamples.Height);
                    }
                }
            }
        }

    }
}
