Pet Project: "TaskTracker API" (Учет задач)

Цель: Создать RESTful API для управления задачами (аналог Trello, но проще).
1. Основные требования
Функционал

    Пользователи:

        Регистрация (/api/auth/register).

        Авторизация (JWT-токен, /api/auth/login).

    Задачи (Tasks):

        CRUD (создание, чтение, обновление, удаление).

        Возможность пометить задачу как выполненную.

        Фильтрация задач по статусу (все/активные/завершенные).

    Дополнительно (по желанию):

        Категории задач (например, "Работа", "Личное").

        Приоритет задач (низкий, средний, высокий).

        Комментарии к задачам.

Технологии

    Язык: C# (.NET 6/7/8).

    База данных: PostgreSQL (или SQLite для простоты).

    ORM: Entity Framework Core.

    Аутентификация: JWT.

    Документация API: Swagger.

2. Этапы реализации
Этап 1. База данных и модели

    Спроектировать схему БД (минимум 2 таблицы: Users, Tasks).

    Настроить EF Core (DbContext, миграции).

Этап 2. API для задач

    Реализовать контроллер TasksController с методами:

        GET /api/tasks – список задач.

        POST /api/tasks – создать задачу.

        PUT /api/tasks/{id} – изменить задачу.

        DELETE /api/tasks/{id} – удалить задачу.

Этап 3. Аутентификация

    Добавить Identity или ручную реализацию JWT.

    Защитить эндпоинты (например, создавать задачи могут только авторизованные пользователи).

Этап 4. Дополнительные фичи

    Валидация запросов (FluentValidation).

    Логирование (Serilog или встроенный ILogger).

    Тесты (xUnit/NUnit, хотя бы 1-2 интеграционных теста).

3. Бонусные задания

    Docker: Задеплоить приложение в Docker-контейнере.

    Кэширование: Добавить Redis для кэширования списка задач.

    Фронтенд: Написать простой интерфейс на Blazor/React (если хочется fullstack)