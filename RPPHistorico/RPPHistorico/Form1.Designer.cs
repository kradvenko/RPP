namespace RPPHistorico
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnInsertarDocumentos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLibreriaSharePoint = new System.Windows.Forms.TextBox();
            this.txtDirectorioDocumentos = new System.Windows.Forms.TextBox();
            this.txtDirectorioImagenes = new System.Windows.Forms.TextBox();
            this.btnSeleccionarDirectorioDocumentos = new System.Windows.Forms.Button();
            this.btnSeleccionarDirectorioImagenes = new System.Windows.Forms.Button();
            this.pgbAvance = new System.Windows.Forms.ProgressBar();
            this.lblTareaActual = new System.Windows.Forms.Label();
            this.lblTotalFiles = new System.Windows.Forms.Label();
            this.lstArchivosNoEncontrados = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lstDocumentos = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lstImagenes = new System.Windows.Forms.ListBox();
            this.lblNumeroImagenes = new System.Windows.Forms.Label();
            this.lstImagenesNoReferenciadas = new System.Windows.Forms.ListBox();
            this.lblTotalArchivosNoReferenciados = new System.Windows.Forms.Label();
            this.btnValidar = new System.Windows.Forms.Button();
            this.chkIgnorarCamposFaltantes = new System.Windows.Forms.CheckBox();
            this.chkReprocesar = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInsertarDocumentos
            // 
            this.btnInsertarDocumentos.Location = new System.Drawing.Point(347, 485);
            this.btnInsertarDocumentos.Name = "btnInsertarDocumentos";
            this.btnInsertarDocumentos.Size = new System.Drawing.Size(75, 23);
            this.btnInsertarDocumentos.TabIndex = 0;
            this.btnInsertarDocumentos.Text = "Importar Documentos";
            this.btnInsertarDocumentos.UseVisualStyleBackColor = true;
            this.btnInsertarDocumentos.Click += new System.EventHandler(this.btnInsertarDocumentos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Directorio de Documentos (.out)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Directorio de imágenes (.tif)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Librería SharePoint:";
            // 
            // txtLibreriaSharePoint
            // 
            this.txtLibreriaSharePoint.Location = new System.Drawing.Point(15, 37);
            this.txtLibreriaSharePoint.Name = "txtLibreriaSharePoint";
            this.txtLibreriaSharePoint.Size = new System.Drawing.Size(411, 20);
            this.txtLibreriaSharePoint.TabIndex = 5;
            // 
            // txtDirectorioDocumentos
            // 
            this.txtDirectorioDocumentos.Location = new System.Drawing.Point(15, 86);
            this.txtDirectorioDocumentos.Name = "txtDirectorioDocumentos";
            this.txtDirectorioDocumentos.Size = new System.Drawing.Size(377, 20);
            this.txtDirectorioDocumentos.TabIndex = 6;
            // 
            // txtDirectorioImagenes
            // 
            this.txtDirectorioImagenes.Location = new System.Drawing.Point(15, 132);
            this.txtDirectorioImagenes.Name = "txtDirectorioImagenes";
            this.txtDirectorioImagenes.Size = new System.Drawing.Size(377, 20);
            this.txtDirectorioImagenes.TabIndex = 7;
            // 
            // btnSeleccionarDirectorioDocumentos
            // 
            this.btnSeleccionarDirectorioDocumentos.Location = new System.Drawing.Point(397, 85);
            this.btnSeleccionarDirectorioDocumentos.Name = "btnSeleccionarDirectorioDocumentos";
            this.btnSeleccionarDirectorioDocumentos.Size = new System.Drawing.Size(30, 20);
            this.btnSeleccionarDirectorioDocumentos.TabIndex = 8;
            this.btnSeleccionarDirectorioDocumentos.Text = "...";
            this.btnSeleccionarDirectorioDocumentos.UseVisualStyleBackColor = true;
            this.btnSeleccionarDirectorioDocumentos.Click += new System.EventHandler(this.btnSeleccionarDirectorioDocumentos_Click);
            // 
            // btnSeleccionarDirectorioImagenes
            // 
            this.btnSeleccionarDirectorioImagenes.Location = new System.Drawing.Point(397, 131);
            this.btnSeleccionarDirectorioImagenes.Name = "btnSeleccionarDirectorioImagenes";
            this.btnSeleccionarDirectorioImagenes.Size = new System.Drawing.Size(30, 20);
            this.btnSeleccionarDirectorioImagenes.TabIndex = 9;
            this.btnSeleccionarDirectorioImagenes.Text = "...";
            this.btnSeleccionarDirectorioImagenes.UseVisualStyleBackColor = true;
            this.btnSeleccionarDirectorioImagenes.Click += new System.EventHandler(this.btnSeleccionarDirectorioImagenes_Click);
            // 
            // pgbAvance
            // 
            this.pgbAvance.Location = new System.Drawing.Point(12, 485);
            this.pgbAvance.Name = "pgbAvance";
            this.pgbAvance.Size = new System.Drawing.Size(329, 23);
            this.pgbAvance.TabIndex = 11;
            // 
            // lblTareaActual
            // 
            this.lblTareaActual.AutoSize = true;
            this.lblTareaActual.Location = new System.Drawing.Point(12, 469);
            this.lblTareaActual.Name = "lblTareaActual";
            this.lblTareaActual.Size = new System.Drawing.Size(64, 13);
            this.lblTareaActual.TabIndex = 12;
            this.lblTareaActual.Text = "En espera...";
            // 
            // lblTotalFiles
            // 
            this.lblTotalFiles.AutoSize = true;
            this.lblTotalFiles.Location = new System.Drawing.Point(11, 331);
            this.lblTotalFiles.Name = "lblTotalFiles";
            this.lblTotalFiles.Size = new System.Drawing.Size(57, 13);
            this.lblTotalFiles.TabIndex = 13;
            this.lblTotalFiles.Text = "0 Archivos";
            this.lblTotalFiles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstArchivosNoEncontrados
            // 
            this.lstArchivosNoEncontrados.FormattingEnabled = true;
            this.lstArchivosNoEncontrados.Location = new System.Drawing.Point(11, 380);
            this.lstArchivosNoEncontrados.Name = "lstArchivosNoEncontrados";
            this.lstArchivosNoEncontrados.Size = new System.Drawing.Size(410, 82);
            this.lstArchivosNoEncontrados.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 364);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(250, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Documentos con archivo de imágen no encontrado";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstDocumentos
            // 
            this.lstDocumentos.FormattingEnabled = true;
            this.lstDocumentos.Location = new System.Drawing.Point(14, 155);
            this.lstDocumentos.Name = "lstDocumentos";
            this.lstDocumentos.Size = new System.Drawing.Size(413, 169);
            this.lstDocumentos.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(332, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Historico";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(74, 100);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(188, 261);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // lstImagenes
            // 
            this.lstImagenes.FormattingEnabled = true;
            this.lstImagenes.Location = new System.Drawing.Point(449, 37);
            this.lstImagenes.Name = "lstImagenes";
            this.lstImagenes.Size = new System.Drawing.Size(165, 420);
            this.lstImagenes.TabIndex = 19;
            // 
            // lblNumeroImagenes
            // 
            this.lblNumeroImagenes.AutoSize = true;
            this.lblNumeroImagenes.Location = new System.Drawing.Point(447, 461);
            this.lblNumeroImagenes.Name = "lblNumeroImagenes";
            this.lblNumeroImagenes.Size = new System.Drawing.Size(57, 13);
            this.lblNumeroImagenes.TabIndex = 20;
            this.lblNumeroImagenes.Text = "0 Archivos";
            this.lblNumeroImagenes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstImagenesNoReferenciadas
            // 
            this.lstImagenesNoReferenciadas.FormattingEnabled = true;
            this.lstImagenesNoReferenciadas.Location = new System.Drawing.Point(620, 37);
            this.lstImagenesNoReferenciadas.Name = "lstImagenesNoReferenciadas";
            this.lstImagenesNoReferenciadas.Size = new System.Drawing.Size(165, 420);
            this.lstImagenesNoReferenciadas.TabIndex = 21;
            // 
            // lblTotalArchivosNoReferenciados
            // 
            this.lblTotalArchivosNoReferenciados.AutoSize = true;
            this.lblTotalArchivosNoReferenciados.Location = new System.Drawing.Point(617, 460);
            this.lblTotalArchivosNoReferenciados.Name = "lblTotalArchivosNoReferenciados";
            this.lblTotalArchivosNoReferenciados.Size = new System.Drawing.Size(57, 13);
            this.lblTotalArchivosNoReferenciados.TabIndex = 22;
            this.lblTotalArchivosNoReferenciados.Text = "0 Archivos";
            this.lblTotalArchivosNoReferenciados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnValidar
            // 
            this.btnValidar.Location = new System.Drawing.Point(710, 485);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(75, 23);
            this.btnValidar.TabIndex = 23;
            this.btnValidar.Text = "Validar";
            this.btnValidar.UseVisualStyleBackColor = true;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // chkIgnorarCamposFaltantes
            // 
            this.chkIgnorarCamposFaltantes.AutoSize = true;
            this.chkIgnorarCamposFaltantes.Checked = true;
            this.chkIgnorarCamposFaltantes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIgnorarCamposFaltantes.Location = new System.Drawing.Point(449, 489);
            this.chkIgnorarCamposFaltantes.Name = "chkIgnorarCamposFaltantes";
            this.chkIgnorarCamposFaltantes.Size = new System.Drawing.Size(142, 17);
            this.chkIgnorarCamposFaltantes.TabIndex = 24;
            this.chkIgnorarCamposFaltantes.Text = "Ignorar campos faltantes";
            this.chkIgnorarCamposFaltantes.UseVisualStyleBackColor = true;
            // 
            // chkReprocesar
            // 
            this.chkReprocesar.AutoSize = true;
            this.chkReprocesar.Location = new System.Drawing.Point(280, 335);
            this.chkReprocesar.Name = "chkReprocesar";
            this.chkReprocesar.Size = new System.Drawing.Size(124, 17);
            this.chkReprocesar.TabIndex = 25;
            this.chkReprocesar.Text = "Reprocesar archivos";
            this.chkReprocesar.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(608, 483);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 26;
            this.button2.Text = "Validar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 514);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.chkReprocesar);
            this.Controls.Add(this.chkIgnorarCamposFaltantes);
            this.Controls.Add(this.btnValidar);
            this.Controls.Add(this.lblTotalArchivosNoReferenciados);
            this.Controls.Add(this.lstImagenesNoReferenciadas);
            this.Controls.Add(this.lblNumeroImagenes);
            this.Controls.Add(this.lstImagenes);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lstDocumentos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstArchivosNoEncontrados);
            this.Controls.Add(this.lblTotalFiles);
            this.Controls.Add(this.lblTareaActual);
            this.Controls.Add(this.pgbAvance);
            this.Controls.Add(this.btnSeleccionarDirectorioImagenes);
            this.Controls.Add(this.btnSeleccionarDirectorioDocumentos);
            this.Controls.Add(this.txtDirectorioImagenes);
            this.Controls.Add(this.txtDirectorioDocumentos);
            this.Controls.Add(this.txtLibreriaSharePoint);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInsertarDocumentos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "RPP Migración Histórico";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInsertarDocumentos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLibreriaSharePoint;
        private System.Windows.Forms.TextBox txtDirectorioDocumentos;
        private System.Windows.Forms.TextBox txtDirectorioImagenes;
        private System.Windows.Forms.Button btnSeleccionarDirectorioDocumentos;
        private System.Windows.Forms.Button btnSeleccionarDirectorioImagenes;
        private System.Windows.Forms.ProgressBar pgbAvance;
        private System.Windows.Forms.Label lblTareaActual;
        private System.Windows.Forms.Label lblTotalFiles;
        private System.Windows.Forms.ListBox lstArchivosNoEncontrados;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox lstDocumentos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox lstImagenes;
        private System.Windows.Forms.Label lblNumeroImagenes;
        private System.Windows.Forms.ListBox lstImagenesNoReferenciadas;
        private System.Windows.Forms.Label lblTotalArchivosNoReferenciados;
        private System.Windows.Forms.Button btnValidar;
        private System.Windows.Forms.CheckBox chkIgnorarCamposFaltantes;
        private System.Windows.Forms.CheckBox chkReprocesar;
        private System.Windows.Forms.Button button2;
    }
}

