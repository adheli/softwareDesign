using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;




class GFrame:Form {

	private Label lmain=new Label();
	private Label l1=new Label(); private Label l2 = new Label(); private Label l3 = new Label();
    private TextBox t1 = new TextBox(); private TextBox t2 = new TextBox(); private TextBox t3 = new TextBox();
    private Button b_win=new Button(); private Button b_draw = new Button(); private Button b_loss = new Button();
    private Button b_print = new Button();
    private Font f=new Font("Times New Roman",15,FontStyle.Bold);
    Team t = new Team("MANU");

      public GFrame():base(){  
    	         lmain.Text="Team Application";
    	         lmain.Font=f;
    	         l1.Text="Name"; l2.Text = "Points"; l3.Text = "Played";
                 lmain.SetBounds(10,10,220,43);
	             l1.SetBounds(22,60,70,23);    t1.SetBounds(102,60,90,23);
                 l2.SetBounds(22, 90, 70, 23); t2.SetBounds(102, 90, 90, 23);
                 l3.SetBounds(22, 120, 70, 23); t3.SetBounds(102, 120, 90, 23);
                 b_win.Text= "WIN "; b_draw.Text = "DRAW "; b_loss.Text = "LOSS "; b_print.Text = "PRINT";
                 b_win.SetBounds(22,150,70,23); b_draw.SetBounds(102, 150, 70, 23);
                 b_loss.SetBounds(22, 180, 70, 23); b_print.SetBounds(102, 180, 70, 23);
                 b_win.Click += new EventHandler(this.button1_Click); b_draw.Click += new EventHandler(this.button2_Click);
                 b_loss.Click += new EventHandler(this.button3_Click); b_print.Click += new EventHandler(this.button4_Click);
                 Controls.Add(lmain);
	             Controls.Add(l1); Controls.Add(l2); Controls.Add(l3);
                 Controls.Add(t1); Controls.Add(t2); Controls.Add(t3);
                 Controls.Add(b_win); Controls.Add(b_draw); Controls.Add(b_loss); Controls.Add(b_print);
                 myRefresh();
    }


    public void myRefresh()
    {
        t1.Text = t.ReadName();
        t2.Text = ""+t.ReadPoints();
        t3.Text = ""+t.ReadGamesPlayed();
    }
      private void button1_Click(object sender, EventArgs e)
      {
        t.Win(); myRefresh();
      }
    private void button2_Click(object sender, EventArgs e)
    {
        t.Draw(); myRefresh();
    }
    private void button3_Click(object sender, EventArgs e)
    {
        t.Loss(); myRefresh();
    }
    private void button4_Click(object sender, EventArgs e)
    {
        t.PrintDetails();
    }
}

public class Test92
{
    public static void Main(string[] args)
    {
        Application.Run(new GFrame());
    }
}



