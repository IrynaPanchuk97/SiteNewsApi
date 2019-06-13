# SiteNewsApi
Завдання:
Створити сервіс, що по таймеру (з певним інтервалом) за допомогою web driver отримує дані з одного або декількох джерел. 
Нові дані записуються в локальну базу за посередництвом черги:
Кандидати на додавання сервісом відправляються в чергу (rabbitmq).
Чергу слухає сервіс-лисенер, що власне записує в базу.
GraphQL сервіс дивиться на базу і повертає дані.
Розробити два з трьох варіантів юзер інтерфейсу: десктоп, веб, мобайл.
Для розвантаження сервісу використати кешування: redis.
Юзер-аплікації мають можливості для маркування нових даних як like/dislike.
Модель машинного навчання тренується на промаркованих даних.
Юзер-аплікації відсилають пуш нотифікацію в систему про дані, що можуть сподобатись користувачеві.
Використати Git або Mercurial.
Створити контейнери для бекенду:
Сервісу продюсера, що завантажує дані, використовуючи WebDriver і відсилає їх в чергу.
Черга rabbitmq.
Сервіс лістенера (консюмера), що кладе дані в базу.
База даних.
GraphQL service.
Запускати контейнери використовуючи ‘docker run’ або Docker compose.
