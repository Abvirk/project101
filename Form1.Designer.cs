namespace Project001
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.tbPersonName = new System.Windows.Forms.TextBox();
            this.btnStartRecognization = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPersonName = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblTimmer = new System.Windows.Forms.Label();
            this.btnTrainModel = new System.Windows.Forms.Button();
            this.lblAlarm = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(546, 351);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Location = new System.Drawing.Point(575, 213);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(197, 23);
            this.btnAddPerson.TabIndex = 3;
            this.btnAddPerson.Text = "Add Person";
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // tbPersonName
            // 
            this.tbPersonName.Location = new System.Drawing.Point(575, 185);
            this.tbPersonName.Name = "tbPersonName";
            this.tbPersonName.Size = new System.Drawing.Size(197, 22);
            this.tbPersonName.TabIndex = 4;
            // 
            // btnStartRecognization
            // 
            this.btnStartRecognization.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnStartRecognization.Location = new System.Drawing.Point(605, 360);
            this.btnStartRecognization.Name = "btnStartRecognization";
            this.btnStartRecognization.Size = new System.Drawing.Size(127, 67);
            this.btnStartRecognization.TabIndex = 5;
            this.btnStartRecognization.Text = "Start Recognization";
            this.btnStartRecognization.UseVisualStyleBackColor = true;
            this.btnStartRecognization.Click += new System.EventHandler(this.btnStartRecognization_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 416);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Message:";
            // 
            // lblPersonName
            // 
            this.lblPersonName.AutoSize = true;
            this.lblPersonName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonName.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblPersonName.Location = new System.Drawing.Point(121, 416);
            this.lblPersonName.Name = "lblPersonName";
            this.lblPersonName.Size = new System.Drawing.Size(0, 25);
            this.lblPersonName.TabIndex = 8;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(575, 13);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(197, 131);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(600, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Person Name";
            // 
            // lblTimmer
            // 
            this.lblTimmer.AutoSize = true;
            this.lblTimmer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimmer.Location = new System.Drawing.Point(615, 239);
            this.lblTimmer.Name = "lblTimmer";
            this.lblTimmer.Size = new System.Drawing.Size(103, 29);
            this.lblTimmer.TabIndex = 11;
            this.lblTimmer.Text = "Timmer";
            this.lblTimmer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTrainModel
            // 
            this.btnTrainModel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnTrainModel.Location = new System.Drawing.Point(575, 314);
            this.btnTrainModel.Name = "btnTrainModel";
            this.btnTrainModel.Size = new System.Drawing.Size(197, 34);
            this.btnTrainModel.TabIndex = 12;
            this.btnTrainModel.Text = "Train Model";
            this.btnTrainModel.UseVisualStyleBackColor = true;
            this.btnTrainModel.Click += new System.EventHandler(this.btnTrainModel_Click);
            // 
            // lblAlarm
            // 
            this.lblAlarm.AutoSize = true;
            this.lblAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlarm.Location = new System.Drawing.Point(615, 278);
            this.lblAlarm.Name = "lblAlarm";
            this.lblAlarm.Size = new System.Drawing.Size(80, 29);
            this.lblAlarm.TabIndex = 13;
            this.lblAlarm.Text = "Alarm";
            this.lblAlarm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblAlarm);
            this.Controls.Add(this.btnTrainModel);
            this.Controls.Add(this.lblTimmer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblPersonName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStartRecognization);
            this.Controls.Add(this.tbPersonName);
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.TextBox tbPersonName;
        private System.Windows.Forms.Button btnStartRecognization;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPersonName;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblTimmer;
        private System.Windows.Forms.Button btnTrainModel;
        private System.Windows.Forms.Label lblAlarm;
    }
}