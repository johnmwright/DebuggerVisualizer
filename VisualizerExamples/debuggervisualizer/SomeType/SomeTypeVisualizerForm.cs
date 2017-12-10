using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TotallyRealApp.DebuggerVisualizer.SomeType
{
    public partial class SomeTypeVisualizerForm : Form
    {
        private readonly Action<Types.SomeType> _onChangeHandler;
        public Types.SomeType Object { get; set; }

        public SomeTypeVisualizerForm(Types.SomeType initialValue, Action<Types.SomeType> onChangeHandler)
        {
            Object = initialValue;          
            _onChangeHandler = onChangeHandler ?? (s => { });
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            txtFoo.Text = Object.Foo;
            base.OnLoad(e);
        }

        private void chkAllowEdit_CheckedChanged(object sender, EventArgs e)
        {
            txtFoo.ReadOnly = !chkAllowEdit.Checked;
        }

        private void txtFoo_TextChanged(object sender, EventArgs e)
        {
            Object.Foo = txtFoo.Text;
            _onChangeHandler(Object);
        }
    }
}
