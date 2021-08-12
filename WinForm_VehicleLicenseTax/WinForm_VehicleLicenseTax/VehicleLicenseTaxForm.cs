using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayHW3
{
    public partial class form_VehicleLicenseTax : Form
    {
        public form_VehicleLicenseTax()
        {
            InitializeComponent();
        }

        // 宣告變數
        private DateTime _dateStart; // 開始日
        private DateTime _dateEnd; // 結束日
        private DateTime _defaultStart; // 預設開始日
        private DateTime _defaultEnd; // 預設結束日
        private int _duration; // 期間
        private decimal _taxValue; // 各用途稅額
        List<int> eachYearDays = new List<int>(); // 實際天數(分子)
        List<int> eachLeapDays = new List<int>(); // 一年幾天(分母)(有可能是閏年)
        List<DateTime> eachDateFirst = new List<DateTime>(); // 開始日期
        List<DateTime> eachDateEnd = new List<DateTime>(); // 結束日期
        private bool dateTimePickerStart_Selected = false; // 開始日期的dateTimePicker是否有被滑鼠點選
        private bool dateTimePickerEnd_Selected = false; // 結束日期的dateTimePicker是否有被滑鼠點選

        public int LeapOrNot(int y) // 判斷是否為閏年
        {
            if (DateTime.IsLeapYear(y))
                return 366;
            else
                return 365;
        }
        private void radioButton_WholeYear_CheckedChanged(object sender, EventArgs e)
        {
            this.dateTimePicker_Start.Visible = false; // "全年度" >> 隱藏dateTimePicker
            this.dateTimePicker_End.Visible = false;
            this.dateTimePicker_Start.Value = _defaultStart;
            this.dateTimePicker_End.Value = _defaultEnd;
            this.dateTimePickerStart_Selected = false;
            this.dateTimePickerEnd_Selected = false;
            this.label_dateTimePickerStart.Visible = false;
            this.label_dateTimePickerEnd.Visible = false;
            this.label_DateStart.Visible = false;
            this.label_DateEnd.Visible = false;
        }
        private void radioButton_Duration_CheckedChanged(object sender, EventArgs e)
        {
            this.dateTimePicker_Start.Visible = true; // "依期間" >> 顯示dateTimePicker
            this.dateTimePicker_End.Visible = true;
            this.label_DateStart.Visible = true;
            this.label_DateEnd.Visible = true;
            this.dateTimePicker_Start.Value = _defaultStart;
            this.dateTimePicker_End.Value = DateTime.Today;
        }
        private void dateTimePicker_Start_MouseDown(object sender, MouseEventArgs e)
        {
            this.dateTimePickerStart_Selected = true; // 滑鼠點選開始dateTimePicker
        }
        private void dateTimePicker_End_MouseDown(object sender, MouseEventArgs e)
        {
            this.dateTimePickerEnd_Selected = true; // 滑鼠點選結束dateTimePicker
        }
        private void form_VehicleLicenseTax_Load(object sender, EventArgs e)
        {
            Init(); // 載入表單
        }
        private void button_Reset_Click(object sender, EventArgs e)
        {
            Init(); // 按下取消重填按鈕
        }
        private void comboBox_Vehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            setCCHPItems(); // 牌照用途的下拉式選單
        }
        private void comboBox_ccHP_SelectedIndexChanged(object sender, EventArgs e)
        {
            getTaxValue(); // 汽缸馬力的下拉式選單
        }

        #region 按下確定送出
        private void button_Calculate_Click(object sender, EventArgs e)
        {
            this.eachDateFirst.Clear();
            this.eachDateEnd.Clear();
            this.eachYearDays.Clear();
            this.eachLeapDays.Clear();

            this._dateStart = this.dateTimePicker_Start.Value; // 取得開始日
            this._dateEnd = this.dateTimePicker_End.Value;     // 取得結束日
            this._duration = new TimeSpan(this._dateEnd.Ticks - this._dateStart.Ticks).Days + 1; // 計算開始到結束的日數(結束-開始+1)

            int firstYear = this._dateStart.Year; // 最初那一年
            DateTime firstYearEnd = new DateTime(firstYear, 12, 31); // 最初那一年的年底
            int firstYearDuration = new TimeSpan(firstYearEnd.Ticks - this._dateStart.Ticks).Days + 1; // 計算最初那一年的期間
            int firstLeapOrNotDays = LeapOrNot(this._dateStart.Year); // 最初那一年是否為閏年

            int endYear = this._dateEnd.Year; // 最後那一年
            DateTime endYearFirst = new DateTime(endYear, 1, 1); // 最後那一年的年初
            int endYearDuration = new TimeSpan(this._dateEnd.Ticks - endYearFirst.Ticks).Days + 1; // 計算最後那一年的期間
            int endLeapOrNotDays = LeapOrNot(this._dateEnd.Year); // 最後那一年是否為閏年

            if (radioButton_WholeYear.Checked) // 全年度
            {
                buttonToPrint(firstYearDuration, firstLeapOrNotDays, endYearDuration, endLeapOrNotDays);
            }
            else if (this.dateTimePickerStart_Selected == true && this.dateTimePickerEnd_Selected == true)
            {
                buttonToPrint(firstYearDuration, firstLeapOrNotDays, endYearDuration, endLeapOrNotDays);
            }
            else
            {
                if (this.dateTimePickerStart_Selected == false) // 提示點選
                {
                    this.label_dateTimePickerStart.Visible = true;
                    this.label_dateTimePickerStart.Text = "請點選開始日期";
                }
                else if (this.dateTimePickerEnd_Selected == false)
                {
                    this.label_dateTimePickerEnd.Visible = true;
                    this.label_dateTimePickerEnd.Text = "請點選結束日期";
                }

            }
        }
        #endregion

        #region 閏年判斷
        private void buttonToPrint(int firstYearDuration, int firstLeapOrNotDays, int endYearDuration, int endLeapOrNotDays)
        {
            if (this._dateEnd.Year - this._dateStart.Year == 0) // 如果期間在同一年
            {
                if (LeapOrNot(this._dateStart.Year) == 366)
                {
                    this.eachDateFirst.Add(_dateStart);
                    this.eachDateEnd.Add(_dateEnd);
                    this.eachYearDays.Add(this._duration);
                    this.eachLeapDays.Add(366);
                    printResult();
                }
                else if ((LeapOrNot(this._dateStart.Year) == 365))
                {
                    this.eachDateFirst.Add(_dateStart);
                    this.eachDateEnd.Add(_dateEnd);
                    this.eachYearDays.Add(this._duration);
                    this.eachLeapDays.Add(365);
                    printResult();
                }
            }
            else if (this._dateEnd.Year - this._dateStart.Year == 1) // 如果有跨年份 (兩個區間)
            {
                DateTime firstYearEndAdd = new DateTime(_dateStart.Year, 12, 31);
                DateTime EndYearFirstAdd = new DateTime(_dateEnd.Year, 1, 1);

                this.eachDateFirst.Add(_dateStart);
                this.eachDateEnd.Add(firstYearEndAdd);
                this.eachDateFirst.Add(EndYearFirstAdd);
                this.eachDateEnd.Add(_dateEnd);

                this.eachYearDays.Add(firstYearDuration);
                this.eachLeapDays.Add(firstLeapOrNotDays);

                this.eachYearDays.Add(endYearDuration);
                this.eachLeapDays.Add(endLeapOrNotDays);

                printResult();
            }
            else if (this._dateEnd.Year - this._dateStart.Year > 1) // 如果跨了一整年 (三個區間)
            {
                DateTime firstYearEndAdd = new DateTime(_dateStart.Year, 12, 31);
                DateTime EndYearFirstAdd = new DateTime(_dateEnd.Year, 1, 1);

                this.eachDateFirst.Add(_dateStart); // 處理最初那一年
                this.eachDateEnd.Add(firstYearEndAdd);
                this.eachYearDays.Add(firstYearDuration);
                this.eachLeapDays.Add(firstLeapOrNotDays);

                for (int i = this._dateStart.Year + 1; i <= this._dateEnd.Year - 1; i++) // 處理中間年份
                {
                    int days = LeapOrNot(i);
                    DateTime MiddleYearFirstAdd = new DateTime(i, 1, 1);
                    DateTime MiddleYearEndAdd = new DateTime(i, 12, 31);
                    this.eachDateFirst.Add(MiddleYearFirstAdd);
                    this.eachDateEnd.Add(MiddleYearEndAdd);
                    this.eachYearDays.Add(days);
                    this.eachLeapDays.Add(days);
                }

                this.eachDateFirst.Add(EndYearFirstAdd); // 處理最後那一年
                this.eachDateEnd.Add(_dateEnd);
                this.eachYearDays.Add(endYearDuration);
                this.eachLeapDays.Add(endLeapOrNotDays);

                printResult();
            }
            else // 期間是否小於0天(一年以上的情況)
            {
                this.label_ResultShow.Visible = true;
                this.label_ResultShow.Text = "因為期間不可為負，麻煩請檢查您填入的年份 <3";
            }
        }
        #endregion

        #region 印出最終結果
        /// <summary> 印出最終的結果 </summary>
        private void printResult()
        {
            if (this._duration <= 0) // 期間是否小於0天(一年以內的情況)
            {
                this.label_ResultShow.Visible = true;
                this.label_ResultShow.Text = "期間不能為負值喲，麻煩請檢查您填入的月份~~";
            }
            else if (this.comboBox_Vehicle.SelectedIndex == -1) // 牌照用途是否選取
            {
                this.label_VehicleMessage.Visible = true;
                this.label_VehicleMessage.Text = "請選擇牌照用途";
                this.label_ResultShow.Text = "";
            }
            else if (this.comboBox_ccHP.SelectedIndex == -1) // 汽缸馬力是否選取
            {
                this.label_CCHPMessage.Visible = true;
                this.label_CCHPMessage.Text = "請選擇汽缸馬力";
                this.label_ResultShow.Text = "";
            }
            else // 印出結果
            {
                this.label_dateTimePickerStart.Visible = false;
                this.label_dateTimePickerEnd.Visible = false;
                this.label_VehicleMessage.Visible = false;
                this.label_CCHPMessage.Visible = false;
                this.label_ResultShow.Visible = true;

                decimal result;
                decimal resultSum = 0;
                this.label_ResultShow.Text = "";

                for (int Loop = 0; Loop < this.eachLeapDays.Count; Loop++) // 跑陣列中的筆數
                {
                    result = this._taxValue * this.eachYearDays[Loop] / this.eachLeapDays[Loop]; // 計算結果

                    if (result < 1) // 應納稅金小於零處理
                        result = 0;
                    else if (result > 1) // 應納稅金指定整數
                        result = Math.Truncate(result);

                    this.label_ResultShow.Text +=
                         $"使用期間： {this.eachDateFirst[Loop]:yyyy-MM-dd} ~ {this.eachDateEnd[Loop]:yyyy-MM-dd}\r\n" +
                         $"計算天數： 共 {this.eachYearDays[Loop]} 天\r\n" +
                         $"汽缸馬力： {this.comboBox_ccHP.Text}\r\n" +
                         $"牌照用途： {this.comboBox_Vehicle.Text}\r\n" +
                         $"計算公式： {this._taxValue} * {this.eachYearDays[Loop]} / {this.eachLeapDays[Loop]} = {result.ToString("#,0")} 元\r\n" +
                         $"應納稅額： 共 {result.ToString("#,0")} 元\r\n\r\n";
                    
                    resultSum += result; // 計算總額
                }
                this.label_ResultShow.Text += $"全部應納稅額為： {resultSum.ToString("#,0")} 元";
            }
        }
        #endregion

        #region 設定汽缸馬力的下拉式選單內容
        /// <summary> 設定CC/HP的ComboBox項目 </summary>
        private void setCCHPItems()
        {
            //透過Switch來指定牌照用途，接著使用For迴圈把CC/HP的項目加進去
            string vehicleType = this.comboBox_Vehicle.Text;
            switch (vehicleType)
            {
                case "機車":
                    {
                        this.comboBox_ccHP.Items.Clear();
                        List<string> ccName = new List<string>()
                        {
                            "150cc以下 / 12HP以下(12.2PS以下)","151cc-250cc / 12.1-20HP(12.3-20.3PS)",
                            "251cc-500cc / 20.1HP以上(20.4PS以上)","501cc-600cc","601cc-1200cc",
                            "1201cc-1800cc","1801cc或以上"
                        };
                        for (int i = 0; i < ccName.Count; i++)
                        {
                            this.comboBox_ccHP.Items.Add(ccName[i]);
                        }
                    }
                    break;
                case "貨車":
                    {
                        this.comboBox_ccHP.Items.Clear();
                        List<string> ccName = new List<string>()
                        {
                            "500cc以下","501cc-600cc","601cc-1200cc","1201cc-1800cc","1801cc-2400cc",
                            "2401cc-3000cc / 138HP以下(140.1PS以下)",
                            "3001cc-3600cc","3601cc-4200cc / 138.1-200HP(140.2-203.0PS)",
                            "4201cc-4800cc","4801cc-5400cc / 200.1-247HP(203.1-250.7PS)",
                            "5401cc-6000cc","6001cc-6600cc / 247.1-286HP(250.8-290.3PS)",
                            "6601cc-7200cc","7201cc-7800cc / 286.1-336HP(290.4-341.0PS)",
                            "7801cc-8400cc","8401cc-9000cc / 336.1-361HP(341.1-366.4PS)",
                            "9001cc-9600cc","9601cc-10200cc / 361.1HP以上(366.5PS以上)","10201cc以上"
                        };
                        for (int i = 0; i < ccName.Count; i++)
                        {
                            this.comboBox_ccHP.Items.Add(ccName[i]);
                        }
                    }
                    break;
                case "大客車":
                    {
                        this.comboBox_ccHP.Items.Clear();
                        List<string> ccName = new List<string>()
                        {
                            "500cc以下","501cc-600cc","601cc-1200cc",
                            "1201cc-1800cc","1801cc-2400cc","2401cc-3000cc / 138HP以下(140.1PS以下)",
                            "3001cc-3600cc","3601cc-4200cc / 138.1-200HP(140.2-203.0PS)",
                            "4201cc-4800cc","4801cc-5400cc / 200.1-247HP(203.1-250.7PS)",
                            "5401cc-6000cc","6001cc-6600cc / 247.1-286HP(250.8-290.3PS)",
                            "6601cc-7200cc","7201cc-7800cc / 286.1-336HP(290.4-341.0PS)",
                            "7801cc-8400cc","8401cc-9000cc / 336.1-361HP(341.1-366.4PS)",
                            "9001cc-9600cc","9601cc-10200cc / 361.1HP以上(366.5PS以上)","10201cc以上"
                        };
                        for (int i = 0; i < ccName.Count; i++)
                        {
                            this.comboBox_ccHP.Items.Add(ccName[i]);
                        }
                    }
                    break;
                case "自用小客車":
                    {
                        this.comboBox_ccHP.Items.Clear();
                        List<string> ccName = new List<string>()
                        {
                            "500cc以下 / 38HP以下(38.6PS以下)","501cc-600cc / 38.1-56HP(38.7-56.8PS)",
                            "601cc-1200cc / 56.1-83HP(56.9-84.2PS)","1201cc-1800cc / 83.1-182HP(84.3-184.7PS)",
                            "1801cc-2400cc / 182.1-262HP(184.8-265.9PS)","2401cc-3000cc / 262.1-322HP(266-326.8PS)",
                            "3001cc-4200cc / 322.1-414HP(326.9-420.2PS","4201cc-5400cc / 414.1-469HP(420.3-476.0PS)",
                            "5401cc-6600cc / 469.1-509HP(476.1-516.6PS)","6601cc-7800cc / 509.1HP以上(516.7PS以上)","7801cc以上"
                        };
                        for (int i = 0; i < ccName.Count; i++)
                        {
                            this.comboBox_ccHP.Items.Add(ccName[i]);
                        }
                    }
                    break;
                case "營業用小客車":
                    {
                        this.comboBox_ccHP.Items.Clear();
                        List<string> ccName = new List<string>()
                        {
                            "500cc以下 / 38HP以下(38.6PS以下)","501cc-600cc / 38.1-56HP(38.7-56.8PS)",
                            "601cc-1200cc / 56.1-83HP(56.9-84.2PS)","1201cc-1800cc / 83.1-182HP(84.3-184.7PS)",
                            "1801cc-2400cc / 182.1-262HP(184.8-265.9PS)","2401cc-3000cc / 262.1-322HP(266-326.8PS)",
                            "3001cc-4200cc / 322.1-414HP(326.9-420.2PS","4201cc-5400cc / 414.1-469HP(420.3-476.0PS)",
                            "5401cc-6600cc / 469.1-509HP(476.1-516.6PS)","6601cc-7800cc / 509.1HP以上(516.7PS以上)","7801cc以上"
                        };
                        for (int i = 0; i < ccName.Count; i++)
                        {
                            this.comboBox_ccHP.Items.Add(ccName[i]);
                        }
                    }
                    break;
                case "電動機車":
                    {
                        this.comboBox_ccHP.Items.Clear();
                        List<string> ccName = new List<string>()
                        {
                            "20.19以下(HP) / 21.54以下(PS)","20.20-40.03(HP) / 21.55-42.71(PS)",
                            "40.04-50.07(HP) / 42.72-53.43(PS)","50.08-58.79(HP) / 53.44-62.73(PS)",
                            "58.80-114.11(HP) / 62.74-121.76(PS)","114.12以上(HP) / 121.77以上(PS)"
                        };
                        for (int i = 0; i < ccName.Count; i++)
                        {
                            this.comboBox_ccHP.Items.Add(ccName[i]);
                        }
                    }
                    break;
                case "電動自用小客車":
                    {
                        this.comboBox_ccHP.Items.Clear();
                        List<string> ccName = new List<string>()
                        {
                            "38以下(HP) / 38.6以下(PS)","38.1-56(HP) / 38.7-56.8(PS)",
                            "56.1-83(HP) / 56.9-84.2(PS)","83.1-182(HP) / 84.3-184.7(PS)",
                            "182.1-262(HP) / 184.8-265.9(PS)","262.1-322(HP) / 266.0-326.8(PS)",
                            "322.1-414(HP) / 326.9-420.2(PS)","414.1-469(HP) / 420.3-476.0(PS)",
                            "469.1-509(HP) / 476.1-516.6(PS)","509.1以上(HP) / 516.7以上(PS)"
                        };
                        for (int i = 0; i < ccName.Count; i++)
                        {
                            this.comboBox_ccHP.Items.Add(ccName[i]);
                        }
                    }
                    break;
                case "電動營業用小客車":
                    {
                        this.comboBox_ccHP.Items.Clear();
                        List<string> ccName = new List<string>()
                        {
                            "38以下(HP) / 38.6以下(PS)","38.1-56(HP) / 38.7-56.8(PS)",
                            "56.1-83(HP) / 56.9-84.2(PS)","83.1-182(HP) / 84.3-184.7(PS)",
                            "182.1-262(HP) / 184.8-265.9(PS)","262.1-322(HP) / 266.0-326.8(PS)",
                            "322.1-414(HP) / 326.9-420.2(PS)","414.1-469(HP) / 420.3-476.0(PS)",
                            "469.1-509(HP) / 476.1-516.6(PS)","509.1以上(HP) / 516.7以上(PS)"
                        };
                        for (int i = 0; i < ccName.Count; i++)
                        {
                            this.comboBox_ccHP.Items.Add(ccName[i]);
                        }
                    }
                    break;
                case "電動貨車及大客車":
                    {
                        this.comboBox_ccHP.Items.Clear();
                        List<string> ccName = new List<string>()
                        {
                            "20.19以下(HP) / 21.54以下(PS)",
                            "20.20-40.03(HP) / 21.55-42.71(PS)",
                            "40.04-50.07(HP) / 42.72-53.43(PS)",
                            "50.08-58.79(HP) / 53.44-62.73(PS)",
                            "58.80-114.11(HP) / 62.74-121.76(PS)",
                            "114.12以上(HP) / 121.77以上(PS)"
                        };
                        for (int i = 0; i < ccName.Count; i++)
                        {
                            this.comboBox_ccHP.Items.Add(ccName[i]);
                        }
                    }
                    break;
                case "曳引車":
                    {
                        this.comboBox_ccHP.Items.Clear();
                        List<string> ccName = new List<string>()
                        {
                            "500cc以下","501cc-600cc","601cc-1200cc","1201cc-1800cc","1801cc-2400cc",
                            "2401cc-3000cc / 138HP以下(140.1PS以下)",
                            "3001cc-3600cc","3601cc-4200cc / 138.1-200HP(140.2-203.0PS)",
                            "4201cc-4800cc","4801cc-5400cc / 200.1-247HP(203.1-250.7PS)",
                            "5401cc-6000cc","6001cc-6600cc / 247.1-286HP(250.8-290.3PS)",
                            "6601cc-7200cc","7201cc-7800cc / 286.1-336HP(290.4-341.0PS)",
                            "7801cc-8400cc","8401cc-9000cc / 336.1-361HP(341.1-366.4PS)",
                            "9001cc-9600cc","9601cc-10200cc / 361.1HP以上(366.5PS以上)","10201cc以上"
                        };
                        for (int i = 0; i < ccName.Count; i++)
                        {
                            this.comboBox_ccHP.Items.Add(ccName[i]);
                        }
                    }
                    break;
            }
        }
        #endregion

        #region 取得對應稅金額度的實作
        /// <summary> 取得_taxValue稅金 </summary>
        private void getTaxValue()
        {
            // 先建立 "CCHP" 與 "應納稅額" 的Dictionary
            Dictionary<string, decimal> Motorcycle = new Dictionary<string, decimal>()
            {
                { "150cc以下 / 12HP以下(12.2PS以下)", 0 },{ "151cc-250cc / 12.1-20HP(12.3-20.3PS)", 800 },
                { "251cc-500cc / 20.1HP以上(20.4PS以上)", 1620 }, { "501cc-600cc", 2160 },
                { "601cc-1200cc", 4320 }, { "1201cc-1800cc", 7120 }, { "1801cc或以上", 11230 },
            };
            Dictionary<string, decimal> Truck = new Dictionary<string, decimal>()
            {
                { "500cc以下", 900 },{ "501cc-600cc", 1080 },{ "601cc-1200cc", 1800 },{ "1201cc-1800cc", 2700 },
                { "1801cc-2400cc", 3600 },{ "2401cc-3000cc / 138HP以下(140.1PS以下)", 4500 },
                { "3001cc-3600cc", 5400 },{ "3601cc-4200cc / 138.1-200HP(140.2-203.0PS)", 6300 },
                { "4201cc-4800cc", 7200 },{ "4801cc-5400cc / 200.1-247HP(203.1-250.7PS)", 8100 },
                { "5401cc-6000cc", 9000 },{ "6001cc-6600cc / 247.1-286HP(250.8-290.3PS)", 9900 },
                { "6601cc-7200cc", 10800 },{ "7201cc-7800cc / 286.1-336HP(290.4-341.0PS)", 11700 },
                { "7801cc-8400cc", 12600 },{ "8401cc-9000cc / 336.1-361HP(341.1-366.4PS)", 13500 },
                { "9001cc-9600cc", 14400 },{ "9601cc-10200cc / 361.1HP以上(366.5PS以上)", 15300 },{ "10201cc以上", 16200 }
            };
            Dictionary<string, decimal> Coach = new Dictionary<string, decimal>()
            {
                { "500cc以下", 0 },{ "501cc-600cc", 1080 },{ "601cc-1200cc", 1800 },
                { "1201cc-1800cc", 2700 },{ "1801cc-2400cc", 3600 },
                { "2401cc-3000cc / 138HP以下(140.1PS以下)", 4500 },{ "3001cc-3600cc", 5400 },
                { "3601cc-4200cc / 138.1-200HP(140.2-203.0PS)", 6300 },{ "4201cc-4800cc", 7200 },
                { "4801cc-5400cc / 200.1-247HP(203.1-250.7PS)", 8100 },{ "5401cc-6000cc", 9000 },
                { "6001cc-6600cc / 247.1-286HP(250.8-290.3PS)", 9900 },{ "6601cc-7200cc", 10800 },
                { "7201cc-7800cc / 286.1-336HP(290.4-341.0PS)", 11700 },{ "7801cc-8400cc", 12600 },
                { "8401cc-9000cc / 336.1-361HP(341.1-366.4PS)", 13500 },{ "9001cc-9600cc", 14400 },
                { "9601cc-10200cc / 361.1HP以上(366.5PS以上)", 15300 },{ "10201cc以上", 16200 }
            };
            Dictionary<string, decimal> Car = new Dictionary<string, decimal>()
            {
                { "500cc以下 / 38HP以下(38.6PS以下)", 1620 },{ "501cc-600cc / 38.1-56HP(38.7-56.8PS)", 2160 },
                { "601cc-1200cc / 56.1-83HP(56.9-84.2PS)", 4320 },{ "1201cc-1800cc / 83.1-182HP(84.3-184.7PS)", 7120 },
                { "1801cc-2400cc / 182.1-262HP(184.8-265.9PS)", 11230 },{ "2401cc-3000cc / 262.1-322HP(266-326.8PS)", 15210 },
                { "3001cc-4200cc / 322.1-414HP(326.9-420.2PS", 28220 },{ "4201cc-5400cc / 414.1-469HP(420.3-476.0PS)", 46170 },
                { "5401cc-6600cc / 469.1-509HP(476.1-516.6PS)", 69690 },{ "6601cc-7800cc / 509.1HP以上(516.7PS以上)", 117000 },
                { "7801cc以上", 151200 }
            };
            Dictionary<string, decimal> CommercialCar = new Dictionary<string, decimal>()
            {
                { "500cc以下 / 38HP以下(38.6PS以下)", 900 },{ "501cc-600cc / 38.1-56HP(38.7-56.8PS)", 1260 },
                { "601cc-1200cc / 56.1-83HP(56.9-84.2PS)", 2160 },{ "1201cc-1800cc / 83.1-182HP(84.3-184.7PS)", 3060 },
                { "1801cc-2400cc / 182.1-262HP(184.8-265.9PS)", 6480 },{ "2401cc-3000cc / 262.1-322HP(266-326.8PS)", 9900 },
                { "3001cc-4200cc / 322.1-414HP(326.9-420.2PS", 16380 },{ "4201cc-5400cc / 414.1-469HP(420.3-476.0PS)", 24300 },
                { "5401cc-6600cc / 469.1-509HP(476.1-516.6PS)", 33660 },{ "6601cc-7800cc / 509.1HP以上(516.7PS以上)", 44460 },
                { "7801cc以上", 56700 }
            };
            Dictionary<string, decimal> eMotorcycle = new Dictionary<string, decimal>()
            {
                { "20.19以下(HP) / 21.54以下(PS)", 0 },{ "20.20-40.03(HP) / 21.55-42.71(PS)", 800 },
                { "40.04-50.07(HP) / 42.72-53.43(PS)", 1620 },{ "50.08-58.79(HP) / 53.44-62.73(PS)", 2160 },
                { "58.80-114.11(HP) / 62.74-121.76(PS)", 4320 },{ "114.12以上(HP) / 121.77以上(PS)", 7120 }
            };
            Dictionary<string, decimal> eCar = new Dictionary<string, decimal>()
            {
                { "38以下(HP) / 38.6以下(PS)", 1620 },{ "38.1-56(HP) / 38.7-56.8(PS)", 2160 },
                { "56.1-83(HP) / 56.9-84.2(PS)", 4320 },{ "83.1-182(HP) / 84.3-184.7(PS)", 7120 },
                { "182.1-262(HP) / 184.8-265.9(PS)", 11230 },{ "262.1-322(HP) / 266.0-326.8(PS)", 15210 },
                { "322.1-414(HP) / 326.9-420.2(PS)", 28220 },{ "414.1-469(HP) / 420.3-476.0(PS)", 46170 },
                { "469.1-509(HP) / 476.1-516.6(PS)", 69690 },{ "509.1以上(HP) / 516.7以上(PS)", 117000 }
            };
            Dictionary<string, decimal> eCommercialCar = new Dictionary<string, decimal>()
            {
                { "38以下(HP) / 38.6以下(PS)", 900 },{ "38.1-56(HP) / 38.7-56.8(PS)", 1260 },
                { "56.1-83(HP) / 56.9-84.2(PS)", 2160 },{ "83.1-182(HP) / 84.3-184.7(PS)", 3060 },
                { "182.1-262(HP) / 184.8-265.9(PS)", 6480 },{ "262.1-322(HP) / 266.0-326.8(PS)", 9900 },
                { "322.1-414(HP) / 326.9-420.2(PS)", 16380 },{ "414.1-469(HP) / 420.3-476.0(PS)", 24300 },
                { "469.1-509(HP) / 476.1-516.6(PS)", 33660 },{ "509.1以上(HP) / 516.7以上(PS)", 44460 }
            };
            Dictionary<string, decimal> eTruckCoach = new Dictionary<string, decimal>()
            {
                { "20.19以下(HP) / 21.54以下(PS)", 0 },{ "20.20-40.03(HP) / 21.55-42.71(PS)", 800 },
                { "40.04-50.07(HP) / 42.72-53.43(PS)", 1620 },{ "50.08-58.79(HP) / 53.44-62.73(PS)", 2160 },
                { "58.80-114.11(HP) / 62.74-121.76(PS)", 4320 },{ "114.12以上(HP) / 121.77以上(PS)", 7120 }
            };
            Dictionary<string, decimal> Tractor = new Dictionary<string, decimal>()
            {
                { "500cc以下", 1170 },{ "501cc-600cc", 1404 },{ "601cc-1200cc", 2340 },
                { "1201cc-1800cc", 3510 },{ "1801cc-2400cc", 4680 },
                { "2401cc-3000cc / 138HP以下(140.1PS以下)", 5850 },{ "3001cc-3600cc", 7020 },
                { "3601cc-4200cc / 138.1-200HP(140.2-203.0PS)", 8190 },{ "4201cc-4800cc", 9360 },
                { "4801cc-5400cc / 200.1-247HP(203.1-250.7PS)", 10530 },{ "5401cc-6000cc", 11700 },
                { "6001cc-6600cc / 247.1-286HP(250.8-290.3PS)", 12870 },{ "6601cc-7200cc", 14040 },
                { "7201cc-7800cc / 286.1-336HP(290.4-341.0PS)", 15210 },{ "7801cc-8400cc", 16380 },
                { "8401cc-9000cc / 336.1-361HP(341.1-366.4PS)", 17550 },{ "9001cc-9600cc", 18720 },
                { "9601cc-10200cc / 361.1HP以上(366.5PS以上)", 19890 },{ "10201cc以上", 21060 }
            };

            // 利用 Dictionary 將上面的資料包裝起來，使之連結Switch的 "牌照用途"
            Dictionary<string, Dictionary<string, decimal>> FindType = new Dictionary<string, Dictionary<string, decimal>>()
            {
                {"機車", Motorcycle }, {"貨車", Truck }, {"大客車", Coach }, {"自用小客車", Car },
                {"營業用小客車", CommercialCar }, {"電動機車", eMotorcycle }, {"電動自用小客車", eCar },
                {"電動營業用小客車", eCommercialCar }, {"電動貨車及大客車", eTruckCoach }, {"曳引車", Tractor }
            };

            // 然後用 Key："牌照用途" 來找到 Value： "CCHP"
            Dictionary<string, decimal> FindTax = FindType[Convert.ToString(this.comboBox_Vehicle.Text)];

            // 再透過 Key："CCHP" 查找出 Value： "稅金"
            this._taxValue = FindTax[Convert.ToString(this.comboBox_ccHP.Text)];
        }
        #endregion

        #region 控制項初始化
        /// <summary> 控制項初始化 </summary>
        private void Init() // 預設項目
        {
            this._defaultStart = new DateTime(DateTime.Now.Year, 1, 1);
            this._defaultEnd = new DateTime(DateTime.Now.Year, 12, 31);

            this.dateTimePicker_Start.Value = _defaultStart;    // 開始日為今年年初
            this.dateTimePicker_End.Value = _defaultEnd;        // 結束日為今年年底
            this.radioButton_WholeYear.Checked = true;          // 勾選"全年度"
            this.label_DateStart.Visible = false;               // 隱藏"從"
            this.label_DateEnd.Visible = false;                 // 隱藏"到"
            this.dateTimePicker_Start.Visible = false;          // 隱藏開始dateTimePicker
            this.dateTimePicker_End.Visible = false;            // 隱藏結束dateTimePicker
            this.comboBox_Vehicle.SelectedIndex = -1;           // 牌照用途為空
            this.label_VehicleMessage.Visible = false;          // 隱藏用途錯誤訊息
            this.label_CCHPMessage.Visible = false;             // 隱藏汽缸錯誤訊息
            this.comboBox_ccHP.Items.Clear();                   // 清空CCHP內容
            this.label_ResultShow.Visible = false;              // 結果尚不顯示
            this.dateTimePickerStart_Selected = false;          // 開始dateTimePicker點選與否
            this.dateTimePickerStart_Selected = false;          // 結束dateTimePicker點選與否
            this.label_dateTimePickerStart.Visible = false;     // 開始dateTimePicker點選提示
            this.label_dateTimePickerEnd.Visible = false;       // 結束dateTimePicker點選提示
        }
        #endregion
    }
}

// 機車 = Motorcycle
// 貨車 = Truck
// 大客車 = Coach
// 自用小客車 = Car
// 營業用小客車 = CommercialCar
// 電動機車 = eMotorcycle
// 電動自用小客車 = eCar
// 電動營業用小客車 = eCommercialCar
// 電動貨車及大客車 = eTruckCoach
// 曳引車 = Tractor