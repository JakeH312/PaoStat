# Import requests library
import requests
import json
# api-endpoint

URL = "https://localhost:44346/api/Thermostats"

# send get request and save response as response object

r = requests.get(url=URL, verify=False)

r.status_code

print(r)
# convert data to json format

json_data = r.json()

print(json_data)

# json_string = json.dumps(json_data)

# #
# #print(json_data[0])
# #print(json_string)
# print(json_string[:])

# data =
