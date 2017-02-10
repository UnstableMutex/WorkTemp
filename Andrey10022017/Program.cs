using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using HtmlAgilityPack;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var ser = new XmlSerializer(typeof(List<Dividend>));
            Directory.CreateDirectory("OutDir");

            var skiperr = Constants.Tickers.Where(x => !x.Contains(@"\") && !x.Contains(@"'") && !x.Contains(@"/") && x!="PRN");
            var c = skiperr.Count();
            foreach (var item in skiperr)
            {
                var fn = @"OutDir\" + item + ".xml";
                if (File.Exists(fn))
                {
                    continue;
                }




                try
                {
   var test= NasdaqDataExcelFunctions.NasdaqDividend(item, false);

                ser.Serialize(new FileStream(fn, FileMode.CreateNew ),test  );
                }
                catch (Exception e)
                {
                   Console.WriteLine(item+" error");
                }
            
               
            }
            Console.WriteLine("end");
            Console.ReadKey();

        }
    }

    [Serializable]
    public class Dividend
    {
        public DateTime ExDiv { get; set; }
        public double CashAmount { get; set; }
        public DateTime DeclDate { get; set; }
        public DateTime PayDate { get; set; }
        public DateTime RecDate { get; set; }
    }


    public class NasdaqDataExcelFunctions
    {
        private const string Url = "http://www.nasdaq.com/en/symbol/{0}/dividend-history";
        private const string CacheFormat = "{0}_Div.txt";

        // Asynchronous method
        //public static object NasdaqDividendAsync(string ticker, bool useCache)
        //{
        //    try
        //    {
        //        return ExcelAsyncUtil.Run("NasdaqDividendAsync", new object[] { ticker, useCache },
        //            () => NasdaqDividend(ticker, useCache));
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}



        private static void LoadAndSave(string url, string ticker,bool useCache, out string respString)
        {
            // Dowload data ...
            using (var web = new WebClient())
            {
                respString = web.DownloadString(url);
            }
            // And store it
            if (useCache)
            using (var writer = new StreamWriter(string.Format(CacheFormat, ticker)))
            {
                writer.Write(respString);
            }
        }

        // synchronous method
        public static List<Dividend> NasdaqDividend(string ticker, bool useCache)
        {
            try
            {
                var url = string.Format(Url, ticker);
                var response = new HtmlDocument();
                string respString;

                try
                {
                    if (useCache)
                        // Get data from cache if already retrieved
                        using (var reader = new StreamReader(string.Format(CacheFormat, ticker)))
                        {
                            respString = reader.ReadToEnd();
                        }
                    else
                    {
                        LoadAndSave(url, ticker,useCache, out respString);
                    }
                }
                catch (Exception)
                {
                    LoadAndSave(url, ticker,useCache, out respString);
                }

                response.LoadHtml(respString);

                var apprtr = response.DocumentNode.Descendants("tr").Where
                    (x => x.InnerHtml.Contains("quotes_content_left_dividendhistoryGrid")).ToList();

                IFormatProvider culture = new CultureInfo("en-US");

                var dividends = new List<Dividend>();

                foreach (HtmlNode htmlNode in apprtr)
                {
                    DateTime exDate;
                    DateTime recDate;
                    DateTime payDate;
                    double cashAmount;
                    DateTime declDate;

                    var exDivStr = htmlNode.Descendants("td").
                        FirstOrDefault(p => p.InnerHtml.Contains("quotes_content_left_dividendhistoryGrid_exdate"))
                        .Descendants("span").FirstOrDefault().InnerText;
                    var cashAmtStr = htmlNode.Descendants("td").
                        FirstOrDefault(p => p.InnerHtml.Contains("quotes_content_left_dividendhistoryGrid_CashAmount"))
                        .Descendants("span").FirstOrDefault().InnerText;
                    var declDateStr = htmlNode.Descendants("td").
                        FirstOrDefault(p => p.InnerHtml.Contains("quotes_content_left_dividendhistoryGrid_DeclDate"))
                        .Descendants("span").FirstOrDefault().InnerText;
                    var recDateStr = htmlNode.Descendants("td").
                        FirstOrDefault(p => p.InnerHtml.Contains("quotes_content_left_dividendhistoryGrid_RecDate"))
                        .Descendants("span").FirstOrDefault().InnerText;
                    var payDateStr = htmlNode.Descendants("td").
                        FirstOrDefault(p => p.InnerHtml.Contains("quotes_content_left_dividendhistoryGrid_PayDate"))
                        .Descendants("span").FirstOrDefault().InnerText;

                    DateTime.TryParse(exDivStr, culture, DateTimeStyles.AdjustToUniversal, out exDate);
                    DateTime.TryParse(recDateStr, culture, DateTimeStyles.AdjustToUniversal, out recDate);
                    DateTime.TryParse(payDateStr, culture, DateTimeStyles.AdjustToUniversal, out payDate);
                    double.TryParse(cashAmtStr, out cashAmount);
                    DateTime.TryParse(declDateStr, culture, DateTimeStyles.AdjustToUniversal, out declDate);

                    var div = new Dividend
                    {
                        CashAmount = cashAmount,
                        DeclDate = declDate,
                        RecDate = recDate,
                        PayDate = payDate,
                        ExDiv = exDate
                    };

                    dividends.Add(div);
                }

  
                var counter = 1;

           
                var result = dividends.Where(p => p.ExDiv != null).OrderByDescending(p => p.ExDiv).ToList();

 

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

}
