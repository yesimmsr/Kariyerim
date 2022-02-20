using Kariyerim.DAL.EF.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kariyerim
{
    using DAL.EF.Context;
    using DAL.EF.Entities;
    using DAL.VM;
    public partial class FormCountry : Form
    {
        public FormCountry()
        {
            InitializeComponent();
        }

        private void FormCountry_Load(object sender, EventArgs e)
        {
            FillControl();
        }


        private void FillControl()
        {
            FillParentCategory();
            FillGrid();
        }

        private void FillGrid()
        {
        }

        private void FillParentCategory()
        {
        }

       Country selectedCountry;
        private void btnSave_Click(object sender, EventArgs e)
        {
            FormSave();
        }

        private void FormSave()
        {
            try
            {

                using (CarrierContext DB = new CarrierContext())
                {
                    if (this.selectedCountry == null)
                    {
                        this.selectedCountry = new Country();
                    }
                    
                    this.selectedCountry.CountryId = Convert.ToInt32(cmbCountry.SelectedValue);
                    this.selectedCountry.CountryName = txtCity.Text;

                    if (Convert.ToInt32(this.Tag) > 0)
                    {
                        DB.Entry(this.selectedCategory).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        DB.Entry(this.selectedCategory).State = System.Data.Entity.EntityState.Added;
                    }
                    DB.SaveChanges();
                    MessageBox.Show("Kayıt başarılı");
                    FormClear();
                    FillControl();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

       
    }
}
