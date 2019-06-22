using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DanceSportEF
{
    public partial class Form1 : Form
    {
        private DanceLibraryEF.DanceSportSimplifiedEntities ctx;
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ctx = new DanceLibraryEF.DanceSportSimplifiedEntities();
            ctx.DANCERs.Load();
            ctx.SEXes.Load();
            this.dANCERBindingSource.DataSource = ctx.DANCERs.Local.ToBindingList();
            this.sEXBindingSource.DataSource = ctx.SEXes.Local.ToBindingList();
            
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            ctx.Dispose();
        }
    }
}
