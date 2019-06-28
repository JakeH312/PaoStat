# Import requests library
import requests
import json
# api-endpoint

URL = "https://localhost:44346/api/Thermostats"

# send get request and save response as response object

r = requests.get(url=URL, verify=False)

loadedJson = json.loads(r.text)

# Do we need this?

# json_data = r.json()

# index and then field you want to index
print(loadedJson[0]['code'])
