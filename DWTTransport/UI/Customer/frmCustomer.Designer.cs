﻿namespace DWTTransport.UI.Customer
{
    partial class frmCustomer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dsCustomer = new System.Windows.Forms.BindingSource(this.components);
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.daybookImportDetailedGrid = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeliveryAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dsCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daybookImportDetailedGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dsCustomer
            // 
            this.dsCustomer.DataSource = typeof(DWTTransport.BLL.DAL.tblCustomer);
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.daybookImportDetailedGrid);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(3, 15);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(735, 696);
            this.groupControl3.TabIndex = 0;
            this.groupControl3.Text = "Customer";
            // 
            // daybookImportDetailedGrid
            // 
            this.daybookImportDetailedGrid.DataSource = this.dsCustomer;
            this.daybookImportDetailedGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.daybookImportDetailedGrid.Location = new System.Drawing.Point(2, 21);
            this.daybookImportDetailedGrid.MainView = this.gridView1;
            this.daybookImportDetailedGrid.Name = "daybookImportDetailedGrid";
            this.daybookImportDetailedGrid.Size = new System.Drawing.Size(731, 673);
            this.daybookImportDetailedGrid.TabIndex = 1;
            this.daybookImportDetailedGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView6});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colDeliveryAddress,
            this.colCustID});
            this.gridView1.GridControl = this.daybookImportDetailedGrid;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 204;
            // 
            // colDeliveryAddress
            // 
            this.colDeliveryAddress.FieldName = "DeliveryAddress";
            this.colDeliveryAddress.Name = "colDeliveryAddress";
            this.colDeliveryAddress.OptionsColumn.AllowEdit = false;
            this.colDeliveryAddress.Visible = true;
            this.colDeliveryAddress.VisibleIndex = 1;
            this.colDeliveryAddress.Width = 511;
            // 
            // colCustID
            // 
            this.colCustID.FieldName = "CustID";
            this.colCustID.Name = "colCustID";
            // 
            // gridView6
            // 
            this.gridView6.GridControl = this.daybookImportDetailedGrid;
            this.gridView6.Name = "gridView6";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.groupControl3, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(230, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 702F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(741, 714);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 714);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Customer";
            this.Load += new System.EventHandler(this.frmCustomer_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel4, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dsCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.daybookImportDetailedGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource dsCustomer;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraGrid.GridControl daybookImportDetailedGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colDeliveryAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colCustID;
    }
}