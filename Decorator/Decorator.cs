using System.Windows.Forms;
using System.Drawing;

abstract class AbstractDecorator : Panel
{
    protected Control ctrl;
    public AbstractDecorator(Control c)
    {
        this.Size = c.Size;
        ctrl = c;
        Controls.Add(c);
        c.Paint += new PaintEventHandler(paint);
    }

    virtual public void paint(object sender, PaintEventArgs pe) { }
}

class SlashDecorator : AbstractDecorator
{

    public SlashDecorator(Control c) : base(c) { }

    override public void paint(object sender, PaintEventArgs pe)
    {
        Pen aPen = new Pen(Color.Black, 1);
        Graphics g = pe.Graphics;
        int x2 = this.Size.Width;
        int y2 = this.Size.Height;
        g.DrawLine(aPen, 0, 0, x2, y2);
    }
}

class CrossDecorator : AbstractDecorator
{

    public CrossDecorator(Control c) : base(c) { }

    override public void paint(object sender, PaintEventArgs pe)
    {
        Pen aPen = new Pen(Color.Black, 1);
        Graphics g = pe.Graphics;
        int x2 = this.Size.Width;
        int y2 = this.Size.Height;
        g.DrawLine(aPen, 0, y2/2, x2, y2/2);
        g.DrawLine(aPen, x2/2, 0, x2/2, y2);
    }
}

class GFrame : Form
{
    private Button cbutton = new Button();
    private Button dbutton = new Button();
    private Button otherButton = new Button();

    private SlashDecorator d;
    private CrossDecorator o;

    public GFrame() : base()
    {
        cbutton.Text = "cbutton";
        dbutton.Text = "dbutton";
        otherButton.Text = "obutton";

        d = new SlashDecorator(dbutton);
        o = new CrossDecorator(otherButton);

        cbutton.SetBounds(10, 10, cbutton.Size.Width,
        cbutton.Size.Height);

        d.SetBounds(100, 10, d.Size.Width, d.Size.Height);
        o.SetBounds(200, 10, o.Size.Width, o.Size.Height);

        Controls.Add(cbutton);
        Controls.Add(d);
        Controls.Add(o);
    }
}

public class Test92
{
    public static void Main(string[] args)
    {
        Application.Run(new GFrame());
    }
}
