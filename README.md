# TaskSeverstal
Инструкция по созданию базы данных MSSQL ии ее таблиц
- Для начала скачайте проект, и добавьте его по пути: Этот компьютер/Локальный диск(C:)/Пользователи/Имя_Аккаунта/source/repos/
- Открываете проект
- В обозревателе решений переходите в файл: Domain/Context/DeliveriesContext
- Найдите метод OnConfiguring, там вы увидите строку подключения к базе данных: optionsBuilder.UseSqlServer("Server=DESKTOP-M508TRG;Database=Deliveries;Trusted_Connection=True;TrustServerCertificate=Yes");
- Вместо " Server=DESKTOP-M508TRG ", вставляете имя сервера своего SqlServer
- Должно получится примерно следующее: optionsBuilder.UseSqlServer("Server=ВАШЕ_ИМЯ_СЕРВЕРА;Database=Deliveries;Trusted_Connection=True;TrustServerCertificate=Yes");
- Запускаете проект. В консольке дожна выскочить ошибка. Ничего страшного, это значит что БД создана
- После чего нужно выполнить следующий запрос в MSSQL: USE Deliveries INSERT INTO TypeDelivery (TypeDeliveryName) VALUES ('Почта'),('Самолет'),('Курьер');
- Снова запускаете проект, и все готово
