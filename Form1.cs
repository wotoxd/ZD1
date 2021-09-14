using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace z1
{
    public partial class Form1 : Form
    {
        Stopwatch s1 = new Stopwatch();
        Stopwatch s2 = new Stopwatch();
        Stopwatch s3 = new Stopwatch();

        double tm1;
        double tm2;
        double tm3;
        public Form1()
        {
            InitializeComponent();
            tm1 = 0;
            tm2 = 0;
            tm3 = 0;
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }
        public class sort
        {      

            static void swap(int[] array, int i, int j)
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
            public static string Bsort(int[] b)
            {
                
                long sw=0,pr =0;

                string a;
                for (int i = 0; i < b.Length; i++)
                {
                    for (int j = 0; j < b.Length - 1; j++)
                    {
                        sw++;
                        if (b[j] > b[j + 1])
                        {
                            swap(b, j, j + 1);
                            pr++;
                            
                        }
                    }
                }
                a = "ОТСОРТИРОВАНО"+" "+"СРАВНЕНИЙ = "+ sw+ " "+"ПЕРЕСТАНОВОК = "+ pr;
                return a;
                

            }

            public static string SHsort(int[] mas)
            {
                long sw = 0, pr = 0;
                string a1;
                int l = 0, r = mas.Length - 1;

                while (l<r)
                {
                    for (int i = l; i < r; i++)
                    {
                        sw++;
                        if (mas[i]>mas[i+1])
                        {
                            swap(mas, i, i + 1);
                            pr++;
                        }
                    }
                    r--;
                    for (int i = r; i > l; i--)
                    {
                        sw++;
                        if (mas[i - 1] > mas[i])
                        {
                            swap(mas, i - 1, i);
                            pr++;
                        }
                    }
                    l++;
                }
                a1 = "ОТСОРТИРОВАНО" + " " + "СРАВНЕНИЙ = " + sw + " " + "ПЕРЕСТАНОВОК = " + pr;
                return a1;
            }

            public static string Qsort(int[] bmas, int left, int right)
            {
                long sw = 0, pr = 0;
                int i = left;
                int k = right;
                int p = bmas[(left + right) / 2];
                do
                {
                    
                    while (bmas[i] < p && i < right) { i++; sw++; } ;
                    while (p < bmas[k] && k > left) { k--; sw++; } ;
                    
                    if (i<=k)
                    {
                        swap(bmas, i, k);
                        i++;
                        k--;
                        pr++;
                    }
                } while (i<=k);
                if (left < k) Qsort(bmas, left, k);
                if (i < right) Qsort(bmas, i, right);
                string ans = "ОТСОРТИРОВАНО" + " " + "СРАВНЕНИЙ = " + sw + " " + "ПЕРЕСТАНОВОК = " + pr;
                return ans;
            }
        }
        

        public void button2_Click(object sender, EventArgs e)
        {

            
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            if (textBox1.Text=="")
            {
                MessageBox.Show("Заполните поле ");
                
            }
            
            Random r = new Random();
            int[] mas = new int[Convert.ToInt32(textBox1.Text)];
            for (int i = 0; i < mas.Length; i++)
            {
                int t = r.Next(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));

                mas[i] += t;



            }
            
           
            int[] ms1=new int[mas.Length]; 
            int[] ms2=new int[mas.Length]; 
            int[] ms3=new int[mas.Length];
            Array.Copy(mas, ms1, mas.Length);
            Array.Copy(mas, ms2, mas.Length);
            Array.Copy(mas, ms3, mas.Length);
            s1.Start();

            textBox4.Text = sort.Bsort(mas).ToString();
            s1.Stop();
            s2.Start();
            textBox5.Text = sort.SHsort(ms2).ToString();
            s2.Stop();
            s3.Start();
            textBox6.Text = sort.Qsort(ms3, 0, ms3.Length - 1);
            s3.Stop();
            TimeSpan ts1 = s1.Elapsed;
            TimeSpan ts2 = s2.Elapsed;
            TimeSpan ts3 = s3.Elapsed;
            string et1 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts1.Hours, ts1.Minutes, ts1.Seconds,
            ts1.Milliseconds / 10);
            string et2 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts2.Hours, ts2.Minutes, ts2.Seconds,
            ts2.Milliseconds / 10);
            string et3 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts3.Hours, ts3.Minutes, ts3.Seconds,
            ts3.Milliseconds / 10);
            textBox7.Text = "Время на сортировку 1,2,3 массива :" + et1 + "\t" + et2 + "\t" + et3;

            

            //for (int i = 0; i < mas.Length; i++)
            //{
            //    textBox6.Text += ms3[i].ToString() + " ";
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
