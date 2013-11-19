import time
from hashlib import sha1
import hmac
import binascii
import json
import httplib2 as http

try:
    from urlparse import urlparse
except ImportError:
    from urllib.parse import urlparse

class CoursioApi:

    # initiate the class
    def __init__(self, publicKey, privateKey, salt):
        self.publicKey = publicKey
        self.privateKey = privateKey
        self.salt = salt
        self.baseUrl = 'http://api.coursio.dev'
        self.request = ''
        self.headers = {}
        self.target = ''
        self.method = 'GET'
        self.h = ''
        self.body = ''

    # prepare an endpoint and caluclate HMAC
    def prepare(self, endpoint):
        if (endpoint is None):
            raise Exception('No endpoint specified')

        # calculate microtime, first to int then to string
        microtime = str(int(round(time.time() * 1000)))

        # concatenate the raw string
        rawString = self.publicKey + microtime + self.salt

        hashed = hmac.new(self.privateKey, rawString, sha1)

        # get hmac from calculated hash
        hmacString = binascii.b2a_base64(hashed.digest())[:-1]

        # setup headers
        self.headers = {
            'X-Coursio-apikey': self.publicKey,
            'X-Coursio-time': microtime,
            'X-Coursio-random': self.salt,
            'X-Coursio-hmac': hmacString
        }

        # concatenate target
        self.target = urlparse(self.baseUrl+endpoint)

        # setup http
        self.h = http.Http()

    # get method
    def get(self, endpoint, object_id = 0):
        # cast object_id to int
        object_id = int(object_id)

        # if object_id exists, add to endpoint
        if (object_id != 0):
            endpoint = endpoint + '/' + str(object_id)

        # prepare for call
        self.prepare(endpoint)

        # set request-method
        self.method = 'GET'

        return self.response()

    def response(self):

        # build request and store response and concent in variables
        response, content = self.h.request(
            self.target.geturl(),
            self.method,
            self.body,
            self.headers
        )

        # return json from server
        return content