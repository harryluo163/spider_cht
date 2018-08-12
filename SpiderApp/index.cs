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
        private IList<_IP> IPList = new List<_IP>();

        private ArrayList cyList = new ArrayList();
        private ArrayList hyList = new ArrayList();
        private ArrayList cbdaList = new ArrayList();
        string cookie = "";
        private int spiderNum = 0;
        private int spidercyNum = 0;
        private int spiderhyNum = 0;
        int xmlnamenum = 0;
        HttpClient httpClient;
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
            if (txtview.Lines.Count() > 100) {
                txtview.Text = "";
                txtview.AppendText("清空缓存" + Environment.NewLine);
            }
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

            if (useproxy.Checked)
            {

                if (IPList.Count<0)
                {
                    MessageBox.Show("ip列表为空，请到ip.xml编辑");
                    return;
                }
                _IP iP = getip();
                httpClient = new HttpClient(iP.ip.Split(':')[0].ToString(), Convert.ToInt32(iP.ip.Split(':')[1].ToString()), useproxy.Checked);
            }
            else
            {
                httpClient = new HttpClient("", 0, useproxy.Checked);
            }

            if (url_comb.Text == "全部")
            {
                Thread cyth = new Thread(spidercymain);
                cyth.Start();

                Thread hyth = new Thread(spiderhymain);
                hyth.Start();

                Thread ccda = new Thread(spiderccdamain);
                ccda.Start();

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
            else if (url_comb.Text == "船舶档案")
            {
                Thread ccda = new Thread(spiderccdamain);
                ccda.Start();
            }

        }

        public void doall()
        {
            spidercymain();
            spiderhymain();
        }
        public void spidercymain()
        {

            WebSpider Spider = new WebSpider();
            user itme = getuser();

            //获取cookie
            if (itme.token != "")
            {

                cleadata();
                autoEvent.WaitOne();  //阻塞当前线程，等待通知以继续执行
                Thread.Sleep(Convert.ToInt32(spidertime.Value) * 1000);
            }

            btnstart.Enabled = true;
            txtview.AppendText("抓取船源结束" + Environment.NewLine);
        }

        public void spiderhymain()
        {
            Thread.Sleep(Convert.ToInt32(spidertime.Value * 1000 / 2));
            WebSpider Spider = new WebSpider();
            user itme = getuser();

            //获取cookie
            if (itme.token != "")
            {

                cleahydata();
                autoEvent.WaitOne();  //阻塞当前线程，等待通知以继续执行
                Thread.Sleep(Convert.ToInt32(spidertime.Value) * 1000);
            }

            btnstart.Enabled = true;
            txtview.AppendText("抓取货源结束" + Environment.NewLine);
        }

        public void spiderccdamain() {
            WebSpider Spider = new WebSpider();
            user itme = getuser();

            //获取cookie
            if (itme.token != "")
            {

                cleacbdadata();
                autoEvent.WaitOne();  //阻塞当前线程，等待通知以继续执行
                Thread.Sleep(Convert.ToInt32(spidertime.Value) * 1000);
            }

            btnstart.Enabled = true;
            txtview.AppendText("抓取船源结束" + Environment.NewLine);

        }
        //抓船源
        public void cleadata()
        {
            try
            {
                txtview.AppendText(" 开始抓船源" + Environment.NewLine);
                //一共有980页
                for (int i = 1; i <= Nspidernum.Value; i++)
                {
                    string content = httpClient.GetResponse("", "http://cht.cjsyw.com:8080/ShipSource/listSS.aspx?pageno=" + i + "&&", "", "");
               
                    //Thread.Sleep(Convert.ToInt32(spidertime.Value) * 1000);
                    if (!string.IsNullOrEmpty(content))
                    {
                        getHttpClient();
                        RegFunc rf = new RegFunc();
                        ArrayList arrayList = rf.GetStrArr(content, "\"id\":", ",");
                        for (int k = 0; k < arrayList.Count; k++)
                        {
                            if (cyList.IndexOf(arrayList[k]) < 0)
                            {
                                cyList.Add(arrayList[k]);
                                cleadatadetail(httpClient, arrayList[k].ToString());
                            }

                        }
                        Thread.Sleep(Convert.ToInt32(1000));
                    }
                    else
                    {
                        txtview.AppendText("请求异常" + Environment.NewLine);
                        getHttpClient();
                        btnstart.Enabled = true;
                        return;
                    }
                }

                Thread.Sleep(Convert.ToInt32(spidertime.Value * 1000));
                spidercymain();
            }
            catch (Exception e)
            {

            }

        }

        //抓货源
        public void cleahydata()
        {
            try
            {
                txtview.AppendText(" 开始抓货源" + Environment.NewLine);

                //一共有1000页
                for (int i = 1; i <= Nspidernum.Value; i++)
                {
                    string content = httpClient.GetResponse("", "http://cht.cjsyw.com:8080/Goods/listGoods.aspx?pageno=" + i + "&&", "", "");
                    getHttpClient();
                    if (!string.IsNullOrEmpty(content))
                    {
                        Thread.Sleep(Convert.ToInt32(4000));
                        RegFunc rf = new RegFunc();
                        ArrayList arrayList = rf.GetStrArr(content, "\"id\":", ",");
                        for (int k = 0; k < arrayList.Count; k++)
                        {
                            if (hyList.IndexOf(arrayList[k]) < 0)
                            {
                                cyList.Add(arrayList[k]);
                                cleahydatadetail(httpClient, arrayList[k].ToString());
                            }
                        }
                        Thread.Sleep(Convert.ToInt32(1000));
                    }
                    else
                    {

                        txtview.AppendText("请求异常" + Environment.NewLine);
                        btnstart.Enabled = true;
                        return;
                    }
                }
                Thread.Sleep(Convert.ToInt32(spidertime.Value * 1000));
                spiderhymain();
            }
            catch (Exception ex)
            {

            }
        }

        //船舶档案
        public void cleacbdadata()
        {
            try
            {
                txtview.AppendText(" 船舶档案" + Environment.NewLine);

                //一共有1000页
                for (int i = 1; i <= nmccda.Value; i++)
                {
                    string content = httpClient.GetResponse("", "http://cht.cjsyw.com:8080/Boat/BoatList.aspx?pageno=" + i + "&&", "", "");
                    getHttpClient();
                    if (!string.IsNullOrEmpty(content))
                    {
                        Thread.Sleep(Convert.ToInt32(4000));
                        RegFunc rf = new RegFunc();
                        ArrayList arrayList = rf.GetStrArr(content, "\"boatid\":", ",");
                        for (int k = 0; k < arrayList.Count; k++)
                        {
                            if (cbdaList.IndexOf(arrayList[k]) < 0)
                            {
                                cbdaList.Add(arrayList[k]);
                                cleacbdadatadetail(httpClient, arrayList[k].ToString());
                            }
                        }
                        Thread.Sleep(Convert.ToInt32(1000));
                    }
                    else
                    {

                        txtview.AppendText("请求异常" + Environment.NewLine);
                        btnstart.Enabled = true;
                        return;
                    }
                }
                Thread.Sleep(Convert.ToInt32(spidertime.Value * 1000));
                spiderhymain();
            }
            catch (Exception ex)
            {

            }
        }
        public void cleadatadetail(HttpClient httpClient, string kcid)
        {
            try
            {
                RegFunc rf = new RegFunc();
                //切换账户，设置代理
                user user = getuser();
                string nexurl = "http://cht.cjsyw.com:8080/ShipSource/getSSDetail.aspx?userid=" + user.token + "&kcid=" + kcid + "";
                string content2 = httpClient.GetResponse("", nexurl, "", "");
                getHttpClient();
                if (rf.GetStr(content2, "\"mobile\":\"", "\",") == "操作频繁稍后再试！")
                {
                    txtview.AppendText("操作频繁切换用户" + user.token + Environment.NewLine);
                    user = getuser();
                    //抓起间隔
                    Thread.Sleep(Convert.ToInt32(spidertime.Value) * 1000);
                    cleadatadetail(httpClient, kcid);

                }
                if (!string.IsNullOrEmpty(content2))
                {
                    string _datastr = "";
                    //创建文件夹

                    string Path = "down\\船源数据.txt";
                    if (!File.Exists(Path))
                    {
                        using (new FileStream(Path, FileMode.Create, FileAccess.Write)) { };
                    }



                    using (StreamWriter sw = new StreamWriter(Path, true, Encoding.Default))
                    {

                        _datastr += "<id>" + rf.GetStr(content2, "\"id\":", ",") + "</id>";
                        _datastr += "<boatid>" + rf.GetStr(content2, "\"boatid\":", ",") + "</boatid>";
                        _datastr += "<Privince>" + rf.GetStr(content2, "\"Privince\":\"", "\",") + "</Privince>";
                        _datastr += "<city>" + rf.GetStr(content2, "\"city\":\"", "\",") + "</city>";
                        _datastr += "<bz>" + rf.GetStr(content2, "\"bz\":\"", "\"") + "/bz>";

                        _datastr += "<userid>" + rf.GetStr(content2, "\"userid\":", ",") + "/userid>";
                        _datastr += "<gsmc>" + rf.GetStr(content2, "\"gsmc\":\"", "\",") + "</gsmc>";

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

                        string content3 = rf.GetStr(content2, "\"czxx\":", "}]");
                        _datastr += "<czxxid>" + rf.GetStr(content3, "\"id\":", ",") + "</czxxid>";
                        _datastr += "<lx>" + rf.GetStr(content3, "\"lx\":\"", "\",") + "</lx>";
                        _datastr += "<Qymc>" + rf.GetStr(content3, "\"Qymc\":\"", "\",") + "</Qymc>";
                        _datastr += "<Uname>" + rf.GetStr(content3, "\"Uname\":\"", "\",") + "</Uname>";
                        _datastr += "<name>" + rf.GetStr(content3, "\"name\":\"", "\",") + "</name>";
                        _datastr += "<mobile>" + rf.GetStr(content3, "\"mobile\":\"", "\",") + "</mobile>";
                        _datastr += "<flag>" + rf.GetStr(content3, "\"flag\":", ",") + "</flag>";
                        _datastr += "<hppj>" + rf.GetStr(content3, "\"hppj\":", ",") + "</hppj>";
                        _datastr += "<ybpj>" + rf.GetStr(content3, "\"ybpj\":", ",") + "</ybpj>";
                        _datastr += "<cppj>" + rf.GetStr(content3, "\"cppj\":", ",") + "</cppj>";
                        _datastr += "<userimg>" + rf.GetStr(content3, "\"userimg\":\"", "\"") + "</userimg>";

                        string content4 = rf.GetStr(content2, "\"ds\":", "}");
                        if (!string.IsNullOrEmpty(rf.GetStr(content4, "\"ch\":\"", "\",")))
                        {
                            _datastr += "<ch>" + rf.GetStr(content4, "\"ch\":\"", "\",") + "</ch>";
                            _datastr += "<sf>" + rf.GetStr(content4, "\"sf\":\"", "\",") + "</sf>";
                            _datastr += "<city>" + rf.GetStr(content4, "\"city\":\"", "\",") + "</city>";
                            _datastr += "<sc>" + rf.GetStr(content4, "\"sc\":\"", "\",") + "</sc>";
                            _datastr += "<cc>" + rf.GetStr(content4, "\"cc\":\"", "\",") + "</cc>";
                            _datastr += "<ck>" + rf.GetStr(content4, "\"ck\":\"", "\",") + "</ck>";
                            _datastr += "<cs>" + rf.GetStr(content4, "\"cs\":\"", "\"") + "</cs>";
                        }
                        else
                        {

                            Thread.Sleep(Convert.ToInt32(2000));
                            // content4 = httpClient.GetResponse("", "http://cht.cjsyw.com:8080/Boat/getBoatById.aspx?id=10310&userid=" + user.token + "", "", "");
                            _datastr += "<ch></ch>";
                            _datastr += "<sf></sf>";
                            _datastr += "<city></city>";
                            _datastr += "<sc></sc>";
                            _datastr += "<cc></cc>";
                            _datastr += "<ck></ck>";
                            _datastr += "<cs></cs>";

                        }




                        //开始写入
                        sw.Write(_datastr + "\r\n");
                        spidercyNum++;
                        txtview.AppendText("已抓到吨位" + rf.GetStr(content2, "\"cpdw\":\"", "\",") + "所在地" + rf.GetStr(content2, "\"szg\":\"", "\",") + rf.GetStr(content2, "\"cplx\":\"", "\",") + Environment.NewLine);
                    }
                }
                //抓起间隔
                Thread.Sleep(Convert.ToInt32(spidertime.Value) * 1000);
            }
            catch (Exception ex)
            {

            }
        }


        public void cleahydatadetail(HttpClient httpClient, string hwid)
        {
            try
            {
                RegFunc rf = new RegFunc();
                //切换账户，设置代理
                user user = getuser();
                string nexurl = "http://cht.cjsyw.com:8080//Goods/FindGoodsDetails.aspx?userid=" + user.token + "&hwid=" + hwid + "";
                string content2 = httpClient.GetResponse("", nexurl, "", "");
                getHttpClient();
                if (rf.GetStr(content2, "\"mobile\":\"", "\",") == "操作频繁稍后再试！")
                {
                    txtview.AppendText("操作频繁切换用户" + user.token + Environment.NewLine);
                    user = getuser();
                    //抓起间隔
                    Thread.Sleep(Convert.ToInt32(spidertime.Value) * 1000);
                    cleahydatadetail(httpClient, hwid);

                }
                if (!string.IsNullOrEmpty(content2))
                {

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

                        _datastr += "<hymc>" + rf.GetStr(content2, "\"hymc\":\"", "\",") + "</hymc>";

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
                        _datastr += "<hwid>" + rf.GetStr(content2, "\"hwid\":", ",") + "</hwid>";
                        _datastr += "<bz>" + rf.GetStr(content2, "\"bz\":\"", "\"") + "</bz>";
                        //开始写入
                        sw.Write(_datastr + "\r\n");
                        spidercyNum++;
                        txtview.AppendText("已抓到" + rf.GetStr(content2, "\"name\":\"", "\",") + "的货源" + rf.GetStr(content2, "\"title\":\"", "\",") + Environment.NewLine);
                    }
                    //抓起间隔
                    Thread.Sleep(Convert.ToInt32(spidertime.Value) * 1000);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void cleacbdadatadetail(HttpClient httpClient, string hwid)
        {
            try
            {
                RegFunc rf = new RegFunc();
                //切换账户，设置代理
                user user = getuser();
                string nexurl = "http://cht.cjsyw.com:8080/Boat/getBoatById.aspx?userid=" + user.token + "&id=" + hwid + "";
                string content2 = httpClient.GetResponse("", nexurl, "", "");
                getHttpClient();
                if (rf.GetStr(content2, "\"mobile\":\"", "\",") == "操作频繁稍后再试！")
                {
                    txtview.AppendText("操作频繁切换用户" + user.token + Environment.NewLine);
                    user = getuser();
                    //抓起间隔
                    Thread.Sleep(Convert.ToInt32(spidertime.Value) * 1000);
                    cleahydatadetail(httpClient, hwid);

                }
                if (!string.IsNullOrEmpty(content2))
                {

                    string _datastr = "";
                    //创建文件夹
                    FileStream fs;
                    string Path = "down\\船舶档案数据.txt";
                    if (!File.Exists(Path))
                    {
                        using (new FileStream(Path, FileMode.Create, FileAccess.Write)) { };
                    }

                    using (StreamWriter sw = new StreamWriter(Path, true, Encoding.Default))
                    {

                        _datastr += "<id>" + rf.GetStr(content2, "\"id\":", ",") + "</id>";
                        _datastr += "<dw>" + rf.GetStr(content2, "\"hzimg\":", ",") + "</hzimg>";
                        _datastr += "<cx>" + rf.GetStr(content2, "\"cx\":\"", "\",") + "</cx>";
                        _datastr += "<sf>" + rf.GetStr(content2, "\"sf\":\"", "\",") + "</sf>";
                        _datastr += "<cx>" + rf.GetStr(content2, "\"cx\":\"", "\",") + "</cx>";
                        _datastr += "<city>" + rf.GetStr(content2, "\"city\":\"", "\",") + "</city>";
                        _datastr += "<czxm>" + rf.GetStr(content2, "\"czxm\":\"", "\",") + "</czxm>";
                        _datastr += "<sjhm>" + rf.GetStr(content2, "\"sjhm\":\"", "\",") + "</sjhm>";
                        _datastr += "<date>" + rf.GetStr(content2, "\"date\":\"", "\",") + "</date>";
                        _datastr += "<gkgs>" + rf.GetStr(content2, "\"gkgs\":\"", "\",") + "</gkgs>";
                        _datastr += "<sfzh>" + rf.GetStr(content2, "\"sfzh\":\"", "\",") + "</sfzh>";
                        _datastr += "<ch>" + rf.GetStr(content2, "\"ch\":\"", "\",") + "</ch>";
                        _datastr += "<hc>" + rf.GetStr(content2, "\"hc\":\"", "\",") + "</hc>";
                        _datastr += "<bz>" + rf.GetStr(content2, "\"bz\":\"", "\",") + "</bz>";

                        _datastr += "<cc>" + rf.GetStr(content2, "\"cc\":\"", "\",") + "</cc>";
                        _datastr += "<cg>" + rf.GetStr(content2, "\"cg\":\"", "\",") + "</cg>";
                        _datastr += "<ck>" + rf.GetStr(content2, "\"ck\":\"", "\",") + "</ck>";
                        _datastr += "<cs>" + rf.GetStr(content2, "\"cs\":\"", "\",") + "</cs>";
                        _datastr += "<sfdb>" + rf.GetStr(content2, "\"sfdb\":\"", "\",") + "</sfdb>";
                        _datastr += "<adress>" + rf.GetStr(content2, "\"adress\":\"", "\",") + "</adress>";
                        _datastr += "<lxdh>" + rf.GetStr(content2, "\"lxdh\":\"", "\",") + "</lxdh>";
                        _datastr += "<qq>" + rf.GetStr(content2, "\"qq\":\"", "\",") + "</qq>";
                        _datastr += "<gmsj>" + rf.GetStr(content2, "\"gmsj\":\"", "\",") + "</gmsj>";
                        _datastr += "<email>" + rf.GetStr(content2, "\"email\":\"", "\",") + "</email>";

                        _datastr += "<frdb>" + rf.GetStr(content2, "\"frdb\":\"", "\",") + "</frdb>";
                        _datastr += "<gsdh>" + rf.GetStr(content2, "\"gsdh\":\"", "\",") + "</gsdh>";
                        _datastr += "<gsweb>" + rf.GetStr(content2, "\"gsweb\":\"", "\",") + "</gsweb>";
                        _datastr += "<gsemail>" + rf.GetStr(content2, "\"gsemail\":\"", "\",") + "</gsemail>";
                        _datastr += "<gsfax>" + rf.GetStr(content2, "\"gsfax\":\"", "\",") + "</gsfax>";
                        _datastr += "<gsadress>" + rf.GetStr(content2, "\"gsadress\":\"", "\",") + "</gsadress>";

                        _datastr += "<flag>" + rf.GetStr(content2, "\"flag\":", ",") + "</flag>";
                        _datastr += "<userid>" + rf.GetStr(content2, "\"userid\":", ",") + "</userid>";
                        _datastr += "<lx>" + rf.GetStr(content2, "\"lx\":\"", "\",") + "</lx>";
                        _datastr += "<ip>" + rf.GetStr(content2, "\"ip\":\"", "\",") + "</ip>";
                        _datastr += "<hits>" + rf.GetStr(content2, "\"hits\":\"", "\",") + "</hits>";
                        _datastr += "<ISCheck>" + rf.GetStr(content2, "\"ISCheck\":\"", "\",") + "</ISCheck>";

                        _datastr += "<CB_Photo>" + rf.GetStr(content2, "\"CB_Photo\":\"", "\",") + "</CB_Photo>";
                        _datastr += "<CB_Class>" + rf.GetStr(content2, "\"CB_Class\":\"", "\",") + "</CB_Class>";
                        _datastr += "<ISTop>" + rf.GetStr(content2, "\"ISTop\":\"", "\",") + "</ISTop>";
                        _datastr += "<Topdate>" + rf.GetStr(content2, "\"Topdate\":\"", "\"") + "</Topdate>";


                        //开始写入
                        sw.Write(_datastr + "\r\n");
                        spidercyNum++;
                        txtview.AppendText("已抓到" + rf.GetStr(content2, "\"ch\":\"", "\",") + "的船舶档案信息" + rf.GetStr(content2, "\"title\":\"", "\",") + Environment.NewLine);



                    }
                    //抓起间隔
                    Thread.Sleep(Convert.ToInt32(spidertime.Value) * 1000);
                }
            }
            catch (Exception ex)
            {
            }
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

        public _IP getip() {
            _IP ip = new _IP();

            for (int i = 0; i < IPList.Count; i++)
            {
                if (IPList[i].ip != "")
                {
                    ip = IPList[i];
                    IPList.Remove(ip);
                    IPList.Add(ip);
                    break;
                }
                else
                {
                    IPList.Remove(IPList[i]);
                }
            }
            return ip;
        }

        public void getHttpClient()
        {
                 if (useproxy.Checked)
            {

                if (IPList.Count<0)
                {
                    MessageBox.Show("ip列表为空，请到ip.xml编辑");
                    return;
                }
                _IP iP = getip();
                txtview.AppendText("切换代理" + iP.ip+ "" + Environment.NewLine);

                httpClient = new HttpClient(iP.ip.Split(':')[0].ToString(), Convert.ToInt32(iP.ip.Split(':')[1].ToString()), useproxy.Checked);
            }
            else
            {
                httpClient = new HttpClient("", 0, useproxy.Checked);
            }
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

            using (FileStream fs = File.Open("entity\\ip.xml", FileMode.Open, FileAccess.Read))
            {
                StreamReader sr = new StreamReader(fs);
                string text = sr.ReadToEnd();
                var list = XmlSerializeHelper.DeSerialize<IPList>(text);
                IPList = list.DataSource;
                cbiplist.DataSource = list.DataSource;
                cbiplist.ValueMember = "ip";
                cbiplist.DisplayMember = "ip";


            }


        }
    }
}
