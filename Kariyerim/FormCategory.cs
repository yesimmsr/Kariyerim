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

    public partial class FormCategory : Form
    {

        public FormCategory()
        {
            InitializeComponent();
        }

        private void FormCategory_Load(object sender, EventArgs e)
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
            using (CarrierContext DB = new CarrierContext())
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = DB.Category.Select(t0 => new CategoryVM
                {
                    CategoryId = t0.CategoryId,
                    CategoryName = t0.CategoryName,
                    ParentCategoryId = t0.ParentCategoryId,
                    ParentCategoryName = t0.ParentCategory != null ? t0.ParentCategory.CategoryName : "",
                    ModifiedDate = t0.ModifiedDate,
                    RecordDate = t0.RecordDate
                }).ToList();
            }
        }

        private void FillParentCategory()
        {
            using (CarrierContext DB = new CarrierContext())
            {
                var Categories = DB.Category.ToList();
                cmbParentCategory.DataSource = Categories;
                cmbParentCategory.DisplayMember = "CategoryName";
                cmbParentCategory.ValueMember = "CategoryId";
                cmbParentCategory.SelectedIndex = -1;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormClear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FormSave();
        }

        Category selectedCategory;

        private void FormSave()
        {

            try
            {

                using (CarrierContext DB = new CarrierContext())
                {
                    if (this.selectedCategory == null)
                    {
                        this.selectedCategory = new Category();
                        //this.selectedCategory.RecordDate  DateTime.Now;
                    }
                    if (cmbParentCategory.SelectedIndex > -1)
                    {
                        this.selectedCategory.ParentCategoryId = Convert.ToInt32(cmbParentCategory.SelectedValue);
                    }
                    else
                    {
                        this.selectedCategory.ParentCategoryId = null;
                    }
                        
                    this.selectedCategory.CategoryName = txtCategoryName.Text;

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

        private void FormClear()
        {
            this.selectedCategory = null;
            this.Tag = 0;
            cmbParentCategory.SelectedIndex = -1;
            txtCategoryName.Text = "";
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var category = (dataGridView1.DataSource as List<CategoryVM>)[e.RowIndex];
                if (category != null)
                {
                    FillData(category.CategoryId);
                }
            }
        }

        private void FillData(int id)
        {
            using (CarrierContext DB = new CarrierContext())
            {
                var category = DB.Category.AsNoTracking().FirstOrDefault(t0 => t0.CategoryId == id);
                if (category != null)
                {
                    txtCategoryName.Text = category.CategoryName;

                    if (category.ParentCategoryId != null)
                    {
                        cmbParentCategory.SelectedValue = category.ParentCategoryId;
                    }
                    else
                    {
                        cmbParentCategory.SelectedIndex = -1;
                    }
                    this.selectedCategory = category;
                    this.Tag = category.CategoryId;
                }
            }
        }
    }
}
