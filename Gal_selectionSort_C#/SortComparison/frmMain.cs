using System;
using System.Linq; 
using System.Windows.Forms;
using System.Collections;

namespace SortComparison
{
    public partial class frmMain : Form
    {
        ArrayList array1;

        int bottomSpacer;
        int topSpacer;
        int leftSpacer;

        int i = 0;
        int j = 1;
        int min = 0;
        bool new_sort = true;
 
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            leftSpacer = pnlSort1.Left;
            bottomSpacer = this.Height - (pnlSort1.Top + pnlSort1.Height);
            topSpacer = pnlSort1.Top;
        }

        private void PrepareForSort()
        {
            resizeGraphics();
           
            
            String[] numbers = textBox1.Text.Split(','); 
            int[] ints = Array.ConvertAll(numbers, int.Parse);  
            array1 = new ArrayList(numbers.Length); // scale the int[] with pnlSort1.Height and store into an ArrayList

            for (int i = 0; i < array1.Capacity; i++)
            {
                int y = (int)((ints[i] / (double)ints.Max()) * pnlSort1.Height);
                array1.Add(y);
            }

        }

        private void cmdSort_Click(object sender, EventArgs e)
        {
            if (new_sort)
            {
                PrepareForSort(); // parse the input field, convert to ints and normalize 
                new_sort = false;
            }

            resizeGraphics();

            DrawSelSort sa = new DrawSelSort(array1, pnlSort1);

            sa.highlightedIndexes.Clear();//porednite n. na chislata v arr koito iskame da sa red
            sa.highlightedIndexes.Add(i, true);
            sa.highlightedIndexes.Add(j, true);

            sa.RedrawChart();

            if (i == array1.Count) // end of outer for-cycle (i)
            {
                i = 0; j = 1; min = 0;
                new_sort = true; // be ready to sort a new arr
                return;
            }

            if (j == array1.Count) // end of the inner for-cycle (j)
                                   // start new iteration of the outer cycle (i)
            {
                i++;
                j = i + 1;
                min = i;
                return;
            } else
            {               
                if (j < array1.Count) // inside the body of the two for loops
                {
                    if (sa.CompareItems(array1, j, min) < 0)
                    {
                        min = j;
                    }
                    j++;
                }

                if (j == array1.Count) // end of the inner loop (j): swap min with i-th
                {
                    if (i < min)
                    {
                        sa.SwapItems(array1, i, min);
                        Console.Out.WriteLine("swapped[" + i + ", " + min + "]");
                    }

                    i++;
                    j = i + 1;
                    min = i;

                    return;

                }

            }
            
            Console.Out.WriteLine("i = " + i + ", j = " + j + ", min = " + min);

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            resizeGraphics();
        }

        public void resizeGraphics()
        {
            // change the graphics to the right sizes

            pnlSort1.Height = this.Height - topSpacer - bottomSpacer;

        }

    }
}
