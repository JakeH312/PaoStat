# Import requests library
import requests
import json
# api-endpoint

URL = "https://localhost:44346/api/Thermostats"

# send get request and save response as response object

r = requests.get(url=URL, verify=False)

loadedJson = json.loads(r.text)

# index and then field you want to index.. [index][key]
print(loadedJson[0]['code'])
print(loadedJson[0]['name'])
print(loadedJson[0]['temperatureReading'])
print(loadedJson[0]['temperatureSetting'])


