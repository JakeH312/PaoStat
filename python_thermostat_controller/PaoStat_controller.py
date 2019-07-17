# Import requests library
import requests
import json
# api-endpoint

URL = "https://localhost:44346/api/Thermostats"

# send get request and save response as response object

r = requests.get(url=URL, verify=False)

loadedJson = json.loads(r.text)

# index and then field you want to index.. [index][key]

# Formatted printing of the two things we really need

x = loadedJson[0]['temperatureReading']
y = loadedJson[0]['temperatureSetting']

z = "The current temperature reading is %s. \nThe current temperature setting is %s" % (
    x, y)
print(z)


# Just printing the whole Json
print("mac address accesor key is: ")
print(loadedJson[0]['code'])
print("ThermoStat Name: ")
print(loadedJson[0]['name'])
print('Current Temperature Reading')
print(loadedJson[0]['temperatureReading'])
print('Current Temperature Setting:   ')
print(loadedJson[0]['temperatureSetting'])
