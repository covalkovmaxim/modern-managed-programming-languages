Реализован агоритм A* для решение игры в 15. 

Запуск:
```
dotnet run BoardSize StepNumber Coef1 Coef2
```
Где 

***BoardSize*** - размер поля. 

***StepNumber*** - число случайных шагов сделанных от начального состояния.

***Coef1*** - вес при манхэттенском расстоянии.

***Coef2*** - вес при длине пути.

#### Выбор коэффициентов
Из результатов серии экспериментов можно сказать, что наиболее оптимальным является выбор Coef1 = 10, Coeff2 = 1. 

#### Работа на досках разного размера
На досках размеров 3 и 4 алгоритм, как правило, сходится менее чем за секунду. На доске размера 5 алгоритм может работать долго: в пределах нескольких минут.   
