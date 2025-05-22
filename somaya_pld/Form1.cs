using com.calitha.goldparser;

namespace somaya_pld
{
    public partial class Form1 : Form
    {

        MyParser parse;
        public Form1()
        {
            InitializeComponent();
            parse = new MyParser("Syntax.egt", ErrorBox, LexBox);
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
