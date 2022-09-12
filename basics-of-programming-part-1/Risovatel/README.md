# Рефакторинг
**1. Название переменных, классов должны быть на английском.** 

Меняем все русские слова написанные транслитом на английские. Если просто изменить название в одном месте, оно не изменится в другом. Чтобы изменить название везде, нажимаем на название курсом + сочетание клавиш ```CTRL + R, R```.
```
    static Graphics grafika; // было
    static Graphics graphics; // стало
```
```
    class Risovatel
    class Painter
```
```
    public static void Initialization(Graphics novayaGrafika)
    public static void Initialization(Graphics newGraphics)
```
```
    public static void makeIt(Pen ruchka, double dlina, double ugol)
    public static void makeIt(Pen pen, double length, double angle)
```
```
    public static void Change(double dlina, double ugol)
    public static void Change(double length, double angle)
```
```
    public static void Draw(int shirina, int visota, double ugolPovorota, Graphics grafika)
    public static void Draw(int width, int height, double rotationAngle, Graphics graphics)
```
**2. Форматирование кода**

Чтобы код был хорошо читаем, всегда используйте форматирование. Самому раставлять табы будет очень сложно, поэтому в средах разработки есть автоматическое форматирование. Горячие кнопки отличаются для разных программ, поэтому придется загуглить. Нам не впервой :)

**3. Стиль написания составных слов**

В С# принято писать составные слова в переменных в ```lowerCamelCase``` (первое слово с маленькой, остальные с большой), а название методов в ```UpperCamelCase``` (Все слова начинаются с большой буквы)
```
    public static void set_position(float x0, float y0)
    public static void SetPosition(float x0, float y0)
```
```
    var diagonal_length = Math.Sqrt(2) * (sz * 0.375f + sz * 0.04f) / 2;
    var diagonalLength = Math.Sqrt(2) * (sz * 0.375f + sz * 0.04f) / 2;
```
**4. Переменные и функции должны иметь понятные названия**

Без этого другому человеку будет сложно разобраться в вашем коде
```
    static float x, y;
    static float positionX, positionY;
```
```
    public static void SetPosition(float x0, float y0)
    public static void SetPosition(float newCoordinateX, float newCoordinateY)
```
```
    public static void makeIt(Pen pen, double length, double angle)
    public static void PaintLineAngle(Pen pen, double length, double angle)
```
```
    var x1 = (float)(positionX + length * Math.Cos(angle));
    var y1 = (float)(positionY + length * Math.Sin(angle));
    
    var newPositionX = (float)(positionX + length * Math.Cos(angle));
    var newPositionY = (float)(positionY + length * Math.Sin(angle));
```
```
    public static void Change(double length, double angle)
    public static void ChangeRotation(double length, double angle)
```
**5. Лишний квалификатор**

Т.к. мы используем методы классы внутри самого класса, то нет необходимости вызывать его полностью
```
    Painter.graphics = newGraphics;
    Painter.graphics.SmoothingMode = SmoothingMode.None;
    Painter.graphics.Clear(Color.Black);
    
    graphics = newGraphics;
    graphics.SmoothingMode = SmoothingMode.None;
    graphics.Clear(Color.Black);
```
**6. Don't repeat yourself**

Правило DRY, которому должен следовать каждый. Если код повторяется, его необходимо вынести в отдельную функцию. Это нужно не только для уменьшения кода, но и для доступности его изменения.
```
   currentCoordinateX = newCoordinateX;
   currentCoordinateY = newCoordinateY;
   
   SetPosition(newCoordinateX, newCoordinateY);
```
**7. Модификаторы доступа**

Мы должны всегда получать доступ только к тем данным, которые необходимо использовать. Если делать все метода и переменные публичными, это ведет к потенциальным проблемам доступа и безопасности.
Вы же не даете всем доступ к своей квартире в надежде, что туда никто не войдет без разрешения.
```
    static float positionX, positionY;
    static Graphics graphics;
    
    private static float positionX, positionY;
    private static Graphics graphics;
```
**8. Вынесение объектов в классы**
В данном примере у нас все, у нас объединены два функционала: рисование и нахождение позиции координат, это нарушает принципы SOLID. Можно разделить их на два класса.
```
class Position
    {
        internal static Coordinate Coordinate = new Coordinate(0, 0);

        public static void SetPositionRotation(double length, double angle)
        {
            var newCoordinate = GetCoordinateRotation(length, angle);
            Coordinate.CoordinateX = newCoordinate.CoordinateX;
            Coordinate.CoordinateY = newCoordinate.CoordinateY;
        }

        public static void SetCoordinate(float coordinateX, float coordinateY)
        {
            Coordinate = new Coordinate(coordinateX, coordinateY);
        }

        public static Coordinate GetCoordinateRotation(double length, double angle)
        {
            return new Coordinate(
                (float)(Coordinate.CoordinateX + length * Math.Cos(angle)),
                (float)(Coordinate.CoordinateY + length * Math.Sin(angle))
            );
        }
    }

    class Coordinate
    {
        internal float CoordinateX;
        internal float CoordinateY;

        public Coordinate(float coordinateX, float coordinateY)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
        }

        public void SetCoordinate(float newCoordinateX, float newCoordinateY)
        {
            CoordinateX = newCoordinateX;
            CoordinateY = newCoordinateY;
        }
    }
```
**Дополнительно**

Встречали ли вы когда-нибудь классный проект с открытым исходным кодом, заходили в код, а комментарии на китайском? Чтобы таких ситуаций больше не было, лучше писать комментарии на английском, тогда твой код будет легче понять другим людям.
Комментарии на английском

```
    // rotationAngle пока не используется, но будет использоваться в будущем
    // rotationAngle is not used yet, but will be used in the future
```

*В данной главе описаны не все изменения, так как рефакторинг происходит очень быстро и каждый шаг сложно описать. Для лучшего понимания смотрите одновременно новый и старый код. Мой код неидеальным, можно улучшить его по этим параметрам:*
- Добавить еще Get и Set методы для свойств.
- Найти последовательность изменений угла
