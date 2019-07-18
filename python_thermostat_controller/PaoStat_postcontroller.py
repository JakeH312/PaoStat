# Import requests library
# Gets the current temperature reading from the webserver
import urllib
import urllib3
import requests
import json
# api-endpoint
import re

# raw_in = input('B8:27:EB:3B:6B:C8')
# code = re.compile(raw_in)
# print(code)


# url1 = "https://localhost:44346/api/Thermostats/"
# url2 = 'B8:27:EB:3B:6B:C8'
# url1 += url2
# url3 = "/temperaturereading/"
# url1 += url3
# print(url1)


URL = "https://localhost:44346/api/Thermostats/B8:27:EB:3B:6B:C8/temperaturereading/"

r = requests.get(url=URL, verify=False)

loadedJson = json.loads(r.text)

print(loadedJson)
