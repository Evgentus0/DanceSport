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
            ctx.CLASSes.Load();
            this.dANCERBindingSource.DataSource = ctx.DANCERs.Local.ToBindingList();
            this.cLUBBindingSource.DataSource = ctx.CLUBs.Local.ToBindingList();
            this.cOMPETITIONBindingSource.DataSource = ctx.COMPETITIONs.Local.ToBindingList();
            this.sEXBindingSource.DataSource = ctx.SEXes.Local.ToBindingList();
            this.cLASSBindingSource.DataSource = ctx.CLASSes.Local.ToBindingList();
            
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            ctx.Dispose();
        }

        private void ButtonSearchD_Click(object sender, EventArgs e)
        {
            ctx.Dispose();
            ctx = new DanceLibraryEF.DanceSportSimplifiedEntities();
            var dancers = from d in ctx.DANCERs select d;
            if (!string.IsNullOrEmpty(textBoxNameD.Text))
            {
                dancers = dancers.Where(d => d.Fullname == textBoxNameD.Text);
            }
            if (numericUpDownHeightMin.Value <= numericUpDownHeightMax.Value)
            {
                dancers = dancers.Where(d => d.Height >= numericUpDownHeightMin.Value && d.Height <= numericUpDownHeightMax.Value);
            }
            if (numericUpDownYearMin.Value <= numericUpDownYearMax.Value)
            {
                dancers = dancers.Where(d => d.Height >= numericUpDownYearMin.Value && d.Height <= numericUpDownYearMax.Value);
            }
            if(checkBoxMaleD.Checked || checkBoxFemaleD.Checked)
            {
                if (checkBoxMaleD.Checked)
                {
                    dancers = dancers.Where(d => d.SEX1.Sex1 == "Ч");
                }
                else
                {
                    dancers = dancers.Where(d => d.SEX1.Sex1 == "Ж");
                }
            }
            if(comboBoxMinClassLatD.SelectedValue!=null&& comboBoxMaxClassLatD.SelectedValue != null)
            {
                dancers = dancers.Where(d => d.Class_Lat >= comboBoxMinClassLatD.SelectedIndex && d.Class_Lat <= comboBoxMaxClassLatD.SelectedIndex);
            }
            if (comboBoxMinClassStD.SelectedValue != null && comboBoxMaxClassStD.SelectedValue != null)
            {
                dancers = dancers.Where(d => d.Class_Lat >= comboBoxMinClassStD.SelectedIndex && d.Class_Lat <= comboBoxMaxClassStD.SelectedIndex);
            }
            dancers.Load();
            dANCERBindingSource.DataSource = ctx.DANCERs.Local.ToBindingList();
        }
    }
}
