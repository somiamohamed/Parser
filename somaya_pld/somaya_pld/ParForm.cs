using System.Windows.Forms;
using com.calitha.goldparser;

namespace somaya_pld
{
    public partial class ParForm : Form
    {

        MyParser parse;
        public ParForm()
        {
            InitializeComponent();
            parse = new MyParser("Syntax.cgt", ErrorBox, LexBox);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            ErrorBox.Items.Clear();
            LexBox.Items.Clear();
            parse.Parse(richTextBox1.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
