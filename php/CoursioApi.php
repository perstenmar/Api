<?php

class CoursioApi
{
    protected $request;

    protected $salt;
    protected $publicKey;
    protected $privateKey;
    protected $baseUrl = 'https://api.coursio.com/v1/';

    public function __construct($publicKey, $privateKey, $salt = 'coursio_salt')
    {
        if (!$publicKey || !$privateKey)
        {
            throw new Exception('Both public and private key are required.');
        }

        $this->salt = $salt;
        $this->publicKey = $publicKey;
        $this->privateKey = $privateKey;
    }

    /**
     * API GET wrapper
     *
     * @param $endpoint
     * @param int $objectId
     * @return mixed
     */
    public function Get($endpoint, $objectId = 0)
    {
        if ($objectId)
        {
            $endpoint .= '/' . $objectId;
        }
        $this->Prepare($endpoint);

        curl_setopt($this->request, CURLOPT_CUSTOMREQUEST, 'GET');

        return $this->ReadResponse();
    }

    /**
     * API POST wrapper
     *
     * @param $endpoint
     * @param $data
     * @return mixed
     */
    public function Post($endpoint, $data)
    {
        $this->Prepare($endpoint);

        curl_setopt($this->request, CURLOPT_CUSTOMREQUEST, 'POST');
        curl_setopt($this->request, CURLOPT_POSTFIELDS, json_encode($data));

        return $this->ReadResponse();
    }

    /**
     * API PUT wrapper
     *
     * @param $endpoint
     * @param $objectId
     * @param $data
     * @return mixed
     */
    public function Put($endpoint, $objectId, $data)
    {
        if ($objectId)
        {
            $endpoint .= '/' . $objectId;
        }
        $this->Prepare($endpoint);

        curl_setopt($this->request, CURLOPT_CUSTOMREQUEST, 'PUT');
        curl_setopt($this->request, CURLOPT_POSTFIELDS, json_encode($data));

        return $this->ReadResponse();
    }

    /**
     * API DELETE wrapper
     *
     * @param $endpoint
     * @param int $objectId
     * @return mixed
     * @throws Exception
     */
    public function Delete($endpoint, $objectId = 0)
    {
        if (!$objectId)
        {
            throw new Exception('Object ID is required');
        }

        $this->Prepare($endpoint . '/' . $objectId);

        curl_setopt($this->request, CURLOPT_CUSTOMREQUEST, 'DELETE');

        return $this->ReadResponse();
    }

    /**
     * Prepares the API call, sets the headers
     *
     * @param $endpoint
     * @throws Exception
     */
    protected function Prepare($endpoint)
    {
        if (!$endpoint || !strlen($endpoint))
        {
            throw new Exception('No endpoint specified');
        }

        // compute HMAC
        $timestamp = microtime(true);
        $rawString = $this->publicKey . $timestamp . $this->salt;
        $hash = hash_hmac ('sha1', $rawString , $this->privateKey);

        $headers = array
        (
            'X-Coursio-apikey: ' . $this->publicKey,
            'X-Coursio-time: ' . $timestamp,
            'X-Coursio-random: ' . $this->salt,
            'X-Coursio-hmac: ' . $hash,
        );

        // setup connection to endpoint
        $this->request = curl_init($this->baseUrl . $endpoint);
        curl_setopt($this->request, CURLOPT_HTTPHEADER, $headers);
        curl_setopt($this->request, CURLOPT_RETURNTRANSFER, true);
    }

    /**
     * Reads the API response and decodes it
     *
     * @return mixed
     */
    protected function ReadResponse()
    {
        $result = curl_exec($this->request);
        curl_close($this->request);

        return json_decode($result, true);
	}
}
