using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SpiderApp.entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Management;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace SpiderApp
{
    public partial class Spider : Form
    {
        //计时器  
        private System.Windows.Forms.Timer tm = new System.Windows.Forms.Timer();
        //自动重置事件类    
        //主要用到其两个方法 WaitOne() 和 Set() , 前者阻塞当前线程，后者通知阻塞线程继续往下执行  
        AutoResetEvent autoEvent = new AutoResetEvent(false);

        private FileInfo fileExcelLoad;
        private string fileNameLoad;
        private IList<phone> phoneList = new List<phone>();
        private IList<user> userList = new List<user>();
        string cookie = "";
        private int spiderNum = 0;
        int xmlnamenum = 0;

        public Spider()
        {
            InitializeComponent();
            ProgressBar.CheckForIllegalCrossThreadCalls = false;
            tm.Interval = 1;
            tm.Tick += new EventHandler(tm_Tick);

        }
        //计时器 事件  
        void tm_Tick(object sender, EventArgs e)
        {
            autoEvent.Set(); //通知阻塞的线程继续执行  
        }



        private void btbadd_Click(object sender, EventArgs e)
        {
            spider();


        }

        public void spider()
        {

            if (string.IsNullOrEmpty(txtphone.Text))
            {
                MessageBox.Show("请输入手机号");
                return;
            }
            WebSpider Spider = new WebSpider();
            Spider.OnStartEvent += (s, e) =>
            {
                Invoke(new Action(() =>
                {
                    LogHelper.WriteLog("开始抓取");
                    string SpiderTime = DateTime.Now.ToString("yyyy-MM-dd");
                    txtview.AppendText(txtphone.Text + " 开始" + Environment.NewLine);
                }));

            };
            Spider.OnExceptionEvent += (s, e) =>
            {
                Invoke(new Action(() =>
                {
                    txtview.AppendText(txtphone.Text + " 异常：" + e.Exception.Message + Environment.NewLine);
                }));
            };

            Spider.OnCompletedEvent += (s, e) =>
            {
                Invoke(new Action(() =>
                {

                    txtview.AppendText(txtphone.Text + " 查询结束" + Environment.NewLine);
                    txtview.AppendText(txtphone.Text + " 耗时：" + e.MilliSeconds + Environment.NewLine);
                }));
            };
            btbadd.Enabled = false;
            txtview.AppendText(txtphone.Text + " 开始查询，请稍后" + Environment.NewLine);
            if (cookie == "")
            {
                HttpClient httpClient = new HttpClient();
                string content = httpClient.GetResponse("", "http://211.139.145.137/businessHsh/hshShop/wochacha/index.jsps?p1=554557782b486871724a756e3368474c53663167366b6f37554246314d39377573415241456756592f6570654765635944574d35354538444951492b2f4875705a56794f4c7a687363594339426d4a773438635742543341586b326d7464685737644e386f7351686561553d", "", "");
                cookie = httpClient.Cookie;
            }
            HttpClient httpClient2 = new HttpClient(cookie);
            string content2 = httpClient2.GetResponse("", "http://211.139.145.137/businessHsh/hshShop/wochacha/search.jsps?" + unit.ConvertDateTimeToLong(DateTime.Now, 1) + "&kw=" + txtphone.Text + "", "", "");

            RegFunc regFunc = new RegFunc();

            string tem_1 = regFunc.GetStr(content2, "sale02-top", "<input type=\"hidden\" name=\"mobile\"");
            ArrayList tem_1list = regFunc.GetStrArr(tem_1, "<p", "</p");
            for (int m = 0; m < tem_1list.Count; m++)
            {
                txtview.AppendText(txtphone.Text + " " + regFunc.GetStr(tem_1list[m].ToString(), "sale02-w\">", "</span") + regFunc.GetStr(tem_1list[m].ToString(), "<span>", "</span") + Environment.NewLine);


            }

            ArrayList list = regFunc.GetStrArr(content2, "sale02-acmain clearfix", "button");
            txtview.AppendText(txtphone.Text + " 找到" + list.Count + "条可办理业务" + Environment.NewLine);
            for (int n = 0; n < list.Count; n++)
            {
                txtview.AppendText(txtphone.Text + " " + regFunc.GetStr(list[n].ToString(), "sale02-accont-p1\">", "</p") + "条可办理业务" + Environment.NewLine);

                txtview.AppendText(txtphone.Text + " " + regFunc.GetStrArr(list[n].ToString(), "zicolor9 zisize14\">", "</p")[1].ToString() + "" + Environment.NewLine);

            }

            txtview.AppendText(txtphone.Text + "结束");
            btbadd.Enabled = true;
        }


        public void spidermain()
        {



            WebSpider Spider = new WebSpider();
            Spider.OnStartEvent += (s, e) =>
            {
                Invoke(new Action(() =>
                {
                    LogHelper.WriteLog("开始抓取");
                    string SpiderTime = DateTime.Now.ToString("yyyy-MM-dd");
                    txtview.AppendText(" 开始" + Environment.NewLine);
                }));

            };
            Spider.OnExceptionEvent += (s, e) =>
            {
                Invoke(new Action(() =>
                {
                    txtview.AppendText(" 异常：" + e.Exception.Message + Environment.NewLine);
                }));
            };

            Spider.OnCompletedEvent += (s, e) =>
            {
                Invoke(new Action(() =>
                {

                    txtview.AppendText(" 查询结束" + Environment.NewLine);
                    txtview.AppendText(" 耗时：" + e.MilliSeconds + Environment.NewLine);
                }));
            };
            btbadd.Enabled = false;
            txtview.AppendText(" 开始查询，请稍后" + Environment.NewLine);


            foreach (phone itme2 in phoneList)
            {

                user itme = getuser();

                //获取cookie
                if (itme.token != "")
                {

                    cleadata(itme, itme2);
                    autoEvent.WaitOne();  //阻塞当前线程，等待通知以继续执行
                    Thread.Sleep(Convert.ToInt32(spidertime.Value));
                }
            }

            btnstart.Enabled = true;
            btbadd.Enabled = true;
            txtview.AppendText("手机号抓取结束" + Environment.NewLine);


        }


        public user getuser()
        {
            user use = new user();

            for (int i = 0; i < userList.Count; i++)
            {
                if (userList[i].token != "")
                {
                    use = userList[i];
                    userList.Remove(use);
                    userList.Add(use);
                    break;
                }
                else
                {
                    userList.Remove(userList[i]);
                }
            }
            return use;
        }

        public void cleadata(user itme, phone phone)
        {
            try
            {


                phone.spidernum++;
                if (phone.num != "")
                {
                    txtview.AppendText(phone.num + " 开始抓取" + phone.num + Environment.NewLine);
                    if (itme.cookie == "")
                    {


                        HttpClient httpClient = new HttpClient();
                        string content = httpClient.GetResponse("", "http://211.139.145.137/businessHsh/hshShop/wochacha/index.jsps?p1=" + itme.token + "", "", "");
                        itme.cookie = httpClient.Cookie;
                    }
                    Thread.Sleep(1000);

                    HttpClient httpClient2 = new HttpClient(itme.cookie);
                    string content2 = httpClient2.GetResponse("", "http://211.139.145.137/businessHsh/hshShop/wochacha/search.jsps?" + unit.ConvertDateTimeToLong(DateTime.Now, 1) + "&kw=" + phone.num + "", "", "");
                    RegFunc regFunc = new RegFunc();
                    string tem_1 = regFunc.GetStr(content2, "sale02-top", "<input type=\"hidden\" name=\"mobile\"");
                    ArrayList tem_1list = regFunc.GetStrArr(tem_1, "<p", "</p");

                    for (int m = 0; m < tem_1list.Count; m++)
                    {
                        txtview.AppendText(phone.num + " " + regFunc.GetStr(tem_1list[m].ToString(), "sale02-w\">", "</span") + regFunc.GetStr(tem_1list[m].ToString(), "<span>", "</span") + Environment.NewLine);
                    }

                    if (tem_1list.Count > 0)
                    {

                        spiderNum++;
                        XmlOperation xml = new XmlOperation("down\\bddata" + xmlnamenum + ".xml", "bddatalist");

                        lblnum2.Text = spiderNum.ToString();
                        textBox1.AppendText(phone.num + Environment.NewLine);

                        Dictionary<string, string> attributes = new Dictionary<string, string>();
                        attributes.Add("id", spiderNum.ToString());
                        attributes.Add("spiderTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        attributes.Add("spiderIP", Get_UserIP());
                        attributes.Add("spiderUser", itme.userName);
                        attributes.Add("spiderMAC", GetNetCardMAC());
                        attributes.Add("phone", phone.num);
                        if (tem_1list.Count == 1) {
                            attributes.Add("isUse", "");
                            attributes.Add("issm", "");
                            attributes.Add("gcar","");
                        }
                        else {
                            attributes.Add("isUse", regFunc.GetStr(tem_1list[1].ToString(), "<span>", "</span"));
                            attributes.Add("issm", regFunc.GetStr(tem_1list[2].ToString(), "<span>", "</span"));
                            attributes.Add("gcar", regFunc.GetStr(tem_1list[3].ToString(), "<span>", "</span"));
                        }
                  
                        ArrayList list2 = regFunc.GetStrArr(content2, "sale02-acmain clearfix", "button");
                        txtview.AppendText(phone.num + " 找到" + list2.Count + "条可办理业务" + Environment.NewLine);
                        string yhhd = "";
                        for (int n = 0; n < list2.Count; n++)
                        {
                            txtview.AppendText(phone.num + " " + regFunc.GetStr(list2[n].ToString(), "sale02-accont-p1\">", "</p") + "条可办理业务" + Environment.NewLine);

                            txtview.AppendText(phone.num + " " + regFunc.GetStrArr(list2[n].ToString(), "zicolor9 zisize14\">", "</p")[0].ToString() + "" + Environment.NewLine);
                            yhhd += regFunc.GetStrArr(list2[n].ToString(), "zicolor9 zisize14\">", "</p")[0].ToString() + ",";
                        }
                        attributes.Add("yhhd", list2.Count > 0 ? yhhd.Substring(0, yhhd.Length - 1) : "");
                        xml.Write("bddata", "", attributes);

                        //每500个旧导出文件
                        if (spiderNum % phonebutnum.Value == 0 && spiderNum != 0)
                        {
                            //导出
                            using (FileStream fs = File.Open("down\\bddata" + xmlnamenum + ".xml", FileMode.Open, FileAccess.Read))
                            {

                                StreamReader sr = new StreamReader(fs);
                                string text = sr.ReadToEnd();

                                //text = "<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"yes\"?><bddatalist><bddata id=\"0\" spiderUser=\"JMADB01026\" spiderTime=\"187320140938\" spiderMAC=\"00:50:56:C0:00:0100:50:56:C0:00:08DC:53:60:51:EC:D5DE:53:60:51:EC:D52E:15:8F:9D:22:8F\" spiderIP=\"172.19.223.1\" phone=\"172.19.223.1\" issm=\"88元4G飞享套餐\" isUse=\"已审核\" gcar=\"4G TD-LTE 128K USIM卡（现场写卡、2FF/3FF/4FF三切）\"> </bddata></bddatalist>";
                                var _bddataList = XmlSerializeHelper.DeSerialize<bddatalist>(text);
                                List<bddata> _bddata = _bddataList.DataSource;
                                DownloadFileInfo downloadFile = ConvertLogToExcel(_bddata);
                                xmlnamenum++;
                            }
                                
                        

                        }
                        else if (spiderNum >= phoneList.Count)
                        {
                            //导出

                            using (FileStream fs = File.Open("down\\bddata" + xmlnamenum + ".xml", FileMode.Open, FileAccess.Read))
                            {

                                StreamReader sr = new StreamReader(fs);
                                string text = sr.ReadToEnd();

                                //text = "<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"yes\"?><bddatalist><bddata id=\"0\" spiderUser=\"JMADB01026\" spiderTime=\"187320140938\" spiderMAC=\"00:50:56:C0:00:0100:50:56:C0:00:08DC:53:60:51:EC:D5DE:53:60:51:EC:D52E:15:8F:9D:22:8F\" spiderIP=\"172.19.223.1\" phone=\"172.19.223.1\" issm=\"88元4G飞享套餐\" isUse=\"已审核\" gcar=\"4G TD-LTE 128K USIM卡（现场写卡、2FF/3FF/4FF三切）\"> </bddata></bddatalist>";
                                var _bddataList = XmlSerializeHelper.DeSerialize<bddatalist>(text);
                                List<bddata> _bddata = _bddataList.DataSource;
                                DownloadFileInfo downloadFile = ConvertLogToExcel(_bddata);
                                xmlnamenum++;
                            }

                        }



                        txtview.AppendText(phone.num + " 抓取结束" + phone.num + Environment.NewLine);
                    }
                    else
                    {
                        if (phone.spidernum <= 3)
                        {
                            txtview.AppendText(phone.num + "第" + phone.spidernum + "次抓取" + Environment.NewLine);
                            cleadata(itme, phone);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                LogHelper.WriteLog(e.ToString());

            }
        }




        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void btnChoseFile_Click(object sender, EventArgs e)
        {

        }

        private void btbse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件";
            dialog.Filter = "Excel文件(*.xls)|*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileNameLoad = dialog.FileName;
                fileExcelLoad = new FileInfo(fileNameLoad);
                tbFilePath.Text = fileNameLoad;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbFilePath.Text))
            {
                ImportExcel(fileExcelLoad);
            }
            else
            {
                MessageBox.Show("请导入手机号");
            }

        }

        private void ImportExcel(FileInfo file)
        {
            string fileName = file.FullName;

            /*You konw that? Crash is AWESOME*/
            //try

            /*读取文件*/
            using (FileStream fileStream = File.OpenRead(fileName))
            {


                XSSFWorkbook workBook = new XSSFWorkbook(fileStream);
                /*读取第一个sheet，零基*/
                ISheet sheet = workBook.GetSheetAt(0);
                phoneList.Clear();
                /*通常第一行是标题行，从第二行开始进行循环*/
                for (int j = 1; j <= sheet.LastRowNum; j++)
                {
                    /*找到Excel对应行数的行*/
                    IRow dataRow = sheet.GetRow(j);

                    string num = dataRow.GetCell(0).ToString().Trim();//读取第j行的第3列数据(零基)

                    phone p = new phone();
                    phoneList.Add(new phone() { num = num, spidernum = 1 });

                }
                label7.Text = "已经导入" + phoneList.Count.ToString() + "条手机号";

                // ShowListView();//导入完成后刷新列表
            }
        }

        private void btbadd_Click_1(object sender, EventArgs e)
        {
            spider();
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            if (phoneList.Count <= 0)
            {
                MessageBox.Show("请导入手机号");
                return;
            }
            button1.Enabled = true;
            btnstart.Enabled = false;

            int spiderNum = 0;
            int xmlnamenum = 0;

            tm.Start();
            Thread th = new Thread(spidermain);
            th.Start();



        }


        private void Spider_Load(object sender, EventArgs e)
        {
            using (FileStream fs = File.Open("entity\\user.xml", FileMode.Open, FileAccess.Read)) {
                StreamReader sr = new StreamReader(fs);
                string text = sr.ReadToEnd();
                var list = XmlSerializeHelper.DeSerialize<userList>(text);
                userList = list.DataSource;
                url_comb.DataSource = list.DataSource;
                url_comb.ValueMember = "token";
                url_comb.DisplayMember = "userName";
                button1.Enabled = false;
            }
           
        
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "暂停")
            {
                button1.Text = "继续";

                tm.Stop();

            }
            else
            {
                button1.Text = "暂停";
                tm.Start();
            }
        }

        public static string GettimeNum()
        {
            string time = DateTime.Now.ToString().Replace(" ", "").Replace("/", "").Replace(":", "").Replace("-", "");
            time = time.Substring(2, time.Length - 2).Insert(4, time.Remove(2));
            return time;
        }

        /// <summary>
        /// 获取网卡的MAC地址
        /// </summary>
        /// <returns>返回一个string</returns>
        public string GetNetCardMAC()
        {
            try
            {
                string stringMAC = "";
                ManagementClass MC = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection MOC = MC.GetInstances();
                foreach (ManagementObject MO in MOC)
                {
                    if ((bool)MO["IPEnabled"] == true)
                    {
                        stringMAC += MO["MACAddress"].ToString();
                    }
                }
                return stringMAC;
            }
            catch
            {
                return "";
            }

        }

        /// <summary>
        /// 获取本地IP
        /// </summary>
        /// <returns></returns>
        public string Get_UserIP()
        {
            string ip = "";
            string strHostName = Dns.GetHostName(); //得到本机的主机名
            IPHostEntry ipEntry = Dns.GetHostByName(strHostName); //取得本机IP
            if (ipEntry.AddressList.Length > 0)
            {
                ip = ipEntry.AddressList[0].ToString();
            }
            return ip;


        }



        private static DownloadFileInfo ConvertLogToExcel(List<bddata> list)
        {

            DownloadFileInfo info = new DownloadFileInfo();
            try
            {
                //操作时间 用户名 操作类型 描述 
                IWorkbook workbook = new HSSFWorkbook();


                ISheet sheet = workbook.CreateSheet("本地优惠");
                IRow row0 = sheet.CreateRow(0);
                int dtRowsCount = list.Count;
                int SheetCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(dtRowsCount) / 65536));
                int SheetNum = 1;
                int rowIndex = 1;
                int tempIndex = 1; //标示 

                row0.CreateCell(0).SetCellValue("序号");
                row0.CreateCell(1).SetCellValue("采集时间");
                row0.CreateCell(2).SetCellValue("采集IP");
                row0.CreateCell(3).SetCellValue("采集账号");
                row0.CreateCell(4).SetCellValue("采集设备");
                row0.CreateCell(5).SetCellValue("号码");
                row0.CreateCell(6).SetCellValue("当前使用");
                row0.CreateCell(7).SetCellValue("实名登记");
                row0.CreateCell(8).SetCellValue("4G卡");
                row0.CreateCell(9).SetCellValue("预存优惠");
                row0.CreateCell(10).SetCellValue("优惠活动");

                HSSFCellStyle style = (HSSFCellStyle)workbook.CreateCellStyle();
                HSSFDataFormat format = (HSSFDataFormat)workbook.CreateDataFormat();
                style.DataFormat = format.GetFormat("yyyy-MM-dd HH:mm:ss");


                for (int i = 0; i < list.Count; i++)
                {
                    IRow row = sheet.CreateRow(i + 1);
                    //row.CreateCell(0).SetCellValue(list[i].OperateTime);
                    ICell cell = row.CreateCell(0);
                    cell.CellStyle = style;
                    //cell.SetCellValue(list[i].OperateTime);
                    cell.Sheet.SetColumnWidth(0, 18 * 256);
                    row.CreateCell(0).SetCellValue(list[i].id);
                    row.CreateCell(1).SetCellValue(list[i].spiderTime);
                    row.CreateCell(2).SetCellValue(list[i].spiderIP);
                    row.CreateCell(3).SetCellValue(list[i].spiderUser);
                    row.CreateCell(4).SetCellValue(list[i].spiderMAC);
                    row.CreateCell(5).SetCellValue(list[i].phone);
                    row.CreateCell(6).SetCellValue(list[i].isUse);
                    row.CreateCell(7).SetCellValue(list[i].issm);
                    row.CreateCell(8).SetCellValue(list[i].gcar);
                    row.CreateCell(9).SetCellValue("");
                    var arr = list[i].yhhd.Split(',');
                    for (int k = 0; k < arr.Length; k++)
                    {
                        row.CreateCell(10 + k).SetCellValue(arr[k]);
                    }

                }
                string fileName = "本地优惠" + "(" + DateTime.Now.ToString("yyyyMMdd HHmmss") + ")" + ".xls";
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "/down", fileName);
                info.FilePath = path;
                info.FileName = fileName;
                using (FileStream fs = System.IO.File.OpenWrite(path))
                {
                    info.FileSize = fs.Length;
                    workbook.Write(fs);

                }
            }
            catch (Exception e)
            {

                throw;
            }
            return info;

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnout_Click(object sender, EventArgs e)
        {
            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("结束当前任务，未完成的数据需要重新导入采集?", "结束", messButton);

            if (dr == DialogResult.OK)//如果点击“确定”按钮

            {
                Thread tr = new Thread(_downold);
                tr.Start();
                tm.Stop();

            }
            else
            {
                tm.Start();
            }

        }

        public void _downold()
        {

            Thread.Sleep(6000);
            using (FileStream fs = File.Open("down\\bddata" + xmlnamenum + ".xml", FileMode.Open, FileAccess.Read)) {

                StreamReader sr = new StreamReader(fs);
                string text = sr.ReadToEnd();

                //text = "<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"yes\"?><bddatalist><bddata id=\"0\" spiderUser=\"JMADB01026\" spiderTime=\"187320140938\" spiderMAC=\"00:50:56:C0:00:0100:50:56:C0:00:08DC:53:60:51:EC:D5DE:53:60:51:EC:D52E:15:8F:9D:22:8F\" spiderIP=\"172.19.223.1\" phone=\"172.19.223.1\" issm=\"88元4G飞享套餐\" isUse=\"已审核\" gcar=\"4G TD-LTE 128K USIM卡（现场写卡、2FF/3FF/4FF三切）\"> </bddata></bddatalist>";
                var _bddataList = XmlSerializeHelper.DeSerialize<bddatalist>(text);
                List<bddata> _bddata = _bddataList.DataSource;
                DownloadFileInfo downloadFile = ConvertLogToExcel(_bddata);

                btnstart.Enabled = true;
                btbadd.Enabled = true;
            }
          
        
        }

        private void btbupdata_Click(object sender, EventArgs e)
        {
            using (FileStream fs = File.Open("entity\\user.xml", FileMode.Open, FileAccess.Read))
            {
                StreamReader sr = new StreamReader(fs);
                string text = sr.ReadToEnd();
                var list = XmlSerializeHelper.DeSerialize<userList>(text);
                userList = list.DataSource;
                url_comb.DataSource = list.DataSource;
                url_comb.ValueMember = "token";
                url_comb.DisplayMember = "userName";
            }

           
          
        }
    }
}