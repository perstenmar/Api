using System;
using System.Net;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace CoursioTest
{
	public class CoursioApi
	{
		protected WebRequest request;

		protected string salt;
		protected string publicKey;
		protected string privateKey;
		protected string baseUrl = "http://api.coursio.dev/v1/";

		public CoursioApi (string publicKey, string privateKey, string salt = "coursiosalt")
		{
			this.salt = salt;
			this.publicKey = publicKey;
			this.privateKey = privateKey;
		}

		public string Get(string endpoint, int objectId = 0)
		{
			if (objectId != 0)
			{
				endpoint += "/" + objectId.ToString();
			}

			this.Prepare (endpoint);
			this.request.Method = "GET";

			return this.ReadResponse ();
		}

		public string Post(string endpoint, string jsonString)
		{
			this.Prepare (endpoint);
			this.request.Method = "POST";

			byte[] byteArray = Encoding.UTF8.GetBytes (jsonString);

			// Set the ContentLength property of the WebRequest.
			this.request.ContentLength = byteArray.Length;

			// Write data to the Stream
			Stream dataStream = this.request.GetRequestStream ();
			dataStream.Write (byteArray, 0, byteArray.Length);
			dataStream.Close ();

			return this.ReadResponse ();
		}

		public string Put(string endpoint, int objectId, string jsonString)
		{
			if (objectId == 0)
			{
				throw new System.Exception ("No object ID specified");
			}
			endpoint += "/" + objectId.ToString();

			this.Prepare (endpoint);
			this.request.Method = "PUT";

			byte[] byteArray = Encoding.UTF8.GetBytes (jsonString);

			// Set the ContentLength property of the WebRequest.
			this.request.ContentLength = byteArray.Length;

			// Write data to the Stream
			Stream dataStream = this.request.GetRequestStream ();
			dataStream.Write (byteArray, 0, byteArray.Length);
			dataStream.Close ();

			return this.ReadResponse ();
		}

		public string Delete(string endpoint, int objectId)
		{
			if (objectId == 0)
			{
				throw new System.Exception ("No object ID specified");
			}
			endpoint += "/" + objectId.ToString();

			this.Prepare (endpoint);
			this.request.Method = "DELETE";

			return this.ReadResponse ();
		}

		protected void Prepare(string endpoint)
		{
			if (endpoint == null || endpoint.Length == 0)
			{
				throw new System.Exception ("No endpoint specified");
			}

			// setup connection to endpoint
			this.request = WebRequest.Create(this.baseUrl + endpoint);

			// compute HMAC
			var enc = Encoding.ASCII;
			HMACSHA1 hmac = new HMACSHA1(enc.GetBytes(this.privateKey));
			hmac.Initialize();

			var timestamp = DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"); 
			var signatureString = this.publicKey + timestamp + this.salt;
			byte[] buffer = enc.GetBytes(signatureString);
			var hash = BitConverter.ToString(hmac.ComputeHash(buffer)).Replace("-", "").ToLower();

			this.request.Headers ["X-Coursio-apikey"] = this.publicKey;
			this.request.Headers ["X-Coursio-time"] = timestamp;
			this.request.Headers ["X-Coursio-random"] = this.salt;
			this.request.Headers ["X-Coursio-hmac"] = hash;
		}

		protected string ReadResponse()
		{
			// Get the response.
			WebResponse response = this.request.GetResponse ();

			//	Console.WriteLine (((HttpWebResponse)response).StatusDescription);

			// Get the stream content and read it
			Stream dataStream = response.GetResponseStream ();
			StreamReader reader = new StreamReader (dataStream);

			// Read the content.
			string responseFromServer = reader.ReadToEnd ();

			// Clean up
			reader.Close ();
			dataStream.Close ();
			response.Close ();

			return responseFromServer;
		}
	}
}
