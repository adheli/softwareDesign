using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{

    class Counter
    {
        protected int value;
        private readonly String name;
        private static Counter instance;
        private static bool hasInstance;

        private Counter()
        {
            this.value = 1;
            this.name = "Score";
            hasInstance = true;
            instance = this;
        }

        public static Counter GetInstance()
        {
            return hasInstance ? instance : new Counter();
        }

        public void Increment() { this.value++; }

        public int ReadValue() { return this.value; }

        public void Decrement() { this.value--; }

        public void Add(int amt) { this.value += amt; }

    }


    class GFrame : Form
    {

        private readonly Label lmain = new Label();
        private readonly Label l1 = new Label();
        private readonly Button b_incr = new Button();
        private readonly Button b_decr = new Button();
        private readonly Button b_add = new Button();
        private readonly TextBox t1 = new TextBox();
        private readonly TextBox t2 = new TextBox();
        private readonly Font f = new Font("Times New Roman", 15, FontStyle.Bold);

        private Counter c;
        public GFrame() : base()
        {
            lmain.Text = "Counter Application";
            lmain.Font = f;
            l1.Text = "Value";
            l1.Font = f;
            b_incr.Text = "Incr";
            b_decr.Text = "Decr";
            b_add.Text = "Add Amt";
            t1.Text = "1";
            lmain.SetBounds(10, 10, 220, 43);
            l1.SetBounds(22, 60, 70, 23);
            t1.SetBounds(102, 60, 90, 23);
            t1.Text = " " + 1;
            b_incr.SetBounds(12, 90, 90, 23);
            b_decr.SetBounds(102, 90, 90, 23);

            b_add.SetBounds(12, 120, 90, 23); t2.SetBounds(102, 120, 90, 23);
            b_incr.Click += new EventHandler(this.Button1_Click);
            b_decr.Click += new EventHandler(this.Button2_Click);
            b_add.Click += new EventHandler(this.Button3_Click);
            Controls.Add(lmain);
            Controls.Add(l1);
            Controls.Add(t1);
            Controls.Add(b_incr);
            Controls.Add(b_decr);
            Controls.Add(b_add);
            Controls.Add(t2);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            c = Counter.GetInstance();
            c.Increment();
            t1.Text = " " + c.ReadValue();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            c = Counter.GetInstance();
            c.Decrement();
            t1.Text = " " + c.ReadValue();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            c = Counter.GetInstance();
            int amt = int.Parse(t2.Text);
            c.Add(amt);
            t1.Text = " " + c.ReadValue();
        }
    }

    public class Test92
    {
        public static void Main(string[] args)
        {
            Application.Run(new GFrame());
        }
    }


}
