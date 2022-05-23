using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using ValidadorNFse.Validator;

namespace ValidadorNFse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var bindingSource1 = new BindingSource
            {
                DataSource = Enum.GetValues(typeof(ECollections))
            };

            comboBox1.DataSource = bindingSource1.DataSource;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = null;
            try
            {
                var validator = Factory.Create(comboBox1.Text);
                var errorList = validator.ValidateSchema(textBox1.Text);
                foreach (var item in errorList)
                {
                    textBox2.Text += string.Concat(item, Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                textBox2.Text = ex.Message;
            }
            
            
        }
    }
}