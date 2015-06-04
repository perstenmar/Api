using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace CoursioApi
{
	public static class CoursioApiFactory
	{
		/// <summary>
		/// Creates an instance of CoursioApi
		/// Add two parameters in your appsettings file, CoursioPrivateKey and CoursioPublicKey, auto genereats SALT
		/// </summary>
		/// <returns></returns>
		public static CoursioApi CreateApiClientFromAppSettingsDef()
		{
			var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			var random = new Random();
			var salt = new string(
				Enumerable.Repeat(chars, 12)
						  .Select(s => s[random.Next(s.Length)])
						  .ToArray());

			return CreateApiClientFromAppSettingsDef(salt);
		}

		/// <summary>
		/// Creates an instance of CoursioApi
		/// Add two parameters in your appsettings file, CoursioPrivateKey and CoursioPublicKey, both provided by Coursio
		/// </summary>
		/// <param name="salt">Salt that will be added to the connection to the API</param>
		/// <returns></returns>
		public static CoursioApi CreateApiClientFromAppSettingsDef(string salt)
		{
			string privateKey = ConfigurationManager.AppSettings["CoursioPrivateKey"];
			string publicKey = ConfigurationManager.AppSettings["CoursioPublicKey"];

			return CreateApiClient(salt, privateKey, publicKey);
		}

		/// <summary>
		/// Creates an instance of CoursioApi
		/// </summary>
		/// <param name="salt">Salt that will be added to the connection to the API</param>
		/// <param name="privateKey">Provided by Coursio</param>
		/// <param name="publicKey">Provided by Coursio</param>
		/// <returns></returns>
		public static CoursioApi CreateApiClient(string salt, string privateKey, string publicKey)
		{

			if(string.IsNullOrEmpty(salt))
			{
				throw new ArgumentException("Salt is empty", "salt");
			}

			if(string.IsNullOrEmpty(privateKey))
			{
				throw new ConfigurationException("Missing AppSetting CoursioPrivateKey");
			}

			if (string.IsNullOrEmpty(publicKey))
			{
				throw new ConfigurationException("Missing AppSetting CoursioPublicKey");
			}

			CoursioApi apiClient = new CoursioApi(publicKey, privateKey, salt);
			return apiClient;
		}

	}
}
