using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpiderApp
{


    /// <summary>
    /// 爬虫启动的事件
    /// </summary>
    public class OnStartEventArgs
    {
        /// <summary>
        /// 爬虫的地址
        /// </summary>
        public Uri Uri { get; set; }
        /// <summary>
        /// 启动爬虫的事件
        /// </summary>
        /// <param name="uri"></param>
        public OnStartEventArgs(Uri uri)
        {
            Uri = uri;
        }
    }
    public class OnExcetionEventArgs
    {
        public Uri Uri { get; set; }

        public Exception Exception { get; set; }

        public OnExcetionEventArgs(Uri uri, Exception exception)
        {
            this.Uri = uri;
            this.Exception = exception;
        }
    }

    /// <summary>
    /// 爬虫完成的事件
    /// </summary>
    public class OnCompletedEventArgs
    {
        /// <summary>
        /// 爬虫的地址
        /// </summary>
        public Uri Uri { get; private set; }
        /// <summary>
        /// 任务现场ID
        /// </summary>
        public int ThreadId { get; private set; }
        /// <summary>
        /// 页面源代码
        /// </summary>
        public string PageSource { get; private set; }
        /// <summary>
        /// 爬虫请求的时间
        /// </summary>
        public long MilliSeconds { get; private set; }


        public OnCompletedEventArgs(Uri uri, int threadId, string pageSource, long milliSeconds)
        {
            Uri = uri;
            ThreadId = threadId;
            PageSource = pageSource;
            MilliSeconds = milliSeconds;
        }

    }



    /// <summary>
    /// 实际的爬虫类
    /// </summary>
    public class WebSpider
    {
        /// <summary>
        /// 爬虫的启动事件
        /// </summary>
        public event EventHandler<OnStartEventArgs> OnStartEvent;

        /// <summary>
        /// 触发爬虫开始事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Onstart(object sender, OnStartEventArgs e)
        {
            OnStartEvent?.Invoke(sender, e);
        }

        /// <summary>
        /// 爬虫的结束事件
        /// </summary>
        public event EventHandler<OnCompletedEventArgs> OnCompletedEvent;
        /// <summary>
        /// 触发爬虫完成的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OnCompleted(object sender, OnCompletedEventArgs e)
        {
            OnCompletedEvent?.Invoke(sender, e);
        }

        /// <summary>
        /// 爬虫出错的事件
        /// </summary>
        public event EventHandler<OnExcetionEventArgs> OnExceptionEvent;
        /// <summary>
        /// 触发爬虫失败的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OnException(object sender, OnExcetionEventArgs e)
        {
            OnExceptionEvent?.Invoke(sender, e);
        }


        /// <summary>
        /// cookie容器
        /// </summary>
        public CookieContainer CookiesContainer { get; set; }

        public WebSpider()
        {

        }



        public string Start(Uri uri, string proxy = null)
        {

            var pageSource = string.Empty;
            try
            {
                Onstart(this, new OnStartEventArgs(uri));//触发启动的事件
                var watch = new Stopwatch();
                watch.Start();
                var request = WebRequest.CreateHttp(uri);
                request.Accept = "*/*";
                request.ServicePoint.Expect100Continue = false;//加快载入速度
                request.ServicePoint.UseNagleAlgorithm = false;//禁止Nagle算法加快载入速度
                request.AllowWriteStreamBuffering = false;//禁止缓冲加快载入速度
                request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");//定义gzip压缩页面支持
                request.ContentType = "text/html";//"application/x-www-form-urlencoded";//定义文档类型及编码
                request.AllowAutoRedirect = false;//禁止自动跳转
                                                  //设置User-Agent，伪装成Google Chrome浏览器
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";
                request.Timeout = 5000;//定义请求超时时间为5秒
                request.KeepAlive = true;//启用长连接
                request.Method = "GET";//定义请求方式为GET              
                if (proxy != null) request.Proxy = new WebProxy(proxy);//设置代理服务器IP，伪装请求地址
                request.CookieContainer = this.CookiesContainer;//附加Cookie容器
                request.ServicePoint.ConnectionLimit = int.MaxValue;//定义最大连接数

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    //获取请求响应

                    foreach (System.Net.Cookie cookie in response.Cookies) this.CookiesContainer.Add(cookie);//将Cookie加入容器，保存登录状态

                    if (response.ContentEncoding.ToLower().Contains("gzip"))//解压
                    {
                        using (GZipStream stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress))
                        {
                            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                            {
                                pageSource = reader.ReadToEnd();
                            }
                        }
                    }
                    else if (response.ContentEncoding.ToLower().Contains("deflate"))//解压
                    {
                        using (DeflateStream stream = new DeflateStream(response.GetResponseStream(), CompressionMode.Decompress))
                        {
                            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                            {
                                pageSource = reader.ReadToEnd();
                            }

                        }
                    }
                    else
                    {
                        using (Stream stream = response.GetResponseStream())//原始
                        {
                            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                            {

                                pageSource = reader.ReadToEnd();
                            }
                        }
                    }
                }
                request.Abort();
                watch.Stop();
                var threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;//获取当前任务线程ID
                var milliseconds = watch.ElapsedMilliseconds;//获取请求执行时间
                OnCompleted(this, new OnCompletedEventArgs(uri, threadId, pageSource, milliseconds));
            }
            catch (Exception ex)
            {
                OnException(this, new OnExcetionEventArgs(uri, ex));
            }
            return pageSource;

        }



    }

    public class unit{

        /// <summary>
        /// 时间转时间戳格式
        /// </summary>
        /// <param name="time">数字</param>
        /// <param name="secondsOrMilliseconds">1：秒级别，非1：毫秒级别</param>
        /// <returns></returns>
        public static DateTime ConvertLongToDateTime(long time, int secondsOrMilliseconds = 1)
        {
            TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            DateTime datetime = DateTime.MinValue;
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));
            if (secondsOrMilliseconds == 1)
                datetime = startTime.AddSeconds(time);
            else
                datetime = startTime.AddMilliseconds(time);
            return datetime;
        }

        /// <summary>
        /// 时间戳转时间格式
        /// </summary>
        /// <param name="datetime">日期</param>
        /// <param name="secondsOrMilliseconds">1：秒级别，非1：毫秒级别</param>
        /// <returns></returns>
        public static long ConvertDateTimeToLong(DateTime datetime, int secondsOrMilliseconds = 1)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));
            TimeSpan ts = (datetime - startTime);
            if (secondsOrMilliseconds == 1)
                return (long)ts.TotalSeconds;
            else
                return (long)ts.TotalMilliseconds;
        }
    }

    class RegFunc
    {
        public ArrayList GetStrArr(string pContent, string regBegKey, string regEndKey)
        {
            ArrayList arr = new ArrayList();
            string regular = "(?<={0})(.|\n)*?(?={1})";
            regular = string.Format(regular, regBegKey, regEndKey);
            Regex regex = new Regex(regular, RegexOptions.IgnoreCase);
            MatchCollection mc = regex.Matches(pContent);
            foreach (Match m in mc)
            {
                arr.Add(m.Value.Trim());
            }
            return arr;
        }

        public string GetStr(string pContent, string regBegKey, string regEndKey)
        {
            string regstr = "";
            string regular = "(?<={0})(.|\n)*?(?={1})";
            regular = string.Format(regular, regBegKey, regEndKey);
            Regex regex = new Regex(regular, RegexOptions.IgnoreCase);
            Match m = regex.Match(pContent);
            if (m.Length > 0)
            {
                regstr = m.Value.Trim();
            }
            return regstr;
        }

       
   
    }
}
