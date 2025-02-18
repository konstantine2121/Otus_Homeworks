# Практическое применение SOLID принципов. (Ответ)

## Критерии оценки:

2 балла: Принцип единственной ответственности;  
1 балла: Принцип инверсии зависимостей;  
2 балла: Принцип разделения интерфейса;  
2 балла: Принцип открытости/закрытости;  
2 балла: Принцип подстановки Барбары Лисков;  
1 балл: CodeStyle, грамотная архитектура, всё замечания проверяющего исправлены.

Минимально необходимый балл: 6.

----

## Принцип единственной ответственности

`RandomGenerator` -- единственная причина для изменения - это изменение алгоритма генерации  
`Game` --  единственная причина для изменения - это изменение логики игры, ибо логикак ввода/вывода вынесена в `GameController`

----

## Принцип инверсии зависимостей

```cs
public Game(IRandomGenerator valueGenerator, int attemptsToWin, Func<int> readUserGuessFunc)
```

readUserGuessFunc -- мы не зависим от способа ввода данных пользователем.

----

## Принцип разделения интерфейса

Игра слишком маленькая - его тут просто некуда засунуть.  
ИМХО - В целом не стоит использовать паттерны ради паттернов и подходы ради подходов.  
Помогают решить задачу - используем. Не помогают - не используем.  

Но нужно заработать баллы - поэтому пример ниже

### Пример разделения

Можно раделить IGame 

```cs
internal interface IGame : IDisposable
{
    int AttemptsToWin { get; }

    int AttemptCounter { get; }

    int NumberToGuess { get; }

    int MinNumber { get; }

    int MaxNumber { get; }

    event EventHandler NewGameStarted;
    event EventHandler<bool> GameFinished;
    event EventHandler<int> TurnStarted;
    event EventHandler<ComparisonResult> TurnFinished;

    void StartNewGame();
}
```

на IGameInfo

```cs
internal interface IGameInfo
{
    int AttemptsToWin { get; }

    int AttemptCounter { get; }

    int NumberToGuess { get; }

    int MinNumber { get; }

    int MaxNumber { get; }
   
}
```
и на IGameEvents

```cs
internal interface IGameEvents : IDisposable
{
    event EventHandler NewGameStarted;
    event EventHandler<bool> GameFinished;
    event EventHandler<int> TurnStarted;
    event EventHandler<ComparisonResult> TurnFinished;
}
```

Результат

```cs
internal interface IGame : IGameInfo, IGameEvents, IDisposable
{
     void StartNewGame();
}
```

В проект это разделение пихать не стал.

----

## Принцип открытости/закрытости

```cs
class RandomGenerator : IRandomGenerator

public virtual int Generate()
{
    return _random.Next(Min, Max + 1);
}
```

Generate() - можно переопределить механизм генерации, если в наследнике соблюсти ограничения Min, Max

## Принцип подстановки Барбары Лисков

```cs
public Game(IRandomGenerator valueGenerator, int attemptsToWin, Func<int> readUserGuessFunc)
```

valueGenerator -- можно засунуть любой генератор (IRandomGenerator)

```cs
public GameController(IGameFactory gameFactory)
{
    _game = gameFactory.Create(ReadUserInput);	
```

gameFactory - можно подсунуть любую (IGameFactory)


