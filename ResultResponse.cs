using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace WindowsFormsApp1
{
    public class ResultResponse
    {
        private HttpWebResponse m_response;

        public ResultResponse(HttpWebResponse response)
        {
            m_response = response;
        }

        public Stream GetResponseStream()
        {
            if (m_response != null)
                return m_response.GetResponseStream();
            return null;
        }

        public string ProtocolVersion { get { return m_response != null ? m_response.ProtocolVersion.ToString() : ""; } }
        public string Method { get { return m_response != null ? m_response.Method : ""; } }
        public string StatusCode { get { return m_response != null ? m_response.StatusCode.ToString() : ""; } }
        public WebHeaderCollection Headers { get { return m_response != null ? m_response.Headers : null; } }

        public  Encoding getResponseEncoding()
        {
            if (m_response != null)
                return Encoding.GetEncoding(m_response.ContentEncoding);
            return null;
        }

        public string GetContent(string encoding = "utf-8")
        {
            return System.Text.Encoding.GetEncoding(encoding).GetString(this.StreamToBytes(this.GetResponseStream()));
        }

        public HttpWebResponse GetRawResponse()
        {
            return m_response;
        }

        private byte[] StreamToBytes(Stream stream)
        {
            byte[] buff;
            int rlen;
            MemoryStream ms;
            if (stream != null)
            {
                buff = new byte[1024];
                rlen = 0;
                ms = new MemoryStream();
                while ((rlen = stream.Read(buff, 0, buff.Length)) > 0)
                {
                    ms.Write(buff, 0, rlen);
                }
                buff = ms.ToArray();
                ms.Close();
                ms.Dispose();
                return buff;
            }
            return null;
        }
    }

    public class HttpClient
    {
        private CookieContainer cookies;
        public string UserAgent { get; set; }
        public HttpClient ()
        {
            cookies = new CookieContainer();
        }

        public CookieContainer GetCookieContainer()
        {
            return cookies;
        }

        public bool SetCookieContainer(CookieContainer cookie)
        {
            if (cookie == null)
                return false;
            else
            {
                cookies = cookie;
                return true;
            }
        }

        public ResultResponse OpenGetUrl(string url, Dictionary<string, string> headers)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = cookies;
            request.Method = HttpClient.ConnectionType.GET;
            request.KeepAlive = true;
            if (this.UserAgent != null && this.UserAgent != "")
                request.UserAgent = this.UserAgent;
            this.FillHeaders(request, headers);
            HttpWebResponse response= request.GetResponse() as HttpWebResponse;
            return new ResultResponse(response);
        }

        public ResultResponse OpenGetUrlRedirect(string url, Dictionary<string, string> headers,HttpClient.RedirectAction action)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = cookies;
            request.Method = HttpClient.ConnectionType.GET;
            request.KeepAlive = true;
            request.AllowAutoRedirect = false;
            if (this.UserAgent != null && this.UserAgent != "")
                request.UserAgent = this.UserAgent;
            this.FillHeaders(request, headers);
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            ResultResponse result = new ResultResponse(response);
            if (response.StatusCode == HttpStatusCode.Found)
            {
                bool ret = true;
                if (action != null)
                    ret = action(null);
                string locationurl = response.Headers["Location"];
                if (ret)
                    return this.OpenGetUrlRedirect(locationurl, null, action);
                return result;
            }

            return new ResultResponse(response);
        }

        public delegate bool RedirectAction (ResultResponse result);

        private void FillHeaders(HttpWebRequest request, Dictionary<string,string> headers)
        {
            if (headers!=null && headers.Count>0)
            {
                Dictionary<string,string>.Enumerator em = headers.GetEnumerator();
                while (em.MoveNext())
                    request.Headers.Add(em.Current.Key, em.Current.Value);
            }
        }

        public ResultResponse OpenPostUrl(string url, Dictionary<string, string> headers, Dictionary<string, string > data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = cookies;
            request.Method = HttpClient.ConnectionType.POST;
            request.KeepAlive = true;
            request.AllowAutoRedirect = false;
            if (this.UserAgent != null && this.UserAgent != "")
                request.UserAgent = this.UserAgent;
            this.FillHeaders(request, headers);
            byte[] buff = DictToBytes(data);
            request.GetRequestStream().Write(buff, 0, buff.Length);
            request.GetRequestStream().Close();

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            return new ResultResponse(response);

        }

        public ResultResponse OpenPostUrlRedirect(string url, Dictionary<string,string> headers, Dictionary<string, string> data, HttpClient.RedirectAction action)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = cookies;
            request.Method = HttpClient.ConnectionType.POST;
            request.KeepAlive = true;
            request.AllowAutoRedirect = false;
            if (this.UserAgent != null && this.UserAgent != "")
                request.UserAgent = this.UserAgent;
            this.FillHeaders(request, headers);
            byte[] buff = DictToBytes(data);
            request.GetRequestStream().Write(buff, 0, buff.Length);
            request.GetRequestStream().Close();

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            ResultResponse result = new ResultResponse(response);
            if (response.StatusCode == HttpStatusCode.Found)
            {
                bool ret = true;
                if (action != null)
                    ret = action(null);
                string locationurl = response.Headers["Location"];
                if (ret)
                    return this.OpenGetUrlRedirect(locationurl, null, action);
                return result;
            }
            return result;
        }

        private byte[] DictToBytes(Dictionary<string, string> dic)
        {
            StringBuilder sb;
            if (dic != null)
            {
                Dictionary<string,string >.Enumerator em = dic.GetEnumerator();
                sb = new StringBuilder();
                while (em.MoveNext())
                    sb.Append(String.Format("{0}={1}&", em.Current.Key, em.Current.Value));
                return System.Text.Encoding.UTF8.GetBytes(sb.ToString());
            }
            return null;
        }

        public static class ConnectionType
        {
            public static string GET { get { return "GET"; } }
            public static string POST { get { return "POST"; } }
        }
    }

}
