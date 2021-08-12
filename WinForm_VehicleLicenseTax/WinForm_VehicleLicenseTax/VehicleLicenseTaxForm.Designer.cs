
namespace RayHW3
{
    partial class form_VehicleLicenseTax
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lable_Duration = new System.Windows.Forms.Label();
            this.label_Used = new System.Windows.Forms.Label();
            this.label_CCHP = new System.Windows.Forms.Label();
            this.label_Result = new System.Windows.Forms.Label();
            this.comboBox_Vehicle = new System.Windows.Forms.ComboBox();
            this.comboBox_ccHP = new System.Windows.Forms.ComboBox();
            this.radioButton_WholeYear = new System.Windows.Forms.RadioButton();
            this.radioButton_Duration = new System.Windows.Forms.RadioButton();
            this.dateTimePicker_Start = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.label_ResultShow = new System.Windows.Forms.Label();
            this.button_Reset = new System.Windows.Forms.Button();
            this.button_Calculate = new System.Windows.Forms.Button();
            this.label_VehicleMessage = new System.Windows.Forms.Label();
            this.label_DateStart = new System.Windows.Forms.Label();
            this.label_DateEnd = new System.Windows.Forms.Label();
            this.label_CCHPMessage = new System.Windows.Forms.Label();
            this.panel_ResultShow = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_dateTimePickerStart = new System.Windows.Forms.Label();
            this.label_dateTimePickerEnd = new System.Windows.Forms.Label();
            this.label_Title = new System.Windows.Forms.Label();
            this.label_Tips = new System.Windows.Forms.Label();
            this.label_Tip = new System.Windows.Forms.Label();
            this.panel_ResultShow.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lable_Duration
            // 
            this.lable_Duration.AutoSize = true;
            this.lable_Duration.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lable_Duration.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.lable_Duration.Location = new System.Drawing.Point(42, 182);
            this.lable_Duration.Name = "lable_Duration";
            this.lable_Duration.Size = new System.Drawing.Size(92, 25);
            this.lable_Duration.TabIndex = 0;
            this.lable_Duration.Text = "使用期間";
            // 
            // label_Used
            // 
            this.label_Used.AutoSize = true;
            this.label_Used.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Used.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label_Used.Location = new System.Drawing.Point(42, 232);
            this.label_Used.Name = "label_Used";
            this.label_Used.Size = new System.Drawing.Size(92, 25);
            this.label_Used.TabIndex = 1;
            this.label_Used.Text = "牌照用途";
            // 
            // label_CCHP
            // 
            this.label_CCHP.AutoSize = true;
            this.label_CCHP.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label_CCHP.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label_CCHP.Location = new System.Drawing.Point(42, 282);
            this.label_CCHP.Name = "label_CCHP";
            this.label_CCHP.Size = new System.Drawing.Size(92, 25);
            this.label_CCHP.TabIndex = 2;
            this.label_CCHP.Text = "汽缸馬力";
            // 
            // label_Result
            // 
            this.label_Result.AutoSize = true;
            this.label_Result.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label_Result.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label_Result.Location = new System.Drawing.Point(42, 340);
            this.label_Result.Name = "label_Result";
            this.label_Result.Size = new System.Drawing.Size(92, 25);
            this.label_Result.TabIndex = 3;
            this.label_Result.Text = "試算結果";
            // 
            // comboBox_Vehicle
            // 
            this.comboBox_Vehicle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Vehicle.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_Vehicle.FormattingEnabled = true;
            this.comboBox_Vehicle.Items.AddRange(new object[] {
            "機車",
            "貨車",
            "大客車",
            "自用小客車",
            "營業用小客車",
            "電動機車",
            "電動自用小客車",
            "電動營業用小客車",
            "電動貨車及大客車",
            "曳引車"});
            this.comboBox_Vehicle.Location = new System.Drawing.Point(165, 229);
            this.comboBox_Vehicle.Name = "comboBox_Vehicle";
            this.comboBox_Vehicle.Size = new System.Drawing.Size(237, 28);
            this.comboBox_Vehicle.TabIndex = 4;
            this.comboBox_Vehicle.SelectedIndexChanged += new System.EventHandler(this.comboBox_Vehicle_SelectedIndexChanged);
            // 
            // comboBox_ccHP
            // 
            this.comboBox_ccHP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ccHP.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_ccHP.FormattingEnabled = true;
            this.comboBox_ccHP.Location = new System.Drawing.Point(165, 279);
            this.comboBox_ccHP.Name = "comboBox_ccHP";
            this.comboBox_ccHP.Size = new System.Drawing.Size(447, 28);
            this.comboBox_ccHP.TabIndex = 5;
            this.comboBox_ccHP.SelectedIndexChanged += new System.EventHandler(this.comboBox_ccHP_SelectedIndexChanged);
            // 
            // radioButton_WholeYear
            // 
            this.radioButton_WholeYear.AutoSize = true;
            this.radioButton_WholeYear.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.radioButton_WholeYear.Location = new System.Drawing.Point(15, 15);
            this.radioButton_WholeYear.Name = "radioButton_WholeYear";
            this.radioButton_WholeYear.Size = new System.Drawing.Size(93, 29);
            this.radioButton_WholeYear.TabIndex = 6;
            this.radioButton_WholeYear.TabStop = true;
            this.radioButton_WholeYear.Text = "全年度";
            this.radioButton_WholeYear.UseVisualStyleBackColor = true;
            this.radioButton_WholeYear.CheckedChanged += new System.EventHandler(this.radioButton_WholeYear_CheckedChanged);
            // 
            // radioButton_Duration
            // 
            this.radioButton_Duration.AutoSize = true;
            this.radioButton_Duration.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.radioButton_Duration.Location = new System.Drawing.Point(136, 15);
            this.radioButton_Duration.Name = "radioButton_Duration";
            this.radioButton_Duration.Size = new System.Drawing.Size(93, 29);
            this.radioButton_Duration.TabIndex = 7;
            this.radioButton_Duration.TabStop = true;
            this.radioButton_Duration.Text = "依期間";
            this.radioButton_Duration.UseVisualStyleBackColor = true;
            this.radioButton_Duration.CheckedChanged += new System.EventHandler(this.radioButton_Duration_CheckedChanged);
            // 
            // dateTimePicker_Start
            // 
            this.dateTimePicker_Start.Location = new System.Drawing.Point(450, 182);
            this.dateTimePicker_Start.Name = "dateTimePicker_Start";
            this.dateTimePicker_Start.Size = new System.Drawing.Size(150, 25);
            this.dateTimePicker_Start.TabIndex = 9;
            this.dateTimePicker_Start.Value = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker_Start.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dateTimePicker_Start_MouseDown);
            // 
            // dateTimePicker_End
            // 
            this.dateTimePicker_End.Location = new System.Drawing.Point(648, 182);
            this.dateTimePicker_End.Name = "dateTimePicker_End";
            this.dateTimePicker_End.Size = new System.Drawing.Size(150, 25);
            this.dateTimePicker_End.TabIndex = 10;
            this.dateTimePicker_End.Value = new System.DateTime(2021, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker_End.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dateTimePicker_End_MouseDown);
            // 
            // label_ResultShow
            // 
            this.label_ResultShow.AutoSize = true;
            this.label_ResultShow.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_ResultShow.Location = new System.Drawing.Point(6, 7);
            this.label_ResultShow.Name = "label_ResultShow";
            this.label_ResultShow.Size = new System.Drawing.Size(442, 150);
            this.label_ResultShow.TabIndex = 14;
            this.label_ResultShow.Text = "使用時間：xxxxxxxxxxxxxxxxxxxxxxxx\r\n計算天數：xxxxxxx\r\n汽缸馬力：xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" +
    "xx\r\n牌照用途：xxxxxxxxxxx\r\n計算公式：xxxxxxxxxxxxxxxxxxxxxxxx\r\n應納稅額：xxxxxxxxx";
            // 
            // button_Reset
            // 
            this.button_Reset.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.button_Reset.Location = new System.Drawing.Point(333, 696);
            this.button_Reset.Name = "button_Reset";
            this.button_Reset.Size = new System.Drawing.Size(120, 60);
            this.button_Reset.TabIndex = 16;
            this.button_Reset.Text = "取消重填";
            this.button_Reset.UseVisualStyleBackColor = true;
            this.button_Reset.Click += new System.EventHandler(this.button_Reset_Click);
            // 
            // button_Calculate
            // 
            this.button_Calculate.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Calculate.Location = new System.Drawing.Point(151, 696);
            this.button_Calculate.Name = "button_Calculate";
            this.button_Calculate.Size = new System.Drawing.Size(120, 60);
            this.button_Calculate.TabIndex = 17;
            this.button_Calculate.Text = "確定送出";
            this.button_Calculate.UseVisualStyleBackColor = true;
            this.button_Calculate.Click += new System.EventHandler(this.button_Calculate_Click);
            // 
            // label_VehicleMessage
            // 
            this.label_VehicleMessage.AutoSize = true;
            this.label_VehicleMessage.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_VehicleMessage.Location = new System.Drawing.Point(408, 232);
            this.label_VehicleMessage.Name = "label_VehicleMessage";
            this.label_VehicleMessage.Size = new System.Drawing.Size(45, 22);
            this.label_VehicleMessage.TabIndex = 18;
            this.label_VehicleMessage.Text = "-----";
            // 
            // label_DateStart
            // 
            this.label_DateStart.AutoSize = true;
            this.label_DateStart.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_DateStart.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label_DateStart.Location = new System.Drawing.Point(416, 182);
            this.label_DateStart.Name = "label_DateStart";
            this.label_DateStart.Size = new System.Drawing.Size(32, 25);
            this.label_DateStart.TabIndex = 20;
            this.label_DateStart.Text = "從";
            // 
            // label_DateEnd
            // 
            this.label_DateEnd.AutoSize = true;
            this.label_DateEnd.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_DateEnd.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label_DateEnd.Location = new System.Drawing.Point(613, 182);
            this.label_DateEnd.Name = "label_DateEnd";
            this.label_DateEnd.Size = new System.Drawing.Size(32, 25);
            this.label_DateEnd.TabIndex = 21;
            this.label_DateEnd.Text = "到";
            // 
            // label_CCHPMessage
            // 
            this.label_CCHPMessage.AutoSize = true;
            this.label_CCHPMessage.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_CCHPMessage.Location = new System.Drawing.Point(618, 282);
            this.label_CCHPMessage.Name = "label_CCHPMessage";
            this.label_CCHPMessage.Size = new System.Drawing.Size(45, 22);
            this.label_CCHPMessage.TabIndex = 22;
            this.label_CCHPMessage.Text = "-----";
            // 
            // panel_ResultShow
            // 
            this.panel_ResultShow.AutoScroll = true;
            this.panel_ResultShow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_ResultShow.Controls.Add(this.label_ResultShow);
            this.panel_ResultShow.Location = new System.Drawing.Point(165, 333);
            this.panel_ResultShow.Name = "panel_ResultShow";
            this.panel_ResultShow.Size = new System.Drawing.Size(633, 342);
            this.panel_ResultShow.TabIndex = 25;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButton_WholeYear);
            this.panel1.Controls.Add(this.radioButton_Duration);
            this.panel1.Location = new System.Drawing.Point(149, 165);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 58);
            this.panel1.TabIndex = 26;
            // 
            // label_dateTimePickerStart
            // 
            this.label_dateTimePickerStart.AutoSize = true;
            this.label_dateTimePickerStart.Font = new System.Drawing.Font("微軟正黑體", 10.2F);
            this.label_dateTimePickerStart.Location = new System.Drawing.Point(446, 157);
            this.label_dateTimePickerStart.Name = "label_dateTimePickerStart";
            this.label_dateTimePickerStart.Size = new System.Drawing.Size(45, 22);
            this.label_dateTimePickerStart.TabIndex = 27;
            this.label_dateTimePickerStart.Text = "-----";
            // 
            // label_dateTimePickerEnd
            // 
            this.label_dateTimePickerEnd.AutoSize = true;
            this.label_dateTimePickerEnd.Font = new System.Drawing.Font("微軟正黑體", 10.2F);
            this.label_dateTimePickerEnd.Location = new System.Drawing.Point(644, 157);
            this.label_dateTimePickerEnd.Name = "label_dateTimePickerEnd";
            this.label_dateTimePickerEnd.Size = new System.Drawing.Size(45, 22);
            this.label_dateTimePickerEnd.TabIndex = 28;
            this.label_dateTimePickerEnd.Text = "-----";
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("微軟正黑體", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Title.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label_Title.Location = new System.Drawing.Point(39, 17);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(438, 48);
            this.label_Title.TabIndex = 29;
            this.label_Title.Text = "使用牌照稅應納稅額試算";
            // 
            // label_Tips
            // 
            this.label_Tips.AutoSize = true;
            this.label_Tips.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Tips.Location = new System.Drawing.Point(43, 100);
            this.label_Tips.Name = "label_Tips";
            this.label_Tips.Size = new System.Drawing.Size(691, 44);
            this.label_Tips.TabIndex = 30;
            this.label_Tips.Text = "1. 本表試算之稅額僅供參考之用，不做任何證明，實際應納稅額仍應以稽徵機關核定為準。\r\n2. 使用牌照稅稅額對照表及電動車應納稅額表";
            // 
            // label_Tip
            // 
            this.label_Tip.AutoSize = true;
            this.label_Tip.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Tip.ForeColor = System.Drawing.Color.Red;
            this.label_Tip.Location = new System.Drawing.Point(42, 70);
            this.label_Tip.Name = "label_Tip";
            this.label_Tip.Size = new System.Drawing.Size(132, 25);
            this.label_Tip.TabIndex = 31;
            this.label_Tip.Text = "貼心小叮嚀：";
            // 
            // form_VehicleLicenseTax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 777);
            this.Controls.Add(this.label_Tip);
            this.Controls.Add(this.label_Tips);
            this.Controls.Add(this.label_Title);
            this.Controls.Add(this.label_dateTimePickerEnd);
            this.Controls.Add(this.label_dateTimePickerStart);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_ResultShow);
            this.Controls.Add(this.label_CCHPMessage);
            this.Controls.Add(this.label_DateEnd);
            this.Controls.Add(this.label_DateStart);
            this.Controls.Add(this.label_VehicleMessage);
            this.Controls.Add(this.button_Calculate);
            this.Controls.Add(this.button_Reset);
            this.Controls.Add(this.dateTimePicker_End);
            this.Controls.Add(this.dateTimePicker_Start);
            this.Controls.Add(this.comboBox_ccHP);
            this.Controls.Add(this.comboBox_Vehicle);
            this.Controls.Add(this.label_Result);
            this.Controls.Add(this.label_CCHP);
            this.Controls.Add(this.label_Used);
            this.Controls.Add(this.lable_Duration);
            this.Name = "form_VehicleLicenseTax";
            this.Text = "VehicleLicenseTax";
            this.Load += new System.EventHandler(this.form_VehicleLicenseTax_Load);
            this.panel_ResultShow.ResumeLayout(false);
            this.panel_ResultShow.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lable_Duration;
        private System.Windows.Forms.Label label_Used;
        private System.Windows.Forms.Label label_CCHP;
        private System.Windows.Forms.Label label_Result;
        private System.Windows.Forms.ComboBox comboBox_Vehicle;
        private System.Windows.Forms.ComboBox comboBox_ccHP;
        private System.Windows.Forms.RadioButton radioButton_WholeYear;
        private System.Windows.Forms.RadioButton radioButton_Duration;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Start;
        private System.Windows.Forms.DateTimePicker dateTimePicker_End;
        private System.Windows.Forms.Label label_ResultShow;
        private System.Windows.Forms.Button button_Reset;
        private System.Windows.Forms.Button button_Calculate;
        private System.Windows.Forms.Label label_VehicleMessage;
        private System.Windows.Forms.Label label_DateStart;
        private System.Windows.Forms.Label label_DateEnd;
        private System.Windows.Forms.Label label_CCHPMessage;
        private System.Windows.Forms.Panel panel_ResultShow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_dateTimePickerStart;
        private System.Windows.Forms.Label label_dateTimePickerEnd;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.Label label_Tips;
        private System.Windows.Forms.Label label_Tip;
    }
}

