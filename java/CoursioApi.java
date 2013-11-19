package CoursioApi;

import java.net.*;
import java.io.*;
import java.sql.Timestamp;
import javax.crypto.Mac;
import javax.crypto.spec.SecretKeySpec;

public class CoursioApi
{
	protected HttpURLConnection connection;

	protected String salt;
	protected String publicKey;
	protected String privateKey;
	protected String baseUrl = "https://api.coursio.com/v1/";
	
    public CoursioApi(String publicKey, String privateKey, String salt) throws Exception
    {
		if (publicKey == null || privateKey == null || salt == null)
		{
			throw new Exception ("Both keys and salt are required.");
		}

		this.salt = salt;
		this.publicKey = publicKey;
		this.privateKey = privateKey;
    }
    
    public String Get(String endpoint, int objectId) throws Exception
	{
		if (objectId != 0)
		{
			endpoint += "/" + Integer.toString(objectId);
		}

		Prepare (endpoint);
		connection.setRequestMethod("GET");
		
		return ReadResponse ();
	}

	public String Post(String endpoint, String jsonString) throws Exception
	{
		Prepare (endpoint);
		connection.setRequestMethod("POST");
		
        OutputStreamWriter osw = new OutputStreamWriter(connection.getOutputStream());
        osw.write(jsonString);
        osw.flush();
        osw.close();

		return ReadResponse ();
	}

	public String Put(String endpoint, int objectId, String jsonString) throws Exception
	{
		if (objectId == 0)
		{
			throw new Exception ("No object ID specified");
		}
		endpoint += "/" + Integer.toString(objectId);

		Prepare (endpoint);
		connection.setRequestMethod("PUT");

        OutputStreamWriter osw = new OutputStreamWriter(connection.getOutputStream());
        osw.write(jsonString);
        osw.flush();
        osw.close();

		return ReadResponse ();
	}

	public String Delete(String endpoint, int objectId) throws Exception
	{
		if (objectId == 0)
		{
			throw new Exception ("No object ID specified");
		}
		endpoint += "/" + Integer.toString(objectId);

		Prepare (endpoint);
		connection.setRequestMethod("DELETE");

		return ReadResponse ();
	}

	protected void Prepare(String endpoint) throws Exception
	{
		if (endpoint == null || endpoint.length() == 0)
		{
			throw new Exception ("No endpoint specified");
		}

		// setup connection to endpoint
        URL obj = new URL(baseUrl + endpoint);
        connection = (HttpURLConnection) obj.openConnection();
        
        connection.setRequestProperty("Content-Type", "application/json");
        connection.setDoOutput(true);

		// compute HMAC
        
        // get an hmac_sha1 key from the raw key bytes
        SecretKeySpec signingKey = new SecretKeySpec(privateKey.getBytes(), "HmacSHA1");

        // get an hmac_sha1 Mac instance and initialize with the signing key
        Mac mac = Mac.getInstance("HmacSHA1");
        mac.init(signingKey);
        
        // generate timestamp
        java.util.Date date = new java.util.Date();
        Timestamp timestamp = new Timestamp(date.getTime());

        String signature = publicKey + timestamp.toString() + salt;
        
        // compute the hmac on input data bytes
        byte[] bytes = mac.doFinal(signature.getBytes());
        StringBuilder hash = new StringBuilder();
        
        for (byte b : bytes)
        {
        	hash.append(String.format("%02x", b));
        }
        
        connection.setRequestProperty ("X-Coursio-apikey", publicKey);
        connection.setRequestProperty ("X-Coursio-time", timestamp.toString());
        connection.setRequestProperty ("X-Coursio-random", salt);
        connection.setRequestProperty ("X-Coursio-hmac", hash.toString());
	}

	protected String ReadResponse() throws IOException
	{
		String result = "";
		
        // Get the response
        BufferedReader rd = new BufferedReader(new InputStreamReader(connection.getInputStream()));
        String line;
        while ((line = rd.readLine()) != null)
        {
        	result += line;
        }
        rd.close();
        
        return result;
	}
}
