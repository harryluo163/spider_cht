using SpiderApp.entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpiderApp
{
    public partial class 船源货源抓取系统 : Form
    {
        //计时器  
        private System.Windows.Forms.Timer tm = new System.Windows.Forms.Timer();
        //自动重置事件类    
        //主要用到其两个方法 WaitOne() 和 Set() , 前者阻塞当前线程，后者通知阻塞线程继续往下执行  
        AutoResetEvent autoEvent = new AutoResetEvent(false);

        private FileInfo fileExcelLoad;
        private string fileNameLoad;
        private IList<user> userList = new List<user>();
        private ArrayList cyList = new ArrayList();
        private ArrayList hyList = new ArrayList();
        string cookie = "";
        private int spiderNum = 0;
        private int spidercyNum = 0;
        private int spiderhyNum = 0;
        int xmlnamenum = 0;
        public 船源货源抓取系统()
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


        private void btnstart_Click(object sender, EventArgs e)
        {
            if (userList.Count <= 0)
            {
                MessageBox.Show("请导入用户账号");
                return;
            }

            btnstart.Enabled = false;

            int spiderNum = 0;
            int xmlnamenum = 0;

            tm.Start();

            if (url_comb.Text == "全部")
            {
                Thread cyth = new Thread(spidercymain);
                cyth.Start();
                Thread hyth = new Thread(spiderhymain);
                hyth.Start();
            }
            else if (url_comb.Text == "船源")
            {
                Thread cyth = new Thread(spidercymain);
                cyth.Start();
            }
            else if (url_comb.Text == "货源")
            {
                Thread hyth = new Thread(spiderhymain);
                hyth.Start();
            }

        }

        public void spidercymain()
        {
            WebSpider Spider = new WebSpider();
            user itme = getuser();

            //获取cookie
            if (itme.token != "")
            {

                cleadata(itme);
                autoEvent.WaitOne();  //阻塞当前线程，等待通知以继续执行
                Thread.Sleep(Convert.ToInt32(spidertime.Value) * 1000);
            }

            btnstart.Enabled = true;
            txtview.AppendText("抓取船源结束" + Environment.NewLine);
        }

        public void spiderhymain()
        {
            WebSpider Spider = new WebSpider();
            user itme = getuser();

            //获取cookie
            if (itme.token != "")
            {

                cleahydata(itme);
                autoEvent.WaitOne();  //阻塞当前线程，等待通知以继续执行
                Thread.Sleep(Convert.ToInt32(spidertime.Value) * 1000);
            }

            btnstart.Enabled = true;
            txtview.AppendText("抓取货源结束" + Environment.NewLine);
        }

        //抓货源
        public void cleadata(user itme)
        {
            txtview.AppendText(" 开始抓船源" + Environment.NewLine);
            HttpClient httpClient = new HttpClient();
            //一共有980页
            for (int i = 1; i <= 980; i++)
            {
                string content = httpClient.GetResponse("", "http://cht.cjsyw.com:8080/ShipSource/listSS.aspx?pageno=" + i + "&&", "", "");
                RegFunc rf = new RegFunc();
                ArrayList arrayList = rf.GetStrArr(content, "\"id\":", ",");
                for (int k = 0; k < arrayList.Count; k++)
                {
                    cleadatadetail(httpClient, arrayList[k].ToString());
                }
                Thread.Sleep(Convert.ToInt32(1000));
            }
        }

        //抓船员
        public void cleahydata(user itme)
        {
            txtview.AppendText(" 开始抓货源" + Environment.NewLine);
            HttpClient httpClient = new HttpClient();
            //一共有1000页
            for (int i = 1; i <= 1000; i++)
            {
                string content = httpClient.GetResponse("", "http://cht.cjsyw.com:8080/Goods/listGoods.aspx?pageno=" + i + "&&", "", "");
                RegFunc rf = new RegFunc();
                ArrayList arrayList = rf.GetStrArr(content, "\"id\":", ",");
                for (int k = 0; k < arrayList.Count; k++)
                {
                    //切换账户，设置代理
                    user user = getuser();
                    string nexurl = "http://cht.cjsyw.com:8080//Goods/FindGoodsDetails.aspx?userid=" + user.token + "&hwid=" + arrayList[k] + "";
                    string content2 = httpClient.GetResponse("", nexurl, "", "");
                    string _datastr = "";
                    //创建文件夹
                    FileStream fs;
                    string Path = "down\\货源数据.txt";
                    if (!File.Exists(Path))
                    {
                        using (new FileStream(Path, FileMode.Create, FileAccess.Write)) { };
                    }

                    using (StreamWriter sw = new StreamWriter(Path, true, Encoding.Default))
                    {

                        _datastr += "<hzimg>" + rf.GetStr(content2, "\"hzimg\":\"", "\",") + "</hzimg>";
                        _datastr += "<name>" + rf.GetStr(content2, "\"name\":\"", "\",") + "</name>";
                        _datastr += "<mobile>" + rf.GetStr(content2, "\"mobile\":\"", "\",") + "</mobile>";
                        _datastr += "<title>" + rf.GetStr(content2, "\"title\":\"", "\",") + "</title>";
                        _datastr += "<hwUserid>" + rf.GetStr(content2, "\"hwUserid\":", ",") + "/hwUserid>";

                        _datastr += "<cppj>" + rf.GetStr(content2, "\"cppj\":\"", "\",") + "</cppj>";
                        _datastr += "<ybpj>" + rf.GetStr(content2, "\"ybpj\":\"", "\",") + "</ybpj>";
                        _datastr += "<cppj>" + rf.GetStr(content2, "\"cppj\":\"", "\",") + "</cppj>";
                        _datastr += "<hits>" + rf.GetStr(content2, "\"hits\":\"", "\",") + "</hits>";

                        _datastr += "<ckyj>" + rf.GetStr(content2, "\"ckyj\":\"", "\",") + "</ckyj>";
                        _datastr += "<hwds>" + rf.GetStr(content2, "\"hwds\":\"", "\",") + "</hwds>";
                        _datastr += "<fhg>" + rf.GetStr(content2, "\"fhg\":\"", "\",") + "</fhg>";
                        _datastr += "<ddg>" + rf.GetStr(content2, "\"ddg\":\"", "\",") + "</ddg>";
                        _datastr += "<ssss>" + rf.GetStr(content2, "\"ssss\":\"", "\"") + "</ssss>";
                        _datastr += "<CFPrivince>" + rf.GetStr(content2, "\"CFPrivince\":\"", "\",") + "</CFPrivince>";
                        _datastr += "<CFCity>" + rf.GetStr(content2, "\"CFCity\":\"", "\",") + "</CFCity>";
                        _datastr += "<bzxs>" + rf.GetStr(content2, "\"bzxs\":\"", "\",") + "</bzxs>";
                        _datastr += "<fhrq>" + rf.GetStr(content2, "\"fhrq\":\"", "\",") + "</fhrq>";
                        _datastr += "<jzrq>" + rf.GetStr(content2, "\"jzrq\":\"", "\",") + "</jzrq>";
                        _datastr += "<lb>" + rf.GetStr(content2, "\"lb\":\"", "\",") + "</lb>";
                        _datastr += "<hwid>" + rf.GetStr(content2, "\"hwid\":\"", "\",") + "</hwid>";
                        _datastr += "<bz>" + rf.GetStr(content2, "\"bz\":\"", "\",") + "</bz>";
                        //开始写入
                        sw.Write(_datastr + "\r\n");
                        spidercyNum++;
                        txtview.AppendText("已抓到" + rf.GetStr(content2, "\"name\":\"", "\",") + "的货源" + rf.GetStr(content2, "\"title\":\"", "\",") + Environment.NewLine);
                    }
                    //抓起间隔
                    Thread.Sleep(Convert.ToInt32(spidertime.Value) * 1000);

                }
                Thread.Sleep(Convert.ToInt32(1000));
            }
        }

        public void cleadatadetail(HttpClient httpClient, string kcid)
        {
            //切换账户，设置代理
            user user = getuser();
            string nexurl = "http://cht.cjsyw.com:8080/ShipSource/getSSDetail.aspx?userid=" + user.token + "&kcid=" + kcid + "";
            string content2 = httpClient.GetResponse("", nexurl, "", "");
            string _datastr = "";
            //创建文件夹

            string Path = "down\\船源数据.txt";
            if (!File.Exists(Path))
            {
                using (new FileStream(Path, FileMode.Create, FileAccess.Write)) { } ;
            }


            RegFunc rf = new RegFunc();
            using (StreamWriter sw = new StreamWriter(Path, true, Encoding.Default))
            {

                _datastr += "<id>" + rf.GetStr(content2, "\"id\":", ",") + "</id>";
                _datastr += "<boatid>" + rf.GetStr(content2, "\"boatid\":", ",") + "</boatid>";
                _datastr += "<Privince>" + rf.GetStr(content2, "\"Privince\":\"", "\",") + "</Privince>";
                _datastr += "<city>" + rf.GetStr(content2, "\"city\":\"", "\",") + "</city>";
                _datastr += "<userid>" + rf.GetStr(content2, "\"userid\":", ",") + "/userid>";
                _datastr += "<szg>" + rf.GetStr(content2, "\"szg\":\"", "\",") + "</szg>";
                _datastr += "<mdg>" + rf.GetStr(content2, "\"mdg\":\"", "\",") + "</mdg>";
                _datastr += "<cpdw>" + rf.GetStr(content2, "\"cpdw\":\"", "\",") + "</cpdw>";
                _datastr += "<cplx>" + rf.GetStr(content2, "\"cplx\":\"", "\",") + "</cplx>";
                _datastr += "<kclb>" + rf.GetStr(content2, "\"kclb\":\"", "\",") + "</kclb>";
                _datastr += "<zhrq1>" + rf.GetStr(content2, "\"zhrq1\":\"", "\",") + "</zhrq1>";
                _datastr += "<zhrq2>" + rf.GetStr(content2, "\"zhrq2\":\"", "\",") + "</zhrq2>";
                _datastr += "<bzlb>" + rf.GetStr(content2, "\"bzlb\":\"", "\",") + "</bzlb>";
                _datastr += "<name>" + rf.GetStr(content2, "\"name\":\"", "\"") + "</name>";
                _datastr += "<mobile>" + rf.GetStr(content2, "\"mobile\":\"", "\",") + "</mobile>";
                //开始写入
                sw.Write(_datastr + "\r\n");
                spidercyNum++;
                txtview.AppendText("已抓到吨位" + rf.GetStr(content2, "\"cpdw\":\"", "\",") + "所在地" + rf.GetStr(content2, "\"szg\":\"", "\",") + rf.GetStr(content2, "\"cplx\":\"", "\",") + Environment.NewLine);
            }
            //抓起间隔
            Thread.Sleep(Convert.ToInt32(spidertime.Value) * 1000);
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


        private void 船源货源抓取系统_Load(object sender, EventArgs e)
        {
            using (FileStream fs = File.Open("entity\\user.xml", FileMode.Open, FileAccess.Read))
            {
                StreamReader sr = new StreamReader(fs);
                string text = sr.ReadToEnd();
                var list = XmlSerializeHelper.DeSerialize<userList>(text);
                userList = list.DataSource;
                comboBox1.DataSource = list.DataSource;
                comboBox1.ValueMember = "token";
                comboBox1.DisplayMember = "token";


            }

        }
    }
}
