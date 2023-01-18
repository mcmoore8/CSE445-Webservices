using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected string hostURL = "http://localhost:49792";
    protected void Page_Load(object sender, EventArgs e)
    {
		/*HttpCookie cookie = Request.Cookies["myCookie"];
		if (cookie != null)
		{
			TextBox1.Text = cookie["inputS1"];
		}*/

		HttpCookie cookie2 = Request.Cookies["myCookie2"];
		if (cookie2 != null)
		{
			TextBox2.Text = cookie2["inputS2"];
		}

		HttpCookie cookie3 = Request.Cookies["myCookie3"];
		if (cookie3 != null)
		{
			TextBox3.Text = cookie3["inputS3"];
		}
	}

    protected void Button1_Click(object sender, EventArgs e)
    {
		/*HttpCookie cookie = new HttpCookie("myCookie");
		cookie["inputS1"] = TextBox1.Text;
		cookie.Expires = DateTime.Now.AddMinutes(1);
		Response.Cookies.Add(cookie);*/

		GetForecast();
	}

	protected void Button2_Click(object sender, EventArgs e)
	{
		HttpCookie cookie2 = new HttpCookie("myCookie2");
		cookie2["inputS2"] = TextBox2.Text;
		cookie2.Expires = DateTime.Now.AddMinutes(1);
		Response.Cookies.Add(cookie2);

		GetCovidData();
	}

	protected void Button3_Click(object sender, EventArgs e)
	{
		HttpCookie cookie3 = new HttpCookie("myCookie3");
		cookie3["inputS3"] = TextBox3.Text;
		cookie3.Expires = DateTime.Now.AddMinutes(1);
		Response.Cookies.Add(cookie3);

		String localDat = "";
		localDat += "City: " + GetCity(TextBox3.Text) + "</br>" +
					"State: " + GetState(TextBox3.Text) + "</br>" +
					"Latitude: " + GetLat(TextBox3.Text) + "</br>" +
					"Longitude: " + GetLong(TextBox3.Text) + "</br></br>";
		Label3.Text = localDat;
	}


	protected void GetForecast()
	{
		string url = @hostURL + "/Service1.svc/forecast?zip=" + TextBox1.Text;
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
		request.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64)";
		request.ContentType = "application/geo+json";
		WebResponse response = request.GetResponse();
		Stream dataStream = response.GetResponseStream();
		StreamReader sreader = new StreamReader(dataStream);
		string responsereader = sreader.ReadToEnd();
		List<Periods> myPeriods = JsonConvert.DeserializeObject<List<Periods>>(responsereader);

		String forecast = "";
		forecast += "Day: " + myPeriods[1].name + "</br>" + 
					"High: " + myPeriods[1].temperature.ToString() + "</br>" + 
					"Detail: " + myPeriods[1].detailedForecast + "</br></br>";
		forecast += "Day: " + myPeriods[3].name + "</br>" + 
					"High: " + myPeriods[3].temperature.ToString() + "</br>" + 
					"Detail: " + myPeriods[3].detailedForecast + "</br></br>";
		forecast += "Day: " + myPeriods[5].name + "</br>" + 
					"High: " + myPeriods[5].temperature.ToString() + "</br>" + 
					"Detail: " + myPeriods[5].detailedForecast + "</br></br>";
		forecast += "Day: " + myPeriods[7].name + "</br>" + 
					"High: " + myPeriods[7].temperature.ToString() + "</br>" + 
					"Detail: " + myPeriods[7].detailedForecast + "</br></br>";
		forecast += "Day: " + myPeriods[9].name + "</br>" + 
					"High: " + myPeriods[9].temperature.ToString() + "</br>" + 
					"Detail: " + myPeriods[9].detailedForecast + "</br></br>";
		Label1.Text = forecast;
	}

	protected void GetCovidData()
	{
		string url = @hostURL + "/Service2.svc/covid?country=" + TextBox2.Text;
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
		request.ContentType = "application/json";
		WebResponse response = request.GetResponse();
		Stream dataStream = response.GetResponseStream();
		StreamReader sreader = new StreamReader(dataStream);
		string responsereader = sreader.ReadToEnd();

		CovidObj myCovidObj = JsonConvert.DeserializeObject<CovidObj>(responsereader);

		int doingFine = myCovidObj.confirmed.value - myCovidObj.deaths.value;

		String covDat = "";
		covDat += "Confirmed Cases: " + myCovidObj.confirmed.value.ToString() + "</br>" +
					"Recovered Cases: " + doingFine.ToString() + "</br>" +
					"Fatal Cases:     " + myCovidObj.deaths.value.ToString() + "</br>" +
					"Information up to date as of: " + myCovidObj.lastUpdate + "</br></br>";
		Label2.Text = covDat;
	}

	protected string GetCity(string zip)
	{
		string url = @hostURL + "/Service3.svc/city?zip=" + zip;
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
		request.ContentType = "application/json";
		WebResponse response = request.GetResponse();
		Stream dataStream = response.GetResponseStream();
		StreamReader sreader = new StreamReader(dataStream);
		string cityresponse = sreader.ReadToEnd();
		return cityresponse;
	}

	protected string GetState(string zip)
	{
		string url = @hostURL + "/Service3.svc/state?zip=" + zip;
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
		request.ContentType = "application/json";
		WebResponse response = request.GetResponse();
		Stream dataStream = response.GetResponseStream();
		StreamReader sreader = new StreamReader(dataStream);
		string stateresponse = sreader.ReadToEnd();
		return stateresponse;
	}

	protected string GetLat(string zip)
	{
		string url = @hostURL + "/Service3.svc/lat?zip=" + zip;
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
		request.ContentType = "application/json";
		WebResponse response = request.GetResponse();
		Stream dataStream = response.GetResponseStream();
		StreamReader sreader = new StreamReader(dataStream);
		string latresponse = sreader.ReadToEnd();
		return latresponse;
	}

	protected string GetLong(string zip)
	{
		string url = @hostURL + "/Service3.svc/long?zip=" + zip;
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
		request.ContentType = "application/json";
		WebResponse response = request.GetResponse();
		Stream dataStream = response.GetResponseStream();
		StreamReader sreader = new StreamReader(dataStream);
		string longresponse = sreader.ReadToEnd();
		return longresponse;
	}
}

public class DLocaleObject
{
	public float longitude { get; set; }
	public float latitude { get; set; }
	public string city { get; set; }
	public string state { get; set; }
}