# AdsDistribution  
Приложение для быстрой рассылки постов в несколько разных групп.  

## Запуск  
Архив с собранным приложением можно скачать [здесь](https://drive.google.com/file/d/1RMOGek7tA8iE13MTQoc2Evy5v_kxfgTz/view?usp=sharing).  
**Важно!** Перед запуском обязательно **измените** содержимое файла _config.txt_ на свои данные. Подробная инструкция есть [ниже](#инструкция-по-использованию).  
Для старта приложения запустите файл _AdsDistribution.exe_.  

## Инструкция по использованию  
Для работы необходимо создать _config.txt_ в папке с исполняемым файлом со следующим содержанием:  
```
{
  "Login": "<Логин>",
  "Password": "<Пароль>",
  "AppId": <Id вашего приложения>,
  "Message": "<Сообщение>",
  "PhotoIds": [
    <id фотографий через запятую>
  ]
  "GroupsIds": [
    <id групп через запятую>
  ]
}
```
После добавления данного файла, достаточно просто запустить .exe файл и ждать завершения работы программы.  

### Как получить id приложения
Для того, чтобы получить id своего приложения нужно его создать, перейдя на эту [страницу](https://vk.com/apps?act=manage).  
Далее нажимаем на кнопку "Создать приложение". Теперь вводим название и выбираем платформу "Standalone-приложение". Осталось только нажать кнопку "Подключить приложение".  
Перейдя в настройки созданного приложения, копируем id нашего приложения. Готово!  

### Добавление фото к посту  
Чтобы добавить фото к посту, нужно сначала загрузить необходимые фотографии на свою страницу в ВК. То есть достаточно просто добавить эти фотографии в один из своих альбомов.  
Осталось только указать id этих фотографий (число после "\_" в адресной строке) через запятую в соответствующем месте в файле _config.txt_.  
