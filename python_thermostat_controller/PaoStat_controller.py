import requests 



r = requests.get(‘/api/Thermostats/B827EB3B6BC8’)
r.status_code
>>200

r.status_code == requests.codes.ok
>>>True

requests.codes['temporary_redirect']