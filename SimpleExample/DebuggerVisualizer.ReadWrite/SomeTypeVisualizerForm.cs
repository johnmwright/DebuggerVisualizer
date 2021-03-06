﻿using System;
using System.Windows.Forms;

namespace SimpleExample.DebuggerVisualizer.ReadWrite
{
    public partial class SomeTypeVisualizerForm : Form
    {
        public SimpleExample.SomeType Object { get; }

        public event EventHandler<SimpleExample.SomeType> OnChange;

        public SomeTypeVisualizerForm(SimpleExample.SomeType initialValue)
        {
            Object = initialValue;          
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
            OnChange?.Invoke(this, Object);           
       }
        
    }
}
