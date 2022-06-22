# TelegramBot


## Схема базы данных: 


* [Файл Visual Paradigm](https://drive.google.com/file/d/1F1Ws-7HqkaQHEjBagT9uJbMbJCjs41Ja/view?usp=sharing)


## Задокументированные в процессе разработки материалы


* [1 Итерация (docx1)](https://docs.google.com/document/d/10Pl8cNeroN4ELPBJEFJYHbLKO3M5xyUz/edit?usp=sharing&ouid=108028726675719309250&rtpof=true&sd=true)
* [2 Итерация (docx2)](https://docs.google.com/document/d/1sclPLupmtywmYUGC7LiHT2mezGBO-9fV/edit?usp=sharing&ouid=108028726675719309250&rtpof=true&sd=true)
* [3 Итерация (docx3)](https://docs.google.com/document/d/1Ih-FHPuzBRGFw3-KYE5kRTtUp29q1lZc/edit?usp=sharing&ouid=108028726675719309250&rtpof=true&sd=true)

## Требования

* [Что в итоге хотим](https://vk.com/doc452253714_630412686?hash=ftzncmJumCGDeBxqt4nvIqj8UotwKzQKEj4DCvwSGu8&dl=y3GfYD0qcbn2lLbZZC8DVA67kbMN3iyVEFtksUtzctL)


## Как развернуть?

### Для работы необходимо уставновить PostgresSQL 

Заполнить нужные поля в config.example.json, поместить в его в папку с исполняемым файлом
*(аналог ```.env```)*


Применить миграции для бд, выполнив команду ```Update-Database```
*(https://metanit.com/sharp/entityframeworkcore/2.15.php)*

