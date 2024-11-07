
# Диаграмма Классов
## Текстовое описание
1. Абстрактный класс "Staff"  
    Поля:
    - id: int — уникальный идентификатор сотрудника.
    - name: String — имя сотрудника.
    - position: String — должность сотрудника.
    Операции:
    - work(): void — метод, work выполнение работы.
2. Класс "LibraryStaff" (наследуется от "Staff")
    Поля:
    - supervisor: LibraryStaff — ссылка на руководителя, если таковой есть.
    Операции:
    - serveReader(): void — обслуживает читателя.
    - manageReadingRoom(): void — управляет процессами в читальном зале.
3. Интерфейс "IReservable"  
    Операции:
    - reserve(reader: Reader): void — зарезервировать элемент.
    - cancelReservation(reader: Reader): void — отменить резерв.
    - isReserved(): boolean
4. Класс "Book" (реализует интерфейс "IReservable")  
    Поля:
    - id: int — уникальный идентификатор книги.
    - title: String — название книги.
    - author: String — автор книги.
    - category: Category — категория книги.
    - reservedBy: Reader
    Операции:
    - reserve(reader: Reader): void
    - cancelReservation(reader: Reader): void
    - isReserved(): boolean
5. Класс "Category"  
    Поля:
    - name: String — название категории.
    - books: List<Book> — список книг в данной категории.
6. Класс "Reader"  
    Поля:
    - id: int — уникальный идентификатор читателя.
    - name: String — имя читателя.
    - orders: List<Order> — список заказов, сделанных читателем.
    Операции:
    - placeOrder(book: Book): Order — метод для заказа книги.
    - cancelOrder(order: Order): void — отменяет заказ.
7. Класс "Order"  
    Поля:
    - orderNumber: int — уникальный номер заказа.
    - book: Book — зарезервированная книга.
    - reader: Reader — читатель, сделавший заказ.
    Операции:
    - confirm(): void — подтверждает заказ.
    - cancel(): void — отменяет заказ.
8. Класс "Library"  
    Поля:
    - id: int — уникальный номер библиотеки.
    - name: String — название библиотеки.
9. Класс "Room"  
    Поля:
    - id: int — уникальный номер комнаты.
    - name: String — название комнаты.
    Операции:
    - open(): void 
    - close(): void 
10. Класс "ReadingRoom"  
    Поля:
    - capacity: int — вместимость.
    - assignedStaff: LibraryStaff — персонал.
    Операции:
    - reserveSeat(reader: Reader): void 
    - releaseSeat(reader: Reader): void 
11. Класс "Seat"  
    Поля:
    - seatNumber: int — номер места.
    - isAvailable: boolean — доступность.
    - reservedBy: Reader — кем зарезервировано.
    Операции:
    - reserve(reader: Reader): void — читальный зал зарезервирован.
    - cancelReservation(reader: Reader): void — отменяет резервирование.
    - isReserved(): boolean — доступность.


## Сама диаграмма.
![АХАХХАХАХА](https://github.com/user-attachments/assets/4982cc95-cb0c-467a-826f-4236bef39c08)


# Диаграмма(мы) последовательностей

## SD1
### 1. Диаграмма последовательности для резервирования книги  
   Описывает процесс, когда читатель резервирует книгу в системе. Основные шаги:
   1. Читатель вызывает метод на резервирование книги.
   2. Сотрудник проверяет доступность книги.
   3. Если книга доступна, проверяется номер зала.
   4. Создается объект Reservation, и состояние книги обновляется на "зарезервирована".
   5. Обновляется состояние заявки на резервирование.
### Диаграмма
![SD1 drawio](https://github.com/user-attachments/assets/17c47c8d-1880-475d-a4ab-a7b3e98ae05f)



## SD2
### 2. Диаграмма описывает процесс проверки доступности экземпляра книги. Основные шаги включают:
   1. Сотрудник бииблиотеки запрашивает доступность книги.
   2. Система возвращает список подходящих экземпляров.
   3. Для каждого экземпляра проверяется, доступен ли он для выдачи читателю.
   4. Если да, то возвращается true, если нет false.
### Диаграмма
![SD2 drawio](https://github.com/user-attachments/assets/d1d4a320-bd6e-4db4-a7ca-cc76becb93e0)



## SD3
### 3. Эта диаграмма описывает процесс обслуживания читателя. Основные шаги включают:
1. Читатель приходит к библиотекарю.
2. Библиотекарь идентифицирует читателя (талон и проч.)
3. Проводится анализ читателя. (должен вернуть, утери, проч.)
4. Библиотекарь запрашивает какая книга нужна.
5. Если требуемая книга требует обновления, то она обновляется.
6. Проводится поиск нужной книги.
7. Если экземпляр книги не тот, обновляются предпочтения и экземпляр книги.
### Диаграмма
![SD3 drawio](https://github.com/user-attachments/assets/0499c7ba-8192-49c4-ad33-71c4a5e0de09)


# Диаграмма объектов

## Текстовое описание
Диаграмма объектов представляет собой структуру государственного учреждения, включающую библиотеку, читальные залы, работников библиотеки и китегории книг. Ниже приведено описание элементов диаграммы:
1. Библиотека
    - lib: Library
      - id: 532
        - name: "НИ ТГУ"
2. Читальные залы
    - rr1: Reading Room 1
      - capacity: 34
        - name: "Зал естественных наук"
    - rr2: Reading Room 2
      - capacity: 62
        - name: "Зал гуманитарный наук"
    - rr3: Reading Room 3
      - capacity: 104
        - name: "Зал художественной литературы"
3. Категории
  - rr1_cat1: Category1
    - name: "Органическая химия"
  - rr1_cat2: Category2
    - name: "Нейробиология"
  - rr2_cat1: Category1
    - name: "История Литвы"
  - rr2_cat2: Category2
    - name: "Социология"
  - rr3_cat1: Category1
    - name: "Экзистенциализм"
  - rr3_cat2: Category2
    - name: "XX век"
4. Работники библиотеки
    - rr1_lst1: LibraryStaff
        - supervisor: "Петрова Анна Сергеевна"
    - rr2_lst1: LibraryStaff
        - supervisor: "Сидоров Алексей Викторович"
    - rr3_lst1: LibraryStaff
        - supervisor: "Кузнецова Мария Анатольевна"
    - rr3_lst2: LibraryStaff
        - supervisor: "Кузнецова Мария Анатольевна"

## Диаграмма
![ДО](https://github.com/user-attachments/assets/0f88c56e-ac65-48e2-be99-94f14e4ea340)
